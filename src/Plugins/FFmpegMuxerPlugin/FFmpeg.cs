﻿// Copyright 2012-2014 Andrew C. Dvorak
//
// This file is part of BDHero.
//
// BDHero is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// BDHero is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with BDHero.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using BDHero.BDROM;
using BDHero.JobQueue;
using DotNetUtils.Extensions;
using DotNetUtils.FS;
using OSUtils.JobObjects;
using ProcessUtils;
using Timer = System.Timers.Timer;

namespace BDHero.Plugin.FFmpegMuxer
{
    public class FFmpeg : BackgroundProcessWorker
    {
        private static readonly log4net.ILog Logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly TimeSpan ProgressParseInterval = TimeSpan.FromMilliseconds(250);
        private static readonly TimeSpan ExitWaitTimeout = ProgressParseInterval + ProgressParseInterval;

        #region Regexes - progress parsing

        private static readonly Regex FrameRegex = new Regex(@"^frame=(\d+)$");
        private static readonly Regex FpsRegex = new Regex(@"^fps=([\d.]+)$");
        private static readonly Regex TotalSizeRegex = new Regex(@"^total_size=(\d+)$");
        private static readonly Regex OutTimeMsRegex = new Regex(@"^out_time_ms=(\d+)$");
        private static readonly Regex ProgressRegex = new Regex(@"^progress=(\w+)$");

        #endregion

        #region Public progress getter properties

        public long CurFrame { get; private set; }
        public double CurFps { get; private set; }
        public long CurSize { get; private set; }
        public long CurOutTimeMs { get; private set; }

        #endregion

        private readonly IJobObjectManager _jobObjectManager;
        private readonly ITempFileRegistrar _tempFileRegistrar;

        private readonly string _progressFilePath;
        private readonly string _inputFileListPath;

        private readonly string _reportDumpFileDir;
        private string _reportDumpFilePath;

        private readonly TimeSpan _playlistLength;

        private readonly BackgroundWorker _progressWorker = new BackgroundWorker();

        private readonly IList<StdErrMessage> _stdErr = new List<StdErrMessage>();

        private readonly ManualResetEventSlim _cleanExitEvent = new ManualResetEventSlim();

        public FFmpeg(Job job, Playlist playlist, string outputMKVPath, IJobObjectManager jobObjectManager, ITempFileRegistrar tempFileRegistrar)
            : base(jobObjectManager)
        {
            _jobObjectManager  = jobObjectManager;
            _tempFileRegistrar = tempFileRegistrar;

            _progressFilePath  = _tempFileRegistrar.CreateTempFile(GetType(), "progress.log");
            _inputFileListPath = _tempFileRegistrar.CreateTempFile(GetType(), "inputFileList.txt");
            _reportDumpFileDir = Path.GetDirectoryName(_progressFilePath);

            _playlistLength    = playlist.Length;

            var inputM2TSPaths = playlist.StreamClips.Select(clip => clip.FileInfo.FullName).ToList();
            var selectedTracks = playlist.Tracks.Where(track => track.Keep).ToList();
            var trackIndexer   = new FFmpegTrackIndexer(playlist);

            var cli = new FFmpegCLI(Arguments)
                .DumpLogFile()
                .SetLogLevel(FFmpegLogLevel.Error)
                .RedirectProgressToFile(_progressFilePath)
                .GenPTS()
                .ReplaceExistingFiles()
                .SetInputPaths(inputM2TSPaths, _inputFileListPath)
                .SetMovieTitle(job)
                .SetSelectedTracks(selectedTracks, trackIndexer)
                .CopyAllCodecs()
                .ConvertLPCM()
                .SetOutputPath(outputMKVPath)
                ;

            ExePath = cli.ExePath;

            BeforeStart += OnBeforeStart;
            StdErr += OnStdErr;
            Exited += (state, code, exception, time) => OnExited(state, code, job.SelectedReleaseMedium, playlist, outputMKVPath);

            CleanExit = false;
        }
        private FFmpeg(ArgumentList arguments, IJobObjectManager jobObjectManager)
            : base(jobObjectManager)
        {
            Arguments = arguments;

            var cli = new FFmpegCLI(Arguments);

            ExePath = cli.ExePath;
        }
        public static string ExeVersion(IJobObjectManager jobObjectManager)
        {
            var sb = new StringBuilder();

            var arguments = new ArgumentList("-version");

            var ffmpeg = new FFmpeg(arguments, jobObjectManager);

            ffmpeg.StdOut += delegate (string line) { sb.AppendLine(line); };

            try
            {
                ffmpeg.Start(); // sync
            }
            catch (Exception ex)
            {
                Logger.Error("FFmpeg.ExeVersion", ex);
            }

            var result = sb.ToString();

            // we want the first 2 lines only
            int length = result.IndexOf(Environment.NewLine);
            length = result.IndexOf(Environment.NewLine, length + 1);
            if (length > 0)
                result = result.Substring(0, length);

            return result;
        }

