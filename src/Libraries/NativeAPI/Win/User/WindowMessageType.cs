﻿// Copyright 2014 Andrew C. Dvorak
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

// ReSharper disable InconsistentNaming
// ReSharper disable MemberCanBePrivate.Global
namespace NativeAPI.Win.User
{
    /// <summary>
    ///     Window message type enum.
    /// </summary>
    /// <seealso href="http://wiki.winehq.org/List_Of_Windows_Messages"/>
    public enum WindowMessageType : uint
    {
        /// <summary>
        ///     <para>
        ///         Performs no operation. An application sends the <c>WM_NULL</c> message if it wants to post a message
        ///         that the recipient window will ignore.
        ///     </para>
        ///     <para>
        ///         A window receives this message through its <c>WindowProc</c> function.
        ///     </para>
        /// </summary>
        /// <param name="wParam">
        ///     This parameter is not used.
        /// </param>
        /// <param name="lParam">
        ///     This parameter is not used.
        /// </param>
        /// <returns>
        ///     Type: LRESULT.
        ///     An application returns zero if it processes this message.
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         For example, if an application has installed a <c>WH_GETMESSAGE</c> hook and wants to prevent a
        ///         message from being processed, the <c>GetMsgProc</c> callback function can change the message number to
        ///         <c>WM_NULL</c> so the recipient will ignore it.
        ///     </para>
        ///     <para>
        ///         As another example, an application can check if a window is responding to messages by sending the
        ///         <c>WM_NULL</c> message with the <c>SendMessageTimeout</c> function.
        ///     </para>
        /// </remarks>
        WM_NULL = 0x0000,

        /// <summary>
        ///     Sent to both the window being activated and the window being deactivated.
        ///     If the windows use the same input queue, the message is sent synchronously, first to the window
        ///     procedure of the top-level window being deactivated, then to the window procedure of the top-level
        ///     window being activated. If the windows use different input queues, the message is sent asynchronously,
        ///     so the window is activated immediately.
        /// </summary>
        /// <param name="wParam">
        ///     The low-order word specifies whether the window is being activated or deactivated.
        ///     This parameter can be one of the <see href="WindowActivate"/> values. The high-order word specifies
        ///     the minimized state of the window being activated or deactivated.
        ///     A nonzero value indicates the window is minimized.
        /// </param>
        /// <param name="lParam">
        ///     A handle to the window being activated or deactivated, depending on the value of the <paramref name="wParam"/> parameter.
        ///     If the low-order word of wParam is <see href="WindowActivate.WA_INACTIVE"/>,
        ///     <c>lParam</c> is the handle to the window being activated.
        ///     If the low-order word of wParam is <see href="WindowActivate.WA_ACTIVE"/> or <see href="WindowActivate.WA_CLICKACTIVE"/>,
        ///     <c>lParam</c> is the handle to the window being deactivated.
        ///     This handle can be <c>null</c>.
        /// </param>
        /// <returns>
        ///     If an application processes this message, it should return zero.
        /// </returns>
        /// <remarks>
        ///     If the window is being activated and is not minimized, the <c>DefWindowProc</c> function sets the
        ///     keyboard focus to the window. If the window is activated by a mouse click, it also receives a
        ///     <see href="WM_MOUSEACTIVATE"/> message.
        /// </remarks>
        WM_ACTIVATE = 0x0006,

        /// <summary>
        ///     Sent to a window after it has gained the keyboard focus.
        /// </summary>
        /// <param name="wParam">
        ///     A handle to the window that has lost the keyboard focus. This parameter can be <c>null</c>.
        /// </param>
        /// <param name="lParam">
        ///     This parameter is not used.
        /// </param>
        /// <returns>
        ///     An application should return zero if it processes this message.
        /// </returns>
        /// <remarks>
        ///     To display a caret, an application should call the appropriate caret functions when it receives the <c>WM_SETFOCUS</c> message.
        /// </remarks>
        WM_SETFOCUS = 0x0007,

        /// <summary>
        ///     Sent to a window immediately before it loses the keyboard focus.
        /// </summary>
        /// <param name="wParam">
        ///     A handle to the window that receives the keyboard focus. This parameter can be NULL.
        /// </param>
        /// <param name="lParam">
        ///     This parameter is not used.
        /// </param>
        /// <returns>
        ///     An application should return zero if it processes this message.
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         If an application is displaying a caret, the caret should be destroyed at this point.
        ///     </para>
        ///     <para>
        ///         While processing this message, do not make any function calls that display or activate a window.
        ///         This causes the thread to yield control and can cause the application to stop responding to messages.
        ///         For more information, see Message Deadlocks.
        ///     </para>
        /// </remarks>
        WM_KILLFOCUS = 0x0008,

        /// <summary>
        ///     An application sends the <c>WM_SETREDRAW</c> message to a window to allow changes in that window to be
        ///     redrawn or to prevent changes in that window from being redrawn.
        /// </summary>
        /// <param name="wParam">
        ///     The redraw state. If this parameter is <c>true</c>, the content can be redrawn after a change.
        ///     If this parameter is <c>false</c>, the content cannot be redrawn after a change.
        /// </param>
        /// <param name="lParam">
        ///     This parameter is not used.
        /// </param>
        /// <returns>
        ///     An application returns zero if it processes this message.
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         This message can be useful if an application must add several items to a list box.
        ///         The application can call this message with <c>wParam</c> set to <c>false</c>, add the items, and then call the
        ///         message again with <c>wParam</c> set to <c>true</c>. Finally, the application can call
        ///         <c>RedrawWindow(hWnd, NULL, NULL, RDW_ERASE | RDW_FRAME | RDW_INVALIDATE | RDW_ALLCHILDREN)</c>
        ///         to cause the list box to be repainted.
        ///     </para>
        ///     <para>
        ///         Note: <c>RedrawWindow</c> with the specified flags is used instead of <c>InvalidateRect</c> because the former
        ///         is necessary for some controls that have nonclient area on their own, or have window styles that
        ///         cause them to be given a nonclient area (such as <see href="WindowStyles.WS_THICKFRAME"/>,
        ///         <see href="WindowStyles.WS_BORDER"/>, or <see href="ExtendedWindowStyles.WS_EX_CLIENTEDGE"/>).
        ///         If the control does not have a nonclient area, <c>RedrawWindow</c> with these flags will do only as much
        ///         invalidation as <c>InvalidateRect</c> would.
        ///     </para>
        ///     <para>
        ///         If the application sends the <c>WM_SETREDRAW</c> message to a hidden window, the window becomes visible
        ///         (that is, the operating system adds the <see href="WindowStyles.WS_VISIBLE"/> style to the window).
        ///     </para>
        /// </remarks>
        WM_SETREDRAW = 0x000b,

