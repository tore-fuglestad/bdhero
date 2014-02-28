﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextEditor
{
    public interface ITextEditorOptions
    {
        #region Font

        /// <summary>
        ///     Base font size.
        /// </summary>
        double FontSize { get; set; }

        #endregion

        #region Scrollbars

        bool Multiline { get; set; }

        #endregion

        #region Line numbers

        bool ShowLineNumbers { get; set; }

        #endregion

        #region Column ruler

        bool ShowColumnRuler { get; set; }

        int ColumnRulerPosition { get; set; }

        bool CutCopyWholeLine { get; set; }

        #endregion

        #region Indentation

        int IndentationSize { get; set; }

        bool ConvertTabsToSpaces { get; set; }

        #endregion

        #region Character visualization

        bool ShowSpaces { get; set; }

        bool ShowTabs { get; set; }

        #endregion
    }
}