        #region Process start

        protected override void OnBeforeStart(Process process)
        {
            base.OnBeforeStart(process);

            process.StartInfo.WorkingDirectory = _reportDumpFileDir;
        }

        protected override void OnStart(Process process)
        {
            base.OnStart(process);

            if (string.IsNullOrEmpty(_reportDumpFileDir))
                return;

            var i = 0;
            while (_reportDumpFilePath == null && i++ < 10)
            {
                _reportDumpFilePath = Directory.GetFiles(_reportDumpFileDir, "ffmpeg*.log").FirstOrDefault();

                if (_reportDumpFilePath == null)
                {
                    Thread.Sleep(500);
                }
            }
        }

        #endregion

        #region Logging

        public void Log()
        {
            LogStdErr();
            LogDumpFile();
        }

        private void LogStdErr()
        {
            if (!_stdErr.Any())
                return;

            Logger.WarnFormat("StdErr:\n{0}", Indent(_stdErr.Select(message => message.ToString())));
        }

        private void LogDumpFile()
        {
            if (_reportDumpFilePath == null)
                return;

            var tail = FileUtils.Tail(_reportDumpFilePath, 30, Environment.NewLine);
            var dump = Indent(tail);
            Logger.WarnFormat("Report Dump:\n{0}", dump);
        }

        private static void LogExit(NonInteractiveProcessState processState, int exitCode)
        {
            const string message = "FFmpeg exited with state {0} and code {1}";
            switch (processState)
            {
                case NonInteractiveProcessState.Completed:
                    Logger.InfoFormat(message, processState, exitCode);
                    break;
                case NonInteractiveProcessState.Killed:
                    Logger.WarnFormat(message, processState, exitCode);
                    break;
                default:
                    Logger.ErrorFormat(message, processState, exitCode);
                    break;
            }
        }

        private static string Indent(IEnumerable<string> lines)
        {
            return lines.IndentTrim();
        }

        #endregion

        #region StdErr

        #region Error messages/codes to ignore

        private static readonly string[] ErrorsToIgnoreAlways =
        {
            "Not a valid DCA frame",
            "Last message repeated",
        };

        private static readonly string[] ErrorsToIgnoreIfComplete =
        {
            "max resync size reached, could not find sync byte", // TODO: How should we handle this?
        };

        private static readonly string[] NonReportableErrors =
        {
        };