        /// <summary>
        ///     Sent to a window if the mouse causes the cursor to move within a window and mouse input is not captured.
        /// </summary>
        /// <param name="wParam">
        ///     A handle to the window that contains the cursor.
        /// </param>
        /// <param name="lParam">
        ///     The low-order word of <c>lParam</c> specifies the hit-test code.
        ///     The high-order word of <c>lParam</c> specifies the identifier of the mouse message.
        /// </param>
        /// <returns>
        ///     If an application processes this message, it should return <c>TRUE</c> to halt further processing or <c>FALSE</c> to continue.
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         The high-order word of <paramref name="lParam"/> is zero when the window enters menu mode.
        ///     </para>
        ///     <para>
        ///         The <c>DefWindowProc</c> function passes the <see href="WM_SETCURSOR"/> message to a parent window before processing.
        ///         If the parent window returns <c>TRUE</c>, further processing is halted. Passing the message to a window's
        ///         parent window gives the parent window control over the cursor's setting in a child window.
        ///         The <c>DefWindowProc</c> function also uses this message to set the cursor to an arrow if it is not in
        ///         the client area, or to the registered class cursor if it is in the client area. If the low-order
        ///         word of the <paramref name="lParam"/> parameter is <c>HTERROR</c> and the high-order word of
        ///         <paramref name="lParam"/> specifies that one of the mouse buttons is pressed, <c>DefWindowProc</c> calls
        ///         the <c>MessageBeep</c> function.
        ///     </para>
        /// </remarks>
        WM_SETCURSOR = 0x0020,

        /// <summary>
        ///     <para>
        ///         Sent when the cursor is in an inactive window and the user presses a mouse button.
        ///         The parent window receives this message only if the child window passes it to the <c>DefWindowProc</c> function.
        ///     </para>
        ///     <para>
        ///         A window receives this message through its <c>WindowProc</c> function.
        ///     </para>
        /// </summary>
        /// <param name="wParam">
        ///     A handle to the top-level parent window of the window being activated.
        /// </param>
        /// <param name="lParam">
        ///     <para>
        ///         The low-order word specifies the hit-test value returned by the <c>DefWindowProc</c> function
        ///         as a result of processing the <see href="WM_NCHITTEST"/> message.
        ///         For a list of hit-test values, see <see href="WM_NCHITTEST"/>.
        ///     </para>
        ///     <para>
        ///         The high-order word specifies the identifier of the mouse message generated when the user pressed
        ///         a mouse button. The mouse message is either discarded or posted to the window, depending on the return value.
        ///     </para>
        /// </param>
        /// <returns>
        ///     The return value specifies whether the window should be activated and whether the identifier of the
        ///     mouse message should be discarded. It must be one of the <see href="MouseActivate"/> values.
        /// </returns>
        /// <remarks>
        ///     The <c>DefWindowProc</c> function passes the message to a child window's parent window before
        ///     any processing occurs. The parent window determines whether to activate the child window.
        ///     If it activates the child window, the parent window should return <see href="MouseActivate.MA_NOACTIVATE"/> or
        ///     <see href="MouseActivate.MA_NOACTIVATEANDEAT"/> to prevent the system from processing the message further.
        /// </remarks>
        WM_MOUSEACTIVATE = 0x0021,

        /// <summary>
        ///     Sent to the window procedure associated with a control. By default, the system handles all
        ///     keyboard input to the control; the system interprets certain types of keyboard input as dialog box
        ///     navigation keys. To override this default behavior, the control can respond to the <c>WM_GETDLGCODE</c> message
        ///     to indicate the types of input it wants to process itself.
        /// </summary>
        /// <param name="wParam">
        ///     The virtual key, pressed by the user, that prompted Windows to issue this notification.
        ///     The handler must selectively handle these keys. For instance, the handler might accept and process
        ///     <see href="VirtualKey.VK_RETURN"/> but delegate <see href="VirtualKey.VK_TAB"/> to the owner window.
        ///     For a list of values, see <see href="VirtualKey"/>.
        /// </param>
        /// <param name="lParam">
        ///     A pointer to a <see href="System.Windows.Forms.Message"/> structure (or <c>null</c> if the system is performing a query).
        /// </param>
        /// <returns>
        ///     The return value is one or more of the <see href="DialogCode"/> values, indicating which type of input the application processes.
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         Although the <c>DefWindowProc</c> function always returns zero in response to the <c>WM_GETDLGCODE</c> message,
        ///         the window procedure for the predefined control classes return a code appropriate for each class.
        ///     </para>
        ///     <para>
        ///         The <c>WM_GETDLGCODE</c> message and the returned values are useful only with user-defined
        ///         dialog box controls or standard controls modified by subclassing.
        ///     </para>
        /// </remarks>
        WM_GETDLGCODE = 0x0087,

        /// <summary>
        ///     Posted to the window with the keyboard focus when a nonsystem key is pressed.
        ///     A nonsystem key is a key that is pressed when the ALT key is not pressed.
        /// </summary>
        /// <param name="wParam">
        ///     The virtual-key code of the nonsystem key. See <see href="VirtualKey"/>.
        /// </param>
        /// <param name="lParam">
        ///     <para>
        ///         The repeat count, scan code, extended-key flag, context code, previous key-state flag,
        ///         and transition-state flag, as shown following.
        ///     </para>
        ///     <code>
        /// Bits   Meaning
        /// ------ -------
        ///  0-15  The repeat count for the current message. The value is the number of times the keystroke is autorepeated as a result of the user holding down the key. If the keystroke is held long enough, multiple messages are sent. However, the repeat count is not cumulative.
        /// 16-23  The scan code. The value depends on the OEM.
        /// 24     Indicates whether the key is an extended key, such as the right-hand ALT and CTRL keys that appear on an enhanced 101- or 102-key keyboard. The value is 1 if it is an extended key; otherwise, it is 0.
        /// 25-28  Reserved; do not use.
        /// 29     The context code. The value is always 0 for a WM_KEYDOWN message.
        /// 30     The previous key state. The value is 1 if the key is down before the message is sent, or it is zero if the key is up.
        /// 31     The transition state. The value is always 0 for a WM_KEYDOWN message.
        ///     </code>
        /// </param>
        /// <returns>
        ///     An application should return zero if it processes this message.
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         If the <c>F10</c> key is pressed, the <c>DefWindowProc</c> function sets an internal flag.
        ///         When <c>DefWindowProc</c> receives the <see href="WM_KEYUP"/> message, the function checks whether the internal flag
        ///         is set and, if so, sends a <see href="WM_SYSCOMMAND"/> message to the top-level window.
        ///         The <see href="WM_SYSCOMMAND"/> parameter of the message is set to <c>SC_KEYMENU</c>.
        ///     </para>
        ///     <para>
        ///         Because of the autorepeat feature, more than one <see href="WM_KEYDOWN"/> message may be posted
        ///         before a <see href="WM_KEYUP"/> message is posted. The previous key state (bit 30) can be used to determine
        ///         whether the <see href="WM_KEYDOWN"/> message indicates the first down transition or a repeated down transition.
        ///     </para>
        ///     <para>
        ///         For enhanced 101- and 102-key keyboards, extended keys are the right <c>ALT</c> and <c>CTRL</c> keys
        ///         on the main section of the keyboard; the <c>INS</c>, <c>DEL</c>, <c>HOME</c>, <c>END</c>, <c>PAGE UP</c>, <c>PAGE DOWN</c>, and
        ///         arrow keys in the clusters to the left of the numeric keypad; and the divide (<c>/</c>) and <c>ENTER</c> keys
        ///         in the numeric keypad. Other keyboards may support the extended-key bit in the <c>lParam</c> parameter.
        ///     </para>
        ///     <para>
        ///         Applications must pass <c>wParam</c> to <c>TranslateMessage</c> without altering it at all.
        ///     </para>
        /// </remarks>
        WM_KEYDOWN = 0x0100,

