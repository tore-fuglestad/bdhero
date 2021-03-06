﻿using System.ComponentModel;
using System.Windows.Forms;

namespace UILib.WinForms
{
    /// <summary>
    ///     Invoked whenever the hooked control's <see href="Control.WndProc"/> method is called.
    /// </summary>
    /// <param name="m">
    ///     Native window message.
    /// </param>
    /// <param name="args">
    ///     Event data.
    /// </param>
    public delegate void WndProcEventHandler(ref Message m, HandledEventArgs args);
}