        /// <summary>
        ///     From FFmpeg src (<c>doc/errno.txt</c>).
        /// </summary>
        private static readonly Dictionary<string, string> NonReportableErrorCodes = new Dictionary<string, string>
        {
            { "EACCES",       "Permission denied" },
            { "EAGAIN",       "Resource temporarily unavailable" },
            { "EAUTH",        "Authentication error" },
            { "EBUSY",        "Device or resource busy" },
            { "ECANCELED",    "Operation canceled" },
            { "ECONNREFUSED", "Connection refused" },
            { "ECONNRESET",   "Connection reset" },
            { "EDEVERR",      "Device error" },
            { "EDQUOT",       "Disc quota exceeded" },
            { "EFBIG",        "File too large" },
            { "EHOSTDOWN",    "Host is down" },
            { "EHOSTUNREACH", "No route to host" },
            { "EHWPOISON",    "Memory page has hardware error" },
            { "EIO",          "I/O error" },
            { "EMFILE",       "Too many open files" },
            { "EMLINK",       "Too many links" },
            { "EMSGSIZE",     "Message too long" },
            { "ENAMETOOLONG", "File name too long" },
            { "ENETDOWN",     "Network is down" },
            { "ENETRESET",    "Network dropped connection on reset" },
            { "ENETUNREACH",  "Network unreachable" },
            { "ENFILE",       "Too many open files in system" },
            { "ENODEV",       "No such device" },
            { "ENOENT",       "No such file or directory" },
            { "ENOFILE",      "No such file or directory" },
            { "ENOMEM",       "Not enough space" },
            { "ENONET",       "Machine is not on the network" },
            { "ENOSPC",       "No space left on device" },
            { "ENXIO",        "No such device or address" },
            { "EPWROFF",      "Device power is off" },
            { "EROFS",        "Read-only file system" },
            { "ETIMEDOUT",    "Connection timed out" },
            { "ETXTBSY",      "Text file busy" },
            { "EUSERS",       "Too many users" },
        };

        #endregion

        private static bool ShouldIgnoreError(string line)
        {
            return ErrorsToIgnoreAlways.Any(line.Contains);
        }

        private void OnStdErr(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return;

            _stdErr.Add(new StdErrMessage(DateTime.Now, line));

            if (ShouldIgnoreError(line))
            {
                Logger.Warn(line);
                return;
            }

            Logger.Error(line);

            try
            {
                // Preserve stack trace by throwing and catching exception
                throw new FFmpegException(line)
                      {
                          IsReportable = IsReportable(line)
                      };
            }
            catch (FFmpegException e)
            {
                Exception = e;
            }
        }

        private static bool IsReportable(string line)
        {
            return !IsNonReportable(line);
        }

        private static bool IsNonReportable(string line)
        {
            return NonReportableErrors.Any(line.Contains)
                || NonReportableErrorCodes.Keys.Any(key => new Regex(string.Format(@"\b{0}\b", key)).IsMatch(line))
                || NonReportableErrorCodes.Values.Any(line.Contains)
                ;
        }

        #endregion

        #region Progress background worker

        private void OnBeforeStart(object sender, EventArgs eventArgs)
        {
            _progressWorker.DoWork += ProgressWorkerOnDoWork;
            _progressWorker.RunWorkerCompleted += ProgressWorkerOnRunWorkerCompleted;
            _progressWorker.RunWorkerAsync();
        }