        /// <summary>
        ///     A window receives this message when the user chooses a command from the Window menu (formerly known
        ///     as the system or control menu) or when the user chooses the maximize button, minimize button,
        ///     restore button, or close button.
        /// </summary>
        /// <seealso href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms646360(v=vs.85).aspx"/>
        WM_SYSCOMMAND = 0x0112,

        /// <summary>
        ///     <para>
        ///         Sent to the focus window when the mouse wheel is rotated. The <c>DefWindowProc</c> function propagates
        ///         the message to the window's parent. There should be no internal forwarding of the message, since
        ///         <c>DefWindowProc</c> propagates it up the parent chain until it finds a window that processes it.
        ///     </para>
        ///     <para>
        ///         A window receives this message through its <c>WindowProc</c> function.
        ///     </para>
        /// </summary>
        /// <param name="wParam">
        ///     <para>
        ///         The high-order word indicates the distance the wheel is rotated, expressed in multiples or
        ///         divisions of <c>WHEEL_DELTA</c>, which is <c>120</c>. A positive value indicates that the wheel was rotated
        ///         forward, away from the user; a negative value indicates that the wheel was rotated backward, toward the user.
        ///     </para>
        ///     <para>
        ///         The low-order word indicates whether various virtual keys are down. This parameter can be one or more of the following values.
        ///     </para>
        /// </param>
        /// <param name="lParam">
        ///     <para>
        ///         The low-order word specifies the x-coordinate of the pointer, relative to the upper-left corner of the screen.
        ///     </para>
        ///     <para>
        ///         The high-order word specifies the y-coordinate of the pointer, relative to the upper-left corner of the screen.
        ///     </para>
        /// </param>
        /// <returns>
        ///     If an application processes this message, it should return zero.
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         Use the following code to get the information in the <c>wParam</c> parameter:
        ///     </para>
        ///     <code>
        ///         fwKeys = GET_KEYSTATE_WPARAM(wParam);
        ///         zDelta = GET_WHEEL_DELTA_WPARAM(wParam);
        ///     </code>
        ///     <para>
        ///         Use the following code to obtain the horizontal and vertical position:
        ///     </para>
        ///     <code>
        ///         xPos = GET_X_LPARAM(lParam); 
        ///         yPos = GET_Y_LPARAM(lParam); 
        ///     </code>
        ///     <para>
        ///         As noted above, the x-coordinate is in the low-order short of the return value; the y-coordinate
        ///         is in the high-order short (both represent signed values because they can take negative values
        ///         on systems with multiple monitors).
        ///     </para>
        ///     <para>
        ///         The wheel rotation will be a multiple of <c>WHEEL_DELTA</c>, which is set at <c>120</c>.
        ///         This is the threshold for action to be taken, and one such action (for example, scrolling one increment)
        ///         should occur for each delta.
        ///     </para>
        ///     <para>
        ///         The delta was set to 120 to allow Microsoft or other vendors to build finer-resolution wheels
        ///         (a freely-rotating wheel with no notches) to send more messages per rotation, but with a smaller value
        ///         in each message. To use this feature, you can either add the incoming delta values until 
        ///         <c>WHEEL_DELTA</c> is reached (so for a delta-rotation you get the same response), or scroll partial
        ///         lines in response to the more frequent messages. You can also choose your scroll granularity
        ///         and accumulate deltas until it is reached.
        ///     </para>
        ///     <para>
        ///         Note, there is no <c>fwKeys</c> for <c>MSH_MOUSEWHEEL</c>. Otherwise, the parameters are exactly the same
        ///         as for <c>WM_MOUSEWHEEL</c>.
        ///     </para>
        ///     <para>
        ///         It is up to the application to forward <c>MSH_MOUSEWHEEL</c> to any embedded objects or controls.
        ///         The application is required to send the message to an active embedded OLE application.
        ///         It is optional that the application sends it to a wheel-enabled control with focus.
        ///         If the application does send the message to a control, it can check the return value to see
        ///         if the message was processed. Controls are required to return a value of TRUE if they process the message.
        ///     </para>
        /// </remarks>
        WM_MOUSEWHEEL = 0x020a,

        /// <summary>
        ///     <para>
        ///         Sent to the window that is losing the mouse capture.
        ///     </para>
        ///     <para>
        ///         A window receives this message through its <c>WindowProc</c> function.
        ///     </para>
        /// </summary>
        /// <param name="wParam">
        ///     This parameter is not used.
        /// </param>
        /// <param name="lParam">
        ///     A handle to the window gaining the mouse capture.
        /// </param>
        /// <returns>
        ///     An application should return zero if it processes this message.
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         A window receives this message even if it calls <c>ReleaseCapture</c> itself.
        ///         An application should not attempt to set the mouse capture in response to this message.
        ///     </para>
        ///     <para>
        ///         When it receives this message, a window should redraw itself, if necessary, to reflect the new
        ///         mouse-capture state.
        ///     </para>
        /// </remarks>
        WM_CAPTURECHANGED = 0x0215,

        /// <summary>
        ///     Notifies an application of a change to the hardware configuration of a device or the computer.
        /// </summary>
        WM_DEVICECHANGE = 0x0219,

