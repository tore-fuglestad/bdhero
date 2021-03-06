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
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using BDHero.JobQueue;
using DotNetUtils.Annotations;
using DotNetUtils.Extensions;
using DotNetUtils.FS;
using OSUtils.JobObjects;
using ProcessUtils;

namespace BDHero.Plugin.FFmpegMuxer
{
    public class FFmpegPlugin : IMuxerPlugin
    {
        private static readonly log4net.ILog Logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public IPluginHost Host { get; private set; }
        public PluginAssemblyInfo AssemblyInfo { get; private set; }

        public string Name { get { return "FFmpeg"; } }

        public bool Enabled { get; set; }

        public Icon Icon { get { return Resources.ffmpeg_icon; } }

        public int RunOrder { get { return 0; } }

        public PluginPropertiesHandler PropertiesHandler
        {
            get { return ShowPluginInfoForm; }
        }

        public MatroskaFeatures SupportedFeatures
        {
            get
            {
                return MatroskaFeatures.Chapters
                     | MatroskaFeatures.CoverArt
                     | MatroskaFeatures.LPCM
                    ;
            }
        }

        private readonly IJobObjectManager _jobObjectManager;
        private readonly ITempFileRegistrar _tempFileRegistrar;

        private readonly AutoResetEvent _mutex = new AutoResetEvent(false);

        private Exception _exception;

        [UsedImplicitly]
        public FFmpegPlugin(IJobObjectManager jobObjectManager, ITempFileRegistrar tempFileRegistrar)
        {
            _jobObjectManager = jobObjectManager;
            _tempFileRegistrar = tempFileRegistrar;
        }

        public void LoadPlugin(IPluginHost host, PluginAssemblyInfo assemblyInfo)
        {
            Host = host;
            AssemblyInfo = assemblyInfo;
        }

        public void UnloadPlugin()
        {
        }

        public void Mux(CancellationToken cancellationToken, Job job)
        {
            if (cancellationToken.IsCancellationRequested)
                return;

            const string startStatus = "Starting FFmpeg process...";

            Host.ReportProgress(this, 0.0, startStatus);
            Logger.Info(startStatus);

            _exception = null;

            var ffmpeg = new FFmpeg(job, job.SelectedPlaylist, job.OutputPath, _jobObjectManager, _tempFileRegistrar);
            ffmpeg.ProgressUpdated += state => OnProgressUpdated(ffmpeg, state, cancellationToken);
            ffmpeg.Exited += OnExited;
            ffmpeg.StartAsync();
            cancellationToken.Register(ffmpeg.Kill, true);
            WaitForThreadToExit();

            if (_exception == null)
                return;

            Log(job, ffmpeg);

            throw new FFmpegException(_exception.Message, _exception);
        }

        private DialogResult ShowPluginInfoForm(Form parent)
        {
            using (var form = new PluginInfoForm(_jobObjectManager))
            {
                return form.ShowDialog(parent);
            }
        }

        #region Logging

        private static void Log(Job job, FFmpeg ffmpeg)
        {
            Logger.InfoFormat("FFmpeg was invoked with: {0}", ffmpeg.FullCommand);
            job.Log();
            ffmpeg.Log();
        }

        #endregion

        private void OnProgressUpdated(FFmpeg ffmpeg, ProgressState progressState, CancellationToken cancellationToken)
        {
            var shortStatus = string.Format("Muxing {0} @ {2:F0} fps - {1}",
                TimeSpan.FromMilliseconds(ffmpeg.CurOutTimeMs).ToStringShort(),
                FileUtils.HumanFriendlyFileSize(ffmpeg.CurSize),
                ffmpeg.CurFps);

            var longStatus = string.Format("Muxing to MKV: {0} - {1} @ {2:N1} fps",
                TimeSpan.FromMilliseconds(ffmpeg.CurOutTimeMs).ToStringMedium(),
                FileUtils.HumanFriendlyFileSize(ffmpeg.CurSize),
                ffmpeg.CurFps);

            Host.ReportProgress(this, progressState.PercentComplete, shortStatus, longStatus);

            if (cancellationToken.IsCancellationRequested)
                ffmpeg.Kill();
        }

        private void OnExited(NonInteractiveProcessState state, int exitCode, Exception exception, TimeSpan runTime)
        {
            Logger.InfoFormat("FFmpeg exited with state {0} and code {1}", state, exitCode);

            _exception = _exception ?? exception;

            if (_exception == null && state != NonInteractiveProcessState.Completed)
            {
                try
                {
                    if (state == NonInteractiveProcessState.Killed)
                    {
                        throw new FFmpegException("FFmpeg was canceled", new OperationCanceledException())
                              {
                                  IsReportable = false
                              };
                    }
                    throw new FFmpegException(string.Format("FFmpeg exited with state: {0}", state))
                          {
                              IsReportable = true
                          };
                }
                catch (FFmpegException e)
                {
                    _exception = e;
                }
            }

            SignalThreadExited();
        }

        private void WaitForThreadToExit()
        {
            _mutex.WaitOne();
        }

        private void SignalThreadExited()
        {
            _mutex.Set();
        }
    }
}
