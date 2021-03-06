﻿// Copyright 2013-2014 Andrew C. Dvorak
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
using System.Linq;
using System.Windows.Forms;
using NativeAPI;
using OSUtils.Window;
using NativeAPI.Win.User;
using UILib.WinForms;

namespace WindowsOSUtils.Windows
{
    /// <seealso href="http://stackoverflow.com/a/4616637/467582"/>
    public class WindowMenu : IWindowMenu
    {
        #region Fields (private)

        /// <summary>
        ///     Handle to a copy of the form's system (window) menu.
        /// </summary>
        private readonly IntPtr _hSysMenu;

        private readonly IList<IWindowMenuItem> _items = new List<IWindowMenuItem>();

        #endregion

        internal WindowMenu(Form form)
        {
            _hSysMenu = SystemMenuAPI.GetSystemMenu(form.Handle, false);
            new WndProcHook(form).WndProcMessage += OnWndProcMessage;
        }

        #region Window message handling

        private void OnWndProcMessage(ref Message m, HandledEventArgs args)
        {
            WindowMessage msg = m;

            // Test if the About item was selected from the system menu
            if (!msg.Is(WindowMessageType.WM_SYSCOMMAND))
                return;

            var itemId = (int) m.WParam;
            var item = _items.FirstOrDefault(menuItem => menuItem.Id == itemId);

            if (item == null)
                return;

            item.Click(EventArgs.Empty);
        }

        #endregion

        #region Public API

        public void AppendMenu(IWindowMenuItem menuItem)
        {
            PInvokeUtils.Try(() => SystemMenuAPI.AppendMenu(_hSysMenu, MenuFlags.MF_STRING, menuItem.Id, menuItem.Text));
            _items.Add(menuItem);
        }

        public void AppendSeparator()
        {
            PInvokeUtils.Try(() => SystemMenuAPI.AppendMenu(_hSysMenu, MenuFlags.MF_SEPARATOR, 0, string.Empty));
        }

        public void InsertMenu(uint position, IWindowMenuItem menuItem)
        {
            PInvokeUtils.Try(() => SystemMenuAPI.InsertMenu(_hSysMenu, position, MenuFlags.MF_BYPOSITION | MenuFlags.MF_STRING, menuItem.Id, menuItem.Text));
            _items.Add(menuItem);
        }

        public void InsertSeparator(uint position)
        {
            PInvokeUtils.Try(() => SystemMenuAPI.InsertMenu(_hSysMenu, position, MenuFlags.MF_BYPOSITION | MenuFlags.MF_SEPARATOR, 0, string.Empty));
        }

        public void UpdateMenu(IWindowMenuItem menuItem)
        {
            var mii = new MENUITEMINFO(null)
                      {
                          fMask = MenuItemInfoMember.MIIM_CHECKMARKS |
                                  MenuItemInfoMember.MIIM_DATA |
                                  MenuItemInfoMember.MIIM_FTYPE |
                                  MenuItemInfoMember.MIIM_ID |
                                  MenuItemInfoMember.MIIM_STATE |
                                  MenuItemInfoMember.MIIM_STRING
                      };

            PInvokeUtils.Try(() => SystemMenuAPI.GetMenuItemInfo(_hSysMenu, menuItem.Id, false, ref mii));

            if (menuItem.Enabled)
                mii.fState &= (~MenuItemState.MFS_DISABLED); // clear "disabled" flag
            else
                mii.fState |= MenuItemState.MFS_DISABLED;    // set "disabled" flag

            if (menuItem.Checked)
                mii.fState |= MenuItemState.MFS_CHECKED;     // set "checked" flag
            else
                mii.fState &= (~MenuItemState.MFS_CHECKED);  // clear "checked" flag

            mii.fMask = MenuItemInfoMember.MIIM_STATE;

            PInvokeUtils.Try(() => SystemMenuAPI.SetMenuItemInfo(_hSysMenu, menuItem.Id, false, ref mii));

            // TODO: From my observations, this function always returns false, even though it appears to succeed.
            //       Am I using it incorrectly?
            SystemMenuAPI.DrawMenuBar(_hSysMenu);
        }

        #endregion
    }
}