        WM_CREATE = 0x0001,
        WM_DESTROY = 0x0002,
        WM_MOVE = 0x0003,
        WM_SIZE = 0x0005,
        WM_ENABLE = 0x000a,
        WM_SETTEXT = 0x000c,
        WM_GETTEXT = 0x000d,
        WM_GETTEXTLENGTH = 0x000e,
        WM_PAINT = 0x000f,
        WM_CLOSE = 0x0010,
        WM_QUERYENDSESSION = 0x0011,
        WM_QUIT = 0x0012,
        WM_QUERYOPEN = 0x0013,
        WM_ERASEBKGND = 0x0014,
        WM_SYSCOLORCHANGE = 0x0015,
        WM_ENDSESSION = 0x0016,
        WM_SHOWWINDOW = 0x0018,
        WM_CTLCOLOR = 0x0019,
        WM_WININICHANGE = 0x001a,
        WM_DEVMODECHANGE = 0x001b,
        WM_ACTIVATEAPP = 0x001c,
        WM_FONTCHANGE = 0x001d,
        WM_TIMECHANGE = 0x001e,
        WM_CANCELMODE = 0x001f,
        WM_CHILDACTIVATE = 0x0022,
        WM_QUEUESYNC = 0x0023,
        WM_GETMINMAXINFO = 0x0024,
        WM_PAINTICON = 0x0026,
        WM_ICONERASEBKGND = 0x0027,
        WM_NEXTDLGCTL = 0x0028,
        WM_SPOOLERSTATUS = 0x002a,
        WM_DRAWITEM = 0x002b,
        WM_MEASUREITEM = 0x002c,
        WM_DELETEITEM = 0x002d,
        WM_VKEYTOITEM = 0x002e,
        WM_CHARTOITEM = 0x002f,
        WM_SETFONT = 0x0030,
        WM_GETFONT = 0x0031,
        WM_SETHOTKEY = 0x0032,
        WM_GETHOTKEY = 0x0033,
        WM_QUERYDRAGICON = 0x0037,
        WM_COMPAREITEM = 0x0039,
        WM_GETOBJECT = 0x003d,
        WM_COMPACTING = 0x0041,
        WM_COMMNOTIFY = 0x0044,
        WM_WINDOWPOSCHANGING = 0x0046,
        WM_WINDOWPOSCHANGED = 0x0047,
        WM_POWER = 0x0048,
        WM_COPYGLOBALDATA = 0x0049,
        WM_COPYDATA = 0x004a,
        WM_CANCELJOURNAL = 0x004b,
        WM_NOTIFY = 0x004e,
        WM_INPUTLANGCHANGEREQUEST = 0x0050,
        WM_INPUTLANGCHANGE = 0x0051,
        WM_TCARD = 0x0052,
        WM_HELP = 0x0053,
        WM_USERCHANGED = 0x0054,
        WM_NOTIFYFORMAT = 0x0055,
        WM_CONTEXTMENU = 0x007b,
        WM_STYLECHANGING = 0x007c,
        WM_STYLECHANGED = 0x007d,
        WM_DISPLAYCHANGE = 0x007e,
        WM_GETICON = 0x007f,
        WM_SETICON = 0x0080,
        WM_NCCREATE = 0x0081,
        WM_NCDESTROY = 0x0082,
        WM_NCCALCSIZE = 0x0083,
        WM_NCHITTEST = 0x0084,
        WM_NCPAINT = 0x0085,
        WM_NCACTIVATE = 0x0086,
        WM_SYNCPAINT = 0x0088,
        WM_NCMOUSEMOVE = 0x00a0,
        WM_NCLBUTTONDOWN = 0x00a1,
        WM_NCLBUTTONUP = 0x00a2,
        WM_NCLBUTTONDBLCLK = 0x00a3,
        WM_NCRBUTTONDOWN = 0x00a4,
        WM_NCRBUTTONUP = 0x00a5,
        WM_NCRBUTTONDBLCLK = 0x00a6,
        WM_NCMBUTTONDOWN = 0x00a7,
        WM_NCMBUTTONUP = 0x00a8,
        WM_NCMBUTTONDBLCLK = 0x00a9,
        WM_NCXBUTTONDOWN = 0x00ab,
        WM_NCXBUTTONUP = 0x00ac,
        WM_NCXBUTTONDBLCLK = 0x00ad,
        SBM_SETPOS = 0x00e0,
        SBM_GETPOS = 0x00e1,
        SBM_SETRANGE = 0x00e2,
        SBM_GETRANGE = 0x00e3,
        SBM_ENABLE_ARROWS = 0x00e4,
        SBM_SETRANGEREDRAW = 0x00e6,
        SBM_SETSCROLLINFO = 0x00e9,
        SBM_GETSCROLLINFO = 0x00ea,
        SBM_GETSCROLLBARINFO = 0x00eb,
        WM_INPUT = 0x00ff,
        WM_KEYFIRST = 0x0100,
        WM_KEYUP = 0x0101,
        WM_CHAR = 0x0102,
        WM_DEADCHAR = 0x0103,
        WM_SYSKEYDOWN = 0x0104,
        WM_SYSKEYUP = 0x0105,
        WM_SYSCHAR = 0x0106,
        WM_SYSDEADCHAR = 0x0107,
        WM_KEYLAST = 0x0108,
        WM_WNT_CONVERTREQUESTEX = 0x0109,
        WM_CONVERTREQUEST = 0x010a,
        WM_CONVERTRESULT = 0x010b,
        WM_INTERIM = 0x010c,
        WM_IME_STARTCOMPOSITION = 0x010d,
        WM_IME_ENDCOMPOSITION = 0x010e,
        WM_IME_COMPOSITION = 0x010f,
        WM_IME_KEYLAST = 0x010f,
        WM_INITDIALOG = 0x0110,
        WM_COMMAND = 0x0111,
        WM_TIMER = 0x0113,
        WM_HSCROLL = 0x0114,
        WM_VSCROLL = 0x0115,
        WM_INITMENU = 0x0116,
        WM_INITMENUPOPUP = 0x0117,
        WM_SYSTIMER = 0x0118,
        WM_MENUSELECT = 0x011f,
        WM_MENUCHAR = 0x0120,
        WM_ENTERIDLE = 0x0121,
        WM_MENURBUTTONUP = 0x0122,
        WM_MENUDRAG = 0x0123,
        WM_MENUGETOBJECT = 0x0124,
        WM_UNINITMENUPOPUP = 0x0125,
        WM_MENUCOMMAND = 0x0126,
        WM_CHANGEUISTATE = 0x0127,
        WM_UPDATEUISTATE = 0x0128,
        WM_QUERYUISTATE = 0x0129,
        WM_CTLCOLORMSGBOX = 0x0132,
        WM_CTLCOLOREDIT = 0x0133,
        WM_CTLCOLORLISTBOX = 0x0134,
        WM_CTLCOLORBTN = 0x0135,
        WM_CTLCOLORDLG = 0x0136,
        WM_CTLCOLORSCROLLBAR = 0x0137,
        WM_CTLCOLORSTATIC = 0x0138,
        WM_MOUSEFIRST = 0x0200,
        WM_MOUSEMOVE = 0x0200,
        WM_LBUTTONDOWN = 0x0201,
        WM_LBUTTONUP = 0x0202,
        WM_LBUTTONDBLCLK = 0x0203,
        WM_RBUTTONDOWN = 0x0204,
        WM_RBUTTONUP = 0x0205,
        WM_RBUTTONDBLCLK = 0x0206,
        WM_MBUTTONDOWN = 0x0207,
        WM_MBUTTONUP = 0x0208,
        WM_MBUTTONDBLCLK = 0x0209,
        WM_MOUSELAST = 0x0209,
        WM_XBUTTONDOWN = 0x020b,
        WM_XBUTTONUP = 0x020c,
        WM_XBUTTONDBLCLK = 0x020d,
        WM_PARENTNOTIFY = 0x0210,
        WM_ENTERMENULOOP = 0x0211,
        WM_EXITMENULOOP = 0x0212,
        WM_NEXTMENU = 0x0213,
        WM_SIZING = 0x0214,
        WM_MOVING = 0x0216,
        WM_POWERBROADCAST = 0x0218,
        WM_MDICREATE = 0x0220,
        WM_MDIDESTROY = 0x0221,
        WM_MDIACTIVATE = 0x0222,
        WM_MDIRESTORE = 0x0223,
        WM_MDINEXT = 0x0224,
        WM_MDIMAXIMIZE = 0x0225,
        WM_MDITILE = 0x0226,
        WM_MDICASCADE = 0x0227,
        WM_MDIICONARRANGE = 0x0228,
        WM_MDIGETACTIVE = 0x0229,
        WM_MDISETMENU = 0x0230,
        WM_ENTERSIZEMOVE = 0x0231,
        WM_EXITSIZEMOVE = 0x0232,
        WM_DROPFILES = 0x0233,
        WM_MDIREFRESHMENU = 0x0234,
        WM_IME_REPORT = 0x0280,
        WM_IME_SETCONTEXT = 0x0281,
        WM_IME_NOTIFY = 0x0282,
        WM_IME_CONTROL = 0x0283,
        WM_IME_COMPOSITIONFULL = 0x0284,
        WM_IME_SELECT = 0x0285,
        WM_IME_CHAR = 0x0286,
        WM_IME_REQUEST = 0x0288,
        WM_IMEKEYDOWN = 0x0290,
        WM_IME_KEYDOWN = 0x0290,
        WM_IMEKEYUP = 0x0291,
        WM_IME_KEYUP = 0x0291,
        WM_NCMOUSEHOVER = 0x02a0,
        WM_MOUSEHOVER = 0x02a1,
        WM_NCMOUSELEAVE = 0x02a2,
        WM_MOUSELEAVE = 0x02a3,
        WM_CUT = 0x0300,
        WM_COPY = 0x0301,
        WM_PASTE = 0x0302,
        WM_CLEAR = 0x0303,
        WM_UNDO = 0x0304,
        WM_RENDERFORMAT = 0x0305,
        WM_RENDERALLFORMATS = 0x0306,
        WM_DESTROYCLIPBOARD = 0x0307,
        WM_DRAWCLIPBOARD = 0x0308,
        WM_PAINTCLIPBOARD = 0x0309,
        WM_VSCROLLCLIPBOARD = 0x030a,
        WM_SIZECLIPBOARD = 0x030b,
        WM_ASKCBFORMATNAME = 0x030c,
        WM_CHANGECBCHAIN = 0x030d,
        WM_HSCROLLCLIPBOARD = 0x030e,
        WM_QUERYNEWPALETTE = 0x030f,
        WM_PALETTEISCHANGING = 0x0310,
        WM_PALETTECHANGED = 0x0311,
        WM_HOTKEY = 0x0312,
        WM_PRINT = 0x0317,
        WM_PRINTCLIENT = 0x0318,
        WM_APPCOMMAND = 0x0319,
        WM_HANDHELDFIRST = 0x0358,
        WM_HANDHELDLAST = 0x035f,
        WM_AFXFIRST = 0x0360,
        WM_AFXLAST = 0x037f,
        WM_PENWINFIRST = 0x0380,
        WM_RCRESULT = 0x0381,
        WM_HOOKRCRESULT = 0x0382,
        WM_GLOBALRCCHANGE = 0x0383,
        WM_PENMISCINFO = 0x0383,
        WM_SKB = 0x0384,
        WM_HEDITCTL = 0x0385,
        WM_PENCTL = 0x0385,
        WM_PENMISC = 0x0386,
        WM_CTLINIT = 0x0387,
        WM_PENEVENT = 0x0388,
        WM_PENWINLAST = 0x038f,
        DDM_SETFMT = 0x0400,
        DM_GETDEFID = 0x0400,
        NIN_SELECT = 0x0400,
        TBM_GETPOS = 0x0400,
        WM_PSD_PAGESETUPDLG = 0x0400,
        WM_USER = 0x0400,
        CBEM_INSERTITEMA = 0x0401,
        DDM_DRAW = 0x0401,
        DM_SETDEFID = 0x0401,
        HKM_SETHOTKEY = 0x0401,
        PBM_SETRANGE = 0x0401,
        RB_INSERTBANDA = 0x0401,
        SB_SETTEXTA = 0x0401,
        TB_ENABLEBUTTON = 0x0401,
        TBM_GETRANGEMIN = 0x0401,
        TTM_ACTIVATE = 0x0401,
        WM_CHOOSEFONT_GETLOGFONT = 0x0401,
        WM_PSD_FULLPAGERECT = 0x0401,
        CBEM_SETIMAGELIST = 0x0402,
        DDM_CLOSE = 0x0402,
        DM_REPOSITION = 0x0402,
        HKM_GETHOTKEY = 0x0402,
        PBM_SETPOS = 0x0402,
        RB_DELETEBAND = 0x0402,
        SB_GETTEXTA = 0x0402,
        TB_CHECKBUTTON = 0x0402,
        TBM_GETRANGEMAX = 0x0402,
        WM_PSD_MINMARGINRECT = 0x0402,
        CBEM_GETIMAGELIST = 0x0403,
        DDM_BEGIN = 0x0403,
        HKM_SETRULES = 0x0403,
        PBM_DELTAPOS = 0x0403,
        RB_GETBARINFO = 0x0403,
        SB_GETTEXTLENGTHA = 0x0403,
        TBM_GETTIC = 0x0403,
        TB_PRESSBUTTON = 0x0403,
        TTM_SETDELAYTIME = 0x0403,
        WM_PSD_MARGINRECT = 0x0403,
        CBEM_GETITEMA = 0x0404,
        DDM_END = 0x0404,
        PBM_SETSTEP = 0x0404,
        RB_SETBARINFO = 0x0404,
        SB_SETPARTS = 0x0404,
        TB_HIDEBUTTON = 0x0404,
        TBM_SETTIC = 0x0404,
        TTM_ADDTOOLA = 0x0404,
        WM_PSD_GREEKTEXTRECT = 0x0404,
        CBEM_SETITEMA = 0x0405,
        PBM_STEPIT = 0x0405,
        TB_INDETERMINATE = 0x0405,
        TBM_SETPOS = 0x0405,
        TTM_DELTOOLA = 0x0405,
        WM_PSD_ENVSTAMPRECT = 0x0405,
        CBEM_GETCOMBOCONTROL = 0x0406,
        PBM_SETRANGE32 = 0x0406,
        RB_SETBANDINFOA = 0x0406,
        SB_GETPARTS = 0x0406,
        TB_MARKBUTTON = 0x0406,
        TBM_SETRANGE = 0x0406,
        TTM_NEWTOOLRECTA = 0x0406,
        WM_PSD_YAFULLPAGERECT = 0x0406,
        CBEM_GETEDITCONTROL = 0x0407,
        PBM_GETRANGE = 0x0407,
        RB_SETPARENT = 0x0407,
        SB_GETBORDERS = 0x0407,
        TBM_SETRANGEMIN = 0x0407,
        TTM_RELAYEVENT = 0x0407,
        CBEM_SETEXSTYLE = 0x0408,
        PBM_GETPOS = 0x0408,
        RB_HITTEST = 0x0408,
        SB_SETMINHEIGHT = 0x0408,
        TBM_SETRANGEMAX = 0x0408,
        TTM_GETTOOLINFOA = 0x0408,
        CBEM_GETEXSTYLE = 0x0409,
        CBEM_GETEXTENDEDSTYLE = 0x0409,
        PBM_SETBARCOLOR = 0x0409,
        RB_GETRECT = 0x0409,
        SB_SIMPLE = 0x0409,
        TB_ISBUTTONENABLED = 0x0409,
        TBM_CLEARTICS = 0x0409,
        TTM_SETTOOLINFOA = 0x0409,
        CBEM_HASEDITCHANGED = 0x040a,
        RB_INSERTBANDW = 0x040a,
        SB_GETRECT = 0x040a,
        TB_ISBUTTONCHECKED = 0x040a,
        TBM_SETSEL = 0x040a,
        TTM_HITTESTA = 0x040a,
        WIZ_QUERYNUMPAGES = 0x040a,
        CBEM_INSERTITEMW = 0x040b,
        RB_SETBANDINFOW = 0x040b,
        SB_SETTEXTW = 0x040b,
        TB_ISBUTTONPRESSED = 0x040b,
        TBM_SETSELSTART = 0x040b,
        TTM_GETTEXTA = 0x040b,
        WIZ_NEXT = 0x040b,
        CBEM_SETITEMW = 0x040c,
        RB_GETBANDCOUNT = 0x040c,
        SB_GETTEXTLENGTHW = 0x040c,
        TB_ISBUTTONHIDDEN = 0x040c,
        TBM_SETSELEND = 0x040c,
        TTM_UPDATETIPTEXTA = 0x040c,
        WIZ_PREV = 0x040c,
        CBEM_GETITEMW = 0x040d,
        RB_GETROWCOUNT = 0x040d,
        SB_GETTEXTW = 0x040d,
        TB_ISBUTTONINDETERMINATE = 0x040d,
        TTM_GETTOOLCOUNT = 0x040d,
        CBEM_SETEXTENDEDSTYLE = 0x040e,
        RB_GETROWHEIGHT = 0x040e,
        SB_ISSIMPLE = 0x040e,
        TB_ISBUTTONHIGHLIGHTED = 0x040e,
        TBM_GETPTICS = 0x040e,
        TTM_ENUMTOOLSA = 0x040e,
        SB_SETICON = 0x040f,
        TBM_GETTICPOS = 0x040f,
        TTM_GETCURRENTTOOLA = 0x040f,
        RB_IDTOINDEX = 0x0410,
        SB_SETTIPTEXTA = 0x0410,
        TBM_GETNUMTICS = 0x0410,
        TTM_WINDOWFROMPOINT = 0x0410,
        RB_GETTOOLTIPS = 0x0411,
        SB_SETTIPTEXTW = 0x0411,
        TBM_GETSELSTART = 0x0411,
        TB_SETSTATE = 0x0411,
        TTM_TRACKACTIVATE = 0x0411,
        RB_SETTOOLTIPS = 0x0412,
        SB_GETTIPTEXTA = 0x0412,
        TB_GETSTATE = 0x0412,
        TBM_GETSELEND = 0x0412,
        TTM_TRACKPOSITION = 0x0412,
        RB_SETBKCOLOR = 0x0413,
        SB_GETTIPTEXTW = 0x0413,
        TB_ADDBITMAP = 0x0413,
        TBM_CLEARSEL = 0x0413,
        TTM_SETTIPBKCOLOR = 0x0413,
        RB_GETBKCOLOR = 0x0414,
        SB_GETICON = 0x0414,
        TB_ADDBUTTONSA = 0x0414,
        TBM_SETTICFREQ = 0x0414,
        TTM_SETTIPTEXTCOLOR = 0x0414,
        RB_SETTEXTCOLOR = 0x0415,
        TB_INSERTBUTTONA = 0x0415,
        TBM_SETPAGESIZE = 0x0415,
        TTM_GETDELAYTIME = 0x0415,
        RB_GETTEXTCOLOR = 0x0416,
        TB_DELETEBUTTON = 0x0416,
        TBM_GETPAGESIZE = 0x0416,
        TTM_GETTIPBKCOLOR = 0x0416,
        RB_SIZETORECT = 0x0417,
        TB_GETBUTTON = 0x0417,
        TBM_SETLINESIZE = 0x0417,
        TTM_GETTIPTEXTCOLOR = 0x0417,
        RB_BEGINDRAG = 0x0418,
        TB_BUTTONCOUNT = 0x0418,
        TBM_GETLINESIZE = 0x0418,
        TTM_SETMAXTIPWIDTH = 0x0418,
        RB_ENDDRAG = 0x0419,
        TB_COMMANDTOINDEX = 0x0419,
        TBM_GETTHUMBRECT = 0x0419,
        TTM_GETMAXTIPWIDTH = 0x0419,
        RB_DRAGMOVE = 0x041a,
        TBM_GETCHANNELRECT = 0x041a,
        TB_SAVERESTOREA = 0x041a,
        TTM_SETMARGIN = 0x041a,
        RB_GETBARHEIGHT = 0x041b,
        TB_CUSTOMIZE = 0x041b,
        TBM_SETTHUMBLENGTH = 0x041b,
        TTM_GETMARGIN = 0x041b,
        RB_GETBANDINFOW = 0x041c,
        TB_ADDSTRINGA = 0x041c,
        TBM_GETTHUMBLENGTH = 0x041c,
        TTM_POP = 0x041c,
        RB_GETBANDINFOA = 0x041d,
        TB_GETITEMRECT = 0x041d,
        TBM_SETTOOLTIPS = 0x041d,
        TTM_UPDATE = 0x041d,
        RB_MINIMIZEBAND = 0x041e,
        TB_BUTTONSTRUCTSIZE = 0x041e,
        TBM_GETTOOLTIPS = 0x041e,
        TTM_GETBUBBLESIZE = 0x041e,
        RB_MAXIMIZEBAND = 0x041f,
        TBM_SETTIPSIDE = 0x041f,
        TB_SETBUTTONSIZE = 0x041f,
        TTM_ADJUSTRECT = 0x041f,
        TBM_SETBUDDY = 0x0420,
        TB_SETBITMAPSIZE = 0x0420,
        TTM_SETTITLEA = 0x0420,
        MSG_FTS_JUMP_VA = 0x0421,
        TB_AUTOSIZE = 0x0421,
        TBM_GETBUDDY = 0x0421,
        TTM_SETTITLEW = 0x0421,
        RB_GETBANDBORDERS = 0x0422,
        MSG_FTS_JUMP_QWORD = 0x0423,
        RB_SHOWBAND = 0x0423,
        TB_GETTOOLTIPS = 0x0423,
        MSG_REINDEX_REQUEST = 0x0424,
        TB_SETTOOLTIPS = 0x0424,
        MSG_FTS_WHERE_IS_IT = 0x0425,
        RB_SETPALETTE = 0x0425,
        TB_SETPARENT = 0x0425,
        RB_GETPALETTE = 0x0426,
        RB_MOVEBAND = 0x0427,
        TB_SETROWS = 0x0427,
        TB_GETROWS = 0x0428,
        TB_GETBITMAPFLAGS = 0x0429,
        TB_SETCMDID = 0x042a,
        RB_PUSHCHEVRON = 0x042b,
        TB_CHANGEBITMAP = 0x042b,
        TB_GETBITMAP = 0x042c,
        MSG_GET_DEFFONT = 0x042d,
        TB_GETBUTTONTEXTA = 0x042d,
        TB_REPLACEBITMAP = 0x042e,
        TB_SETINDENT = 0x042f,
        TB_SETIMAGELIST = 0x0430,
        TB_GETIMAGELIST = 0x0431,
        TB_LOADIMAGES = 0x0432,
        TTM_ADDTOOLW = 0x0432,
        TB_GETRECT = 0x0433,
        TTM_DELTOOLW = 0x0433,
        TB_SETHOTIMAGELIST = 0x0434,
        TTM_NEWTOOLRECTW = 0x0434,
        TB_GETHOTIMAGELIST = 0x0435,
        TTM_GETTOOLINFOW = 0x0435,
        TB_SETDISABLEDIMAGELIST = 0x0436,
        TTM_SETTOOLINFOW = 0x0436,
        TB_GETDISABLEDIMAGELIST = 0x0437,
        TTM_HITTESTW = 0x0437,
        TB_SETSTYLE = 0x0438,
        TTM_GETTEXTW = 0x0438,
        TB_GETSTYLE = 0x0439,
        TTM_UPDATETIPTEXTW = 0x0439,
        TB_GETBUTTONSIZE = 0x043a,
        TTM_ENUMTOOLSW = 0x043a,
        TB_SETBUTTONWIDTH = 0x043b,
        TTM_GETCURRENTTOOLW = 0x043b,
        TB_SETMAXTEXTROWS = 0x043c,
        TB_GETTEXTROWS = 0x043d,
        TB_GETOBJECT = 0x043e,
        TB_GETBUTTONINFOW = 0x043f,
        TB_SETBUTTONINFOW = 0x0440,
        TB_GETBUTTONINFOA = 0x0441,
        TB_SETBUTTONINFOA = 0x0442,
        TB_INSERTBUTTONW = 0x0443,
        TB_ADDBUTTONSW = 0x0444,
        TB_HITTEST = 0x0445,
        TB_SETDRAWTEXTFLAGS = 0x0446,
        TB_GETHOTITEM = 0x0447,
        TB_SETHOTITEM = 0x0448,
        TB_SETANCHORHIGHLIGHT = 0x0449,
        TB_GETANCHORHIGHLIGHT = 0x044a,
        TB_GETBUTTONTEXTW = 0x044b,
        TB_SAVERESTOREW = 0x044c,
        TB_ADDSTRINGW = 0x044d,
        TB_MAPACCELERATORA = 0x044e,
        TB_GETINSERTMARK = 0x044f,
        TB_SETINSERTMARK = 0x0450,
        TB_INSERTMARKHITTEST = 0x0451,
        TB_MOVEBUTTON = 0x0452,
        TB_GETMAXSIZE = 0x0453,
        TB_SETEXTENDEDSTYLE = 0x0454,
        TB_GETEXTENDEDSTYLE = 0x0455,
        TB_GETPADDING = 0x0456,
        TB_SETPADDING = 0x0457,
        TB_SETINSERTMARKCOLOR = 0x0458,
        TB_GETINSERTMARKCOLOR = 0x0459,
        TB_MAPACCELERATORW = 0x045a,
        TB_GETSTRINGW = 0x045b,
        TB_GETSTRINGA = 0x045c,
        TAPI_REPLY = 0x0463,
        ACM_OPENA = 0x0464,
        BFFM_SETSTATUSTEXTA = 0x0464,
        CDM_FIRST = 0x0464,
        CDM_GETSPEC = 0x0464,
        IPM_CLEARADDRESS = 0x0464,
        WM_CAP_UNICODE_START = 0x0464,
        ACM_PLAY = 0x0465,
        BFFM_ENABLEOK = 0x0465,
        CDM_GETFILEPATH = 0x0465,
        IPM_SETADDRESS = 0x0465,
        PSM_SETCURSEL = 0x0465,
        UDM_SETRANGE = 0x0465,
        WM_CHOOSEFONT_SETLOGFONT = 0x0465,
        ACM_STOP = 0x0466,
        BFFM_SETSELECTIONA = 0x0466,
        CDM_GETFOLDERPATH = 0x0466,
        IPM_GETADDRESS = 0x0466,
        PSM_REMOVEPAGE = 0x0466,
        UDM_GETRANGE = 0x0466,
        WM_CAP_SET_CALLBACK_ERRORW = 0x0466,
        WM_CHOOSEFONT_SETFLAGS = 0x0466,
        ACM_OPENW = 0x0467,
        BFFM_SETSELECTIONW = 0x0467,
        CDM_GETFOLDERIDLIST = 0x0467,
        IPM_SETRANGE = 0x0467,
        PSM_ADDPAGE = 0x0467,
        UDM_SETPOS = 0x0467,
        WM_CAP_SET_CALLBACK_STATUSW = 0x0467,
        BFFM_SETSTATUSTEXTW = 0x0468,
        CDM_SETCONTROLTEXT = 0x0468,
        IPM_SETFOCUS = 0x0468,
        PSM_CHANGED = 0x0468,
        UDM_GETPOS = 0x0468,
        CDM_HIDECONTROL = 0x0469,
        IPM_ISBLANK = 0x0469,
        PSM_RESTARTWINDOWS = 0x0469,
        UDM_SETBUDDY = 0x0469,
        CDM_SETDEFEXT = 0x046a,
        PSM_REBOOTSYSTEM = 0x046a,
        UDM_GETBUDDY = 0x046a,
        PSM_CANCELTOCLOSE = 0x046b,
        UDM_SETACCEL = 0x046b,
        EM_CONVPOSITION = 0x046c,
        PSM_QUERYSIBLINGS = 0x046c,
        UDM_GETACCEL = 0x046c,
        MCIWNDM_GETZOOM = 0x046d,
        PSM_UNCHANGED = 0x046d,
        UDM_SETBASE = 0x046d,
        PSM_APPLY = 0x046e,
        UDM_GETBASE = 0x046e,
        PSM_SETTITLEA = 0x046f,
        UDM_SETRANGE32 = 0x046f,
        PSM_SETWIZBUTTONS = 0x0470,
        UDM_GETRANGE32 = 0x0470,
        WM_CAP_DRIVER_GET_NAMEW = 0x0470,
        PSM_PRESSBUTTON = 0x0471,
        UDM_SETPOS32 = 0x0471,
        WM_CAP_DRIVER_GET_VERSIONW = 0x0471,
        PSM_SETCURSELID = 0x0472,
        UDM_GETPOS32 = 0x0472,
        PSM_SETFINISHTEXTA = 0x0473,
        PSM_GETTABCONTROL = 0x0474,
        PSM_ISDIALOGMESSAGE = 0x0475,
        MCIWNDM_REALIZE = 0x0476,
        PSM_GETCURRENTPAGEHWND = 0x0476,
        MCIWNDM_SETTIMEFORMATA = 0x0477,
        PSM_INSERTPAGE = 0x0477,
        MCIWNDM_GETTIMEFORMATA = 0x0478,
        PSM_SETTITLEW = 0x0478,
        WM_CAP_FILE_SET_CAPTURE_FILEW = 0x0478,
        MCIWNDM_VALIDATEMEDIA = 0x0479,
        PSM_SETFINISHTEXTW = 0x0479,
        WM_CAP_FILE_GET_CAPTURE_FILEW = 0x0479,
        MCIWNDM_PLAYTO = 0x047b,
        WM_CAP_FILE_SAVEASW = 0x047b,
        MCIWNDM_GETFILENAMEA = 0x047c,
        MCIWNDM_GETDEVICEA = 0x047d,
        PSM_SETHEADERTITLEA = 0x047d,
        WM_CAP_FILE_SAVEDIBW = 0x047d,
        MCIWNDM_GETPALETTE = 0x047e,
        PSM_SETHEADERTITLEW = 0x047e,
        MCIWNDM_SETPALETTE = 0x047f,
        PSM_SETHEADERSUBTITLEA = 0x047f,
        MCIWNDM_GETERRORA = 0x0480,
        PSM_SETHEADERSUBTITLEW = 0x0480,
        PSM_HWNDTOINDEX = 0x0481,
        PSM_INDEXTOHWND = 0x0482,
        MCIWNDM_SETINACTIVETIMER = 0x0483,
        PSM_PAGETOINDEX = 0x0483,
        PSM_INDEXTOPAGE = 0x0484,
        DL_BEGINDRAG = 0x0485,
        MCIWNDM_GETINACTIVETIMER = 0x0485,
        PSM_IDTOINDEX = 0x0485,
        DL_DRAGGING = 0x0486,
        PSM_INDEXTOID = 0x0486,
        DL_DROPPED = 0x0487,
        PSM_GETRESULT = 0x0487,
        DL_CANCELDRAG = 0x0488,
        PSM_RECALCPAGESIZES = 0x0488,
        MCIWNDM_GET_SOURCE = 0x048c,
        MCIWNDM_PUT_SOURCE = 0x048d,
        MCIWNDM_GET_DEST = 0x048e,
        MCIWNDM_PUT_DEST = 0x048f,
        MCIWNDM_CAN_PLAY = 0x0490,
        MCIWNDM_CAN_WINDOW = 0x0491,
        MCIWNDM_CAN_RECORD = 0x0492,
        MCIWNDM_CAN_SAVE = 0x0493,
        MCIWNDM_CAN_EJECT = 0x0494,
        MCIWNDM_CAN_CONFIG = 0x0495,
        IE_GETINK = 0x0496,
        IE_MSGFIRST = 0x0496,
        MCIWNDM_PALETTEKICK = 0x0496,
        IE_SETINK = 0x0497,
        IE_GETPENTIP = 0x0498,
        IE_SETPENTIP = 0x0499,
        IE_GETERASERTIP = 0x049a,
        IE_SETERASERTIP = 0x049b,
        IE_GETBKGND = 0x049c,
        IE_SETBKGND = 0x049d,
        IE_GETGRIDORIGIN = 0x049e,
        IE_SETGRIDORIGIN = 0x049f,
        IE_GETGRIDPEN = 0x04a0,
        IE_SETGRIDPEN = 0x04a1,
        IE_GETGRIDSIZE = 0x04a2,
        IE_SETGRIDSIZE = 0x04a3,
        IE_GETMODE = 0x04a4,
        IE_SETMODE = 0x04a5,
        IE_GETINKRECT = 0x04a6,
        WM_CAP_SET_MCI_DEVICEW = 0x04a6,
        WM_CAP_GET_MCI_DEVICEW = 0x04a7,
        WM_CAP_PAL_OPENW = 0x04b4,
        WM_CAP_PAL_SAVEW = 0x04b5,
        IE_GETAPPDATA = 0x04b8,
        IE_SETAPPDATA = 0x04b9,
        IE_GETDRAWOPTS = 0x04ba,
        IE_SETDRAWOPTS = 0x04bb,
        IE_GETFORMAT = 0x04bc,
        IE_SETFORMAT = 0x04bd,
        IE_GETINKINPUT = 0x04be,
        IE_SETINKINPUT = 0x04bf,
        IE_GETNOTIFY = 0x04c0,
        IE_SETNOTIFY = 0x04c1,
        IE_GETRECOG = 0x04c2,
        IE_SETRECOG = 0x04c3,
        IE_GETSECURITY = 0x04c4,
        IE_SETSECURITY = 0x04c5,
        IE_GETSEL = 0x04c6,
        IE_SETSEL = 0x04c7,
        CDM_LAST = 0x04c8,
        IE_DOCOMMAND = 0x04c8,
        MCIWNDM_NOTIFYMODE = 0x04c8,
        IE_GETCOMMAND = 0x04c9,
        IE_GETCOUNT = 0x04ca,
        IE_GETGESTURE = 0x04cb,
        MCIWNDM_NOTIFYMEDIA = 0x04cb,
        IE_GETMENU = 0x04cc,
        IE_GETPAINTDC = 0x04cd,
        MCIWNDM_NOTIFYERROR = 0x04cd,
        IE_GETPDEVENT = 0x04ce,
        IE_GETSELCOUNT = 0x04cf,
        IE_GETSELITEMS = 0x04d0,
        IE_GETSTYLE = 0x04d1,
        MCIWNDM_SETTIMEFORMATW = 0x04db,
        EM_OUTLINE = 0x04dc,
        MCIWNDM_GETTIMEFORMATW = 0x04dc,
        EM_GETSCROLLPOS = 0x04dd,
        EM_SETSCROLLPOS = 0x04de,
        EM_SETFONTSIZE = 0x04df,
        MCIWNDM_GETFILENAMEW = 0x04e0,
        MCIWNDM_GETDEVICEW = 0x04e1,
        MCIWNDM_GETERRORW = 0x04e4,
        FM_GETFOCUS = 0x0600,
        FM_GETDRIVEINFOA = 0x0601,
        FM_GETSELCOUNT = 0x0602,
        FM_GETSELCOUNTLFN = 0x0603,
        FM_GETFILESELA = 0x0604,
        FM_GETFILESELLFNA = 0x0605,
        FM_REFRESH_WINDOWS = 0x0606,
        FM_RELOAD_EXTENSIONS = 0x0607,
        FM_GETDRIVEINFOW = 0x0611,
        FM_GETFILESELW = 0x0614,
        FM_GETFILESELLFNW = 0x0615,
        WLX_WM_SAS = 0x0659,
        SM_GETSELCOUNT = 0x07e8,
        UM_GETSELCOUNT = 0x07e8,
        WM_CPL_LAUNCH = 0x07e8,
        SM_GETSERVERSELA = 0x07e9,
        UM_GETUSERSELA = 0x07e9,
        WM_CPL_LAUNCHED = 0x07e9,
        SM_GETSERVERSELW = 0x07ea,
        UM_GETUSERSELW = 0x07ea,
        SM_GETCURFOCUSA = 0x07eb,
        UM_GETGROUPSELA = 0x07eb,
        SM_GETCURFOCUSW = 0x07ec,
        UM_GETGROUPSELW = 0x07ec,
        SM_GETOPTIONS = 0x07ed,
        UM_GETCURFOCUSA = 0x07ed,
        UM_GETCURFOCUSW = 0x07ee,
        UM_GETOPTIONS = 0x07ef,
        UM_GETOPTIONS2 = 0x07f0,
        OCMBASE = 0x2000,
        OCM_CTLCOLOR = 0x2019,
        OCM_DRAWITEM = 0x202b,
        OCM_MEASUREITEM = 0x202c,
        OCM_DELETEITEM = 0x202d,
        OCM_VKEYTOITEM = 0x202e,
        OCM_CHARTOITEM = 0x202f,
        OCM_COMPAREITEM = 0x2039,
        OCM_NOTIFY = 0x204e,
        OCM_COMMAND = 0x2111,
        OCM_HSCROLL = 0x2114,
        OCM_VSCROLL = 0x2115,
        OCM_CTLCOLORMSGBOX = 0x2132,
        OCM_CTLCOLOREDIT = 0x2133,
        OCM_CTLCOLORLISTBOX = 0x2134,
        OCM_CTLCOLORBTN = 0x2135,
        OCM_CTLCOLORDLG = 0x2136,
        OCM_CTLCOLORSCROLLBAR = 0x2137,
        OCM_CTLCOLORSTATIC = 0x2138,
        OCM_PARENTNOTIFY = 0x2210,
        WM_APP = 0x8000,
        WM_RASDIALEVENT = 0xcccd,
    }

    public static class WindowMessageTypeExtensions
    {
        public static Int32 ToInt32(this WindowMessageType windowMessageType)
        {
            return (Int32) windowMessageType;
        }

        public static UInt32 ToUInt32(this WindowMessageType windowMessageType)
        {
            return (UInt32) windowMessageType;
        }

        public static Int64 ToInt64(this WindowMessageType windowMessageType)
        {
            return (Int64) windowMessageType;
        }

        public static UInt64 ToUInt64(this WindowMessageType windowMessageType)
        {
            return (UInt64) windowMessageType;
        }
    }
}