        private void ProgressWorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            using (var stream = CreateProgressFileStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    while (KeepParsingProgress)
                    {
                        ParseProgressLine(reader.ReadLine());
                    }
                }
            }
        }

        private FileStream CreateProgressFileStream()
        {
            return new FileStream(_progressFilePath,
                                  FileMode.Open,
                                  FileAccess.Read,
                                  FileShare.ReadWrite | FileShare.Delete);
        }

        private void ProgressWorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs args)
        {
            if (args.Error != null)
            {
                Logger.Error("Error occurred in _progressWorker.DoWork", args.Error);
                Exception = args.Error;
                Kill(true);
            }
        }

        #endregion

        #region Progress parsing

        private bool KeepParsingProgress
        {
            get
            {
                return State == NonInteractiveProcessState.Ready   ||
                       State == NonInteractiveProcessState.Running ||
                       State == NonInteractiveProcessState.Paused;
            }
        }

        private void ParseProgressLine(string line)
        {
            if (line == null)
            {
                if (State == NonInteractiveProcessState.Running && _progress < 98.0)
                    Thread.Sleep(ProgressParseInterval);
                return;
            }

            if (FrameRegex.IsMatch(line))
                CurFrame = GetLong(FrameRegex, line);
            else if (FpsRegex.IsMatch(line))
                CurFps = GetDouble(FpsRegex, line);
            else if (TotalSizeRegex.IsMatch(line))
                CurSize = GetLong(TotalSizeRegex, line);
            else if (OutTimeMsRegex.IsMatch(line))
                CurOutTimeMs = GetLong(OutTimeMsRegex, line) / 1000;

            _progress = 100 * (CurOutTimeMs / _playlistLength.TotalMilliseconds);
            _progress = Math.Min(_progress, 100);

            if ("progress=end" == line)
            {
                Logger.Info(line);

                if (_progress >= 99.9)
                {
                    var prevProgress = _progress;

                    _progress = 100;
                    CleanExit = true;

                    Logger.InfoFormat("{0:P} => {1:P}", prevProgress / 100.0, _progress / 100.0);
                }

                _sawProgressEnd = true;
                _cleanExitEvent.Set();
            }
        }

        private static long GetLong(Regex regex, string line)
        {
            return regex.Match(line).Groups[1].Value.ParseLongInvariant();
        }

        private static double GetDouble(Regex regex, string line)
        {
            return regex.Match(line).Groups[1].Value.ParseDoubleInvariant();
        }

        #endregion

        private bool _sawProgressEnd;

        protected override bool IsError
        {
            get { return base.IsError || _progress < 100.0; }
        }

        #region Exit handling

        protected override void BeforeProcessExited()
        {
            PickBestException();

            // ParseProgressLine() already parsed "progress=end" line
            if (_sawProgressEnd)
                return;

            // Give ParseProgressLine() time to read the final output written by the process
            _cleanExitEvent.Wait(ExitWaitTimeout);
        }

        // TODO: Clean this garbage up
        private void PickBestException()
        {
            var stdErr =
                new Stack<string>(
                    _stdErr.Where(message => !ErrorsToIgnoreIfComplete.Contains(message.Message))
                           .Select(message => message.Message));

            if (_progress == 100.0 ||
                Exception == null ||
                !ErrorsToIgnoreIfComplete.Any(Exception.Message.Contains) ||
                !stdErr.Any())
            {
                return;
            }

            try
            {
                throw new Exception(stdErr.Pop());
            }
            catch (Exception ex)
            {
                Exception = ex;
            }
        }

        private void OnExited(NonInteractiveProcessState processState, int exitCode, ReleaseMedium releaseMedium, Playlist playlist, string outputMKVPath)
        {
            LogExit(processState, exitCode);

            DeleteTempFilesAsync();

            if (processState != NonInteractiveProcessState.Completed)
                return;

            var mkvPropEdit = new MkvPropEdit(_jobObjectManager, _tempFileRegistrar) { SourceFilePath = outputMKVPath }
                .RemoveAllTags()
                .AddCoverArt(releaseMedium)
                .SetChapters(playlist.Chapters)
//                .SetDefaultTracksAuto(selectedTracks) // Breaks MediaInfo
            ;
            mkvPropEdit.Start();
        }

        private void DeleteTempFilesAsync()
        {
            // Wait about 2 seconds before deleting temp files to give the FFmpeg process a chance to finish reading
            // the input file list and exit.
            var timer = new Timer(2000) { AutoReset = false };
            timer.Elapsed += DeleteTempFiles;
            timer.Start();
        }

        private void DeleteTempFiles(object sender, ElapsedEventArgs args)
        {
            _tempFileRegistrar.DeleteTempFiles(_progressFilePath, _inputFileListPath, _reportDumpFilePath);
        }

        #endregion
    }
}
