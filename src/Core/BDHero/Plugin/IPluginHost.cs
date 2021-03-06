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

namespace BDHero.Plugin
{
    /// <summary>
    ///     Provides an interface for observers to be notified whenever a plugin updates its progress.
    /// </summary>
    public interface IPluginHost
    {
        /// <summary>
        ///     Allows plugins to report their progress to the host.
        /// </summary>
        /// <param name="plugin">Plugin that is reporting its progress</param>
        /// <param name="percentComplete">0.0 to 100.0</param>
        /// <param name="shortStatus">
        ///     Short description of what the plugin is currently doing
        ///     (e.g., "Parsing 00850.MPLS", "Muxing to MKV @ 00:45:19").
        /// </param>
        /// <param name="longStatus">
        ///     Detailed description of what the plugin is currently doing
        ///     (e.g., "Parsing 00850.MPLS", "Muxing to MKV @ 00:45:19").
        /// </param>
        void ReportProgress(IPlugin plugin, double percentComplete, string shortStatus, string longStatus = null);

        /// <summary>
        ///     Gets the <see href="ProgressProvider"/> for the specified <paramref name="plugin"/>.
        /// </summary>
        /// <param name="plugin">The plugin whose <see href="ProgressProvider"/> is required.</param>
        /// <returns>
        ///     The <see href="ProgressProvider"/> for <paramref name="plugin"/>.
        /// </returns>
        ProgressProvider GetProgressProvider(IPlugin plugin);
    }
}
