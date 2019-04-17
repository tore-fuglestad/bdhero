﻿// ReSharper disable InconsistentNaming
namespace NativeAPI.Win.UXTheme
{
    /// <summary>
    ///     VisualStyle Style Guide symbols from <c>vsstyle.h</c>.
    /// </summary>
    /// <seealso href="http://www.ookii.org/misc/vsstyle.h"/>
    /// <seealso href="https://code.google.com/p/miranda/source/browse/trunk/miranda/include/msapi/vssym32.h?r=11670"/>
    internal static class VisualStyle
    {
        #region Theme classes

        /// <summary>
        ///     Theme class (i.e., type).
        /// </summary>
        /// <seealso href="http://stackoverflow.com/a/6539701/467582"/>
        public static class CLASS
        {
            public const string BUTTON = "BUTTON";
            public const string CLOCK = "CLOCK";
            public const string COMBOBOX = "COMBOBOX";
            public const string COMMUNICATIONS = "COMMUNICATIONS";
            public const string CONTROLPANEL = "CONTROLPANEL";
            public const string DATEPICKER = "DATEPICKER";
            public const string DRAGDROP = "DRAGDROP";
            public const string EDIT = "EDIT";
            public const string EXPLORERBAR = "EXPLORERBAR";
            public const string FLYOUT = "FLYOUT";
            public const string GLOBALS = "GLOBALS";
            public const string HEADER = "HEADER";
            public const string LISTBOX = "LISTBOX";
            public const string LISTVIEW = "LISTVIEW";
            public const string MENU = "MENU";
            public const string MENUBAND = "MENUBAND";
            public const string NAVIGATION = "NAVIGATION";
            public const string PAGE = "PAGE";
            public const string PROGRESS = "PROGRESS";
            public const string REBAR = "REBAR";
            public const string SCROLLBAR = "SCROLLBAR";
            public const string SEARCHEDITBOX = "SEARCHEDITBOX";
            public const string SPIN = "SPIN";
            public const string STARTPANEL = "STARTPANEL";
            public const string STATUS = "STATUS";
            public const string TAB = "TAB";
            public const string TASKBAND = "TASKBAND";
            public const string TASKBAR = "TASKBAR";
            public const string TASKDIALOG = "TASKDIALOG";
            public const string TEXTSTYLE = "TEXTSTYLE";
            public const string TOOLBAR = "TOOLBAR";
            public const string TOOLTIP = "TOOLTIP";
            public const string TRACKBAR = "TRACKBAR";
            public const string TRAYNOTIFY = "TRAYNOTIFY";
            public const string TREEVIEW = "TREEVIEW";
            public const string WINDOW = "WINDOW";
        }

        #endregion

        #region AEROWIZARDSTYLE class parts and states

        public enum AEROWIZARDPARTS
        {
            AW_TITLEBAR = 1,
            AW_HEADERAREA = 2,
            AW_CONTENTAREA = 3,
            AW_COMMANDAREA = 4,
            AW_BUTTON = 5,
        }

        public enum TITLEBARSTATES
        {
            AW_S_TITLEBAR_ACTIVE = 1,
            AW_S_TITLEBAR_INACTIVE = 2,
        }

        public enum HEADERAREASTATES
        {
            AW_S_HEADERAREA_NOMARGIN = 1,
        }

        public enum CONTENTAREASTATES
        {
            AW_S_CONTENTAREA_NOMARGIN = 1,
        }

        #endregion

        #region BUTTONSTYLE class parts and states

        public enum BUTTONPARTS
        {
            BP_PUSHBUTTON = 1,
            BP_RADIOBUTTON = 2,
            BP_CHECKBOX = 3,
            BP_GROUPBOX = 4,
            BP_USERBUTTON = 5,
            BP_COMMANDLINK = 6,
            BP_COMMANDLINKGLYPH = 7,
        }

        public enum PUSHBUTTONSTATES
        {
            PBS_NORMAL = 1,
            PBS_HOT = 2,
            PBS_PRESSED = 3,
            PBS_DISABLED = 4,
            PBS_DEFAULTED = 5,
            PBS_DEFAULTED_ANIMATING = 6,
        }

        public enum RADIOBUTTONSTATES
        {
            RBS_UNCHECKEDNORMAL = 1,
            RBS_UNCHECKEDHOT = 2,
            RBS_UNCHECKEDPRESSED = 3,
            RBS_UNCHECKEDDISABLED = 4,
            RBS_CHECKEDNORMAL = 5,
            RBS_CHECKEDHOT = 6,
            RBS_CHECKEDPRESSED = 7,
            RBS_CHECKEDDISABLED = 8,
        }

        public enum CHECKBOXSTATES
        {
            CBS_UNCHECKEDNORMAL = 1,
            CBS_UNCHECKEDHOT = 2,
            CBS_UNCHECKEDPRESSED = 3,
            CBS_UNCHECKEDDISABLED = 4,
            CBS_CHECKEDNORMAL = 5,
            CBS_CHECKEDHOT = 6,
            CBS_CHECKEDPRESSED = 7,
            CBS_CHECKEDDISABLED = 8,
            CBS_MIXEDNORMAL = 9,
            CBS_MIXEDHOT = 10,
            CBS_MIXEDPRESSED = 11,
            CBS_MIXEDDISABLED = 12,
            CBS_IMPLICITNORMAL = 13,
            CBS_IMPLICITHOT = 14,
            CBS_IMPLICITPRESSED = 15,
            CBS_IMPLICITDISABLED = 16,
            CBS_EXCLUDEDNORMAL = 17,
            CBS_EXCLUDEDHOT = 18,
            CBS_EXCLUDEDPRESSED = 19,
            CBS_EXCLUDEDDISABLED = 20,
        }

        public enum GROUPBOXSTATES
        {
            GBS_NORMAL = 1,
            GBS_DISABLED = 2,
        }

        public enum COMMANDLINKSTATES
        {
            CMDLS_NORMAL = 1,
            CMDLS_HOT = 2,
            CMDLS_PRESSED = 3,
            CMDLS_DISABLED = 4,
            CMDLS_DEFAULTED = 5,
            CMDLS_DEFAULTED_ANIMATING = 6,
        }

        public enum COMMANDLINKGLYPHSTATES
        {
            CMDLGS_NORMAL = 1,
            CMDLGS_HOT = 2,
            CMDLGS_PRESSED = 3,
            CMDLGS_DISABLED = 4,
            CMDLGS_DEFAULTED = 5,
        }

        #endregion

        #region COMBOBOXSTYLE class parts and states

        public enum COMBOBOXPARTS
        {
            CP_DROPDOWNBUTTON = 1,
            CP_BACKGROUND = 2,
            CP_TRANSPARENTBACKGROUND = 3,
            CP_BORDER = 4,
            CP_READONLY = 5,
            CP_DROPDOWNBUTTONRIGHT = 6,
            CP_DROPDOWNBUTTONLEFT = 7,
            CP_CUEBANNER = 8,
        }

        public enum COMBOBOXSTYLESTATES
        {
            CBXS_NORMAL = 1,
            CBXS_HOT = 2,
            CBXS_PRESSED = 3,
            CBXS_DISABLED = 4,
        }

        public enum DROPDOWNBUTTONRIGHTSTATES
        {
            CBXSR_NORMAL = 1,
            CBXSR_HOT = 2,
            CBXSR_PRESSED = 3,
            CBXSR_DISABLED = 4,
        }

        public enum DROPDOWNBUTTONLEFTSTATES
        {
            CBXSL_NORMAL = 1,
            CBXSL_HOT = 2,
            CBXSL_PRESSED = 3,
            CBXSL_DISABLED = 4,
        }

        public enum TRANSPARENTBACKGROUNDSTATES
        {
            CBTBS_NORMAL = 1,
            CBTBS_HOT = 2,
            CBTBS_DISABLED = 3,
            CBTBS_FOCUSED = 4,
        }

        public enum BORDERSTATES
        {
            CBB_NORMAL = 1,
            CBB_HOT = 2,
            CBB_FOCUSED = 3,
            CBB_DISABLED = 4,
        }

        public enum READONLYSTATES
        {
            CBRO_NORMAL = 1,
            CBRO_HOT = 2,
            CBRO_PRESSED = 3,
            CBRO_DISABLED = 4,
        }

        public enum CUEBANNERSTATES
        {
            CBCB_NORMAL = 1,
            CBCB_HOT = 2,
            CBCB_PRESSED = 3,
            CBCB_DISABLED = 4,
        }

        #endregion

        #region COMMUNICATIONSSTYLE class parts and states

        public enum COMMUNICATIONSPARTS
        {
            CSST_TAB = 1,
        }

        public enum TABSTATES
        {
            CSTB_NORMAL = 1,
            CSTB_HOT = 2,
            CSTB_SELECTED = 3,
        }

        #endregion

        #region CONTROLPANELSTYLE class parts and states

        public enum CONTROLPANELPARTS
        {
            CPANEL_NAVIGATIONPANE = 1,
            CPANEL_CONTENTPANE = 2,
            CPANEL_NAVIGATIONPANELABEL = 3,
            CPANEL_CONTENTPANELABEL = 4,
            CPANEL_TITLE = 5,
            CPANEL_BODYTEXT = 6,
            CPANEL_HELPLINK = 7,
            CPANEL_TASKLINK = 8,
            CPANEL_GROUPTEXT = 9,
            CPANEL_CONTENTLINK = 10,
            CPANEL_SECTIONTITLELINK = 11,
            CPANEL_LARGECOMMANDAREA = 12,
            CPANEL_SMALLCOMMANDAREA = 13,
            CPANEL_BUTTON = 14,
            CPANEL_MESSAGETEXT = 15,
            CPANEL_NAVIGATIONPANELINE = 16,
            CPANEL_CONTENTPANELINE = 17,
            CPANEL_BANNERAREA = 18,
            CPANEL_BODYTITLE = 19,
        }

        public enum HELPLINKSTATES
        {
            CPHL_NORMAL = 1,
            CPHL_HOT = 2,
            CPHL_PRESSED = 3,
            CPHL_DISABLED = 4,
        }

        public enum TASKLINKSTATES
        {
            CPTL_NORMAL = 1,
            CPTL_HOT = 2,
            CPTL_PRESSED = 3,
            CPTL_DISABLED = 4,
            CPTL_PAGE = 5,
        }

        public enum CONTENTLINKSTATES
        {
            CPCL_NORMAL = 1,
            CPCL_HOT = 2,
            CPCL_PRESSED = 3,
            CPCL_DISABLED = 4,
        }

        public enum SECTIONTITLELINKSTATES
        {
            CPSTL_NORMAL = 1,
            CPSTL_HOT = 2,
        }

        #endregion

        #region DATEPICKERSTYLE class parts and states

        public enum DATEPICKERPARTS
        {
            DP_DATETEXT = 1,
            DP_DATEBORDER = 2,
            DP_SHOWCALENDARBUTTONRIGHT = 3,
        }

        public enum DATETEXTSTATES
        {
            DPDT_NORMAL = 1,
            DPDT_DISABLED = 2,
            DPDT_SELECTED = 3,
        }

        public enum DATEBORDERSTATES
        {
            DPDB_NORMAL = 1,
            DPDB_HOT = 2,
            DPDB_FOCUSED = 3,
            DPDB_DISABLED = 4,
        }

        public enum SHOWCALENDARBUTTONRIGHTSTATES
        {
            DPSCBR_NORMAL = 1,
            DPSCBR_HOT = 2,
            DPSCBR_PRESSED = 3,
            DPSCBR_DISABLED = 4,
        }

        #endregion

        #region DRAGDROPSTYLE class parts and states

        public enum DRAGDROPPARTS
        {
            DD_COPY = 1,
            DD_MOVE = 2,
            DD_UPDATEMETADATA = 3,
            DD_CREATELINK = 4,
            DD_WARNING = 5,
            DD_NONE = 6,
            DD_IMAGEBG = 7,
            DD_TEXTBG = 8,
        }

        public enum COPYSTATES
        {
            DDCOPY_HIGHLIGHT = 1,
            DDCOPY_NOHIGHLIGHT = 2,
        }

        public enum MOVESTATES
        {
            DDMOVE_HIGHLIGHT = 1,
            DDMOVE_NOHIGHLIGHT = 2,
        }

        public enum UPDATEMETADATASTATES
        {
            DDUPDATEMETADATA_HIGHLIGHT = 1,
            DDUPDATEMETADATA_NOHIGHLIGHT = 2,
        }

        public enum CREATELINKSTATES
        {
            DDCREATELINK_HIGHLIGHT = 1,
            DDCREATELINK_NOHIGHLIGHT = 2,
        }

        public enum WARNINGSTATES
        {
            DDWARNING_HIGHLIGHT = 1,
            DDWARNING_NOHIGHLIGHT = 2,
        }

        public enum NONESTATES
        {
            DDNONE_HIGHLIGHT = 1,
            DDNONE_NOHIGHLIGHT = 2,
        }

        #endregion

        #region EDITSTYLE class parts and states

        public enum EDITPARTS
        {
            EP_EDITTEXT = 1,
            EP_CARET = 2,
            EP_BACKGROUND = 3,
            EP_PASSWORD = 4,
            EP_BACKGROUNDWITHBORDER = 5,
            EP_EDITBORDER_NOSCROLL = 6,
            EP_EDITBORDER_HSCROLL = 7,
            EP_EDITBORDER_VSCROLL = 8,
            EP_EDITBORDER_HVSCROLL = 9,
        }

        public enum EDITTEXTSTATES
        {
            ETS_NORMAL = 1,
            ETS_HOT = 2,
            ETS_SELECTED = 3,
            ETS_DISABLED = 4,
            ETS_FOCUSED = 5,
            ETS_READONLY = 6,
            ETS_ASSIST = 7,
            ETS_CUEBANNER = 8,
        }

        public enum BACKGROUNDSTATES
        {
            EBS_NORMAL = 1,
            EBS_HOT = 2,
            EBS_DISABLED = 3,
            EBS_FOCUSED = 4,
            EBS_READONLY = 5,
            EBS_ASSIST = 6,
        }

        public enum BACKGROUNDWITHBORDERSTATES
        {
            EBWBS_NORMAL = 1,
            EBWBS_HOT = 2,
            EBWBS_DISABLED = 3,
            EBWBS_FOCUSED = 4,
        }

        public enum EDITBORDER_NOSCROLLSTATES
        {
            EPSN_NORMAL = 1,
            EPSN_HOT = 2,
            EPSN_FOCUSED = 3,
            EPSN_DISABLED = 4,
        }

        public enum EDITBORDER_HSCROLLSTATES
        {
            EPSH_NORMAL = 1,
            EPSH_HOT = 2,
            EPSH_FOCUSED = 3,
            EPSH_DISABLED = 4,
        }

        public enum EDITBORDER_VSCROLLSTATES
        {
            EPSV_NORMAL = 1,
            EPSV_HOT = 2,
            EPSV_FOCUSED = 3,
            EPSV_DISABLED = 4,
        }

        public enum EDITBORDER_HVSCROLLSTATES
        {
            EPSHV_NORMAL = 1,
            EPSHV_HOT = 2,
            EPSHV_FOCUSED = 3,
            EPSHV_DISABLED = 4,
        }

        #endregion

        #region EXPLORERBARSTYLE class parts and states

        public enum EXPLORERBARPARTS
        {
            EBP_HEADERBACKGROUND = 1,
            EBP_HEADERCLOSE = 2,
            EBP_HEADERPIN = 3,
            EBP_IEBARMENU = 4,
            EBP_NORMALGROUPBACKGROUND = 5,
            EBP_NORMALGROUPCOLLAPSE = 6,
            EBP_NORMALGROUPEXPAND = 7,
            EBP_NORMALGROUPHEAD = 8,
            EBP_SPECIALGROUPBACKGROUND = 9,
            EBP_SPECIALGROUPCOLLAPSE = 10,
            EBP_SPECIALGROUPEXPAND = 11,
            EBP_SPECIALGROUPHEAD = 12,
        }

        public enum HEADERCLOSESTATES
        {
            EBHC_NORMAL = 1,
            EBHC_HOT = 2,
            EBHC_PRESSED = 3,
        }

        public enum HEADERPINSTATES
        {
            EBHP_NORMAL = 1,
            EBHP_HOT = 2,
            EBHP_PRESSED = 3,
            EBHP_SELECTEDNORMAL = 4,
            EBHP_SELECTEDHOT = 5,
            EBHP_SELECTEDPRESSED = 6,
        }

        public enum IEBARMENUSTATES
        {
            EBM_NORMAL = 1,
            EBM_HOT = 2,
            EBM_PRESSED = 3,
        }

        public enum NORMALGROUPCOLLAPSESTATES
        {
            EBNGC_NORMAL = 1,
            EBNGC_HOT = 2,
            EBNGC_PRESSED = 3,
        }

        public enum NORMALGROUPEXPANDSTATES
        {
            EBNGE_NORMAL = 1,
            EBNGE_HOT = 2,
            EBNGE_PRESSED = 3,
        }

        public enum SPECIALGROUPCOLLAPSESTATES
        {
            EBSGC_NORMAL = 1,
            EBSGC_HOT = 2,
            EBSGC_PRESSED = 3,
        }

        public enum SPECIALGROUPEXPANDSTATES
        {
            EBSGE_NORMAL = 1,
            EBSGE_HOT = 2,
            EBSGE_PRESSED = 3,
        }

        #endregion

        #region FLYOUTSTYLE class parts and states

        public enum FLYOUTPARTS
        {
            FLYOUT_HEADER = 1,
            FLYOUT_BODY = 2,
            FLYOUT_LABEL = 3,
            FLYOUT_LINK = 4,
            FLYOUT_DIVIDER = 5,
            FLYOUT_WINDOW = 6,
            FLYOUT_LINKAREA = 7,
            FLYOUT_LINKHEADER = 8,
        }

        public enum LABELSTATES
        {
            FLS_NORMAL = 1,
            FLS_SELECTED = 2,
            FLS_EMPHASIZED = 3,
            FLS_DISABLED = 4,
        }

        public enum LINKSTATES
        {
            FLYOUTLINK_NORMAL = 1,
            FLYOUTLINK_HOVER = 2,
        }

        public enum BODYSTATES
        {
            FBS_NORMAL = 1,
            FBS_EMPHASIZED = 2,
        }

        public enum LINKHEADERSTATES
        {
            FLH_NORMAL = 1,
            FLH_HOVER = 2,
        }

        #endregion

        #region HEADERSTYLE class parts and states

        public enum HEADERPARTS
        {
            HP_HEADERITEM = 1,
            HP_HEADERITEMLEFT = 2,
            HP_HEADERITEMRIGHT = 3,
            HP_HEADERSORTARROW = 4,
            HP_HEADERDROPDOWN = 5,
            HP_HEADERDROPDOWNFILTER = 6,
            HP_HEADEROVERFLOW = 7,
        }

        public enum HEADERSTYLESTATES
        {
            HBG_DETAILS = 1,
            HBG_ICON = 2,
        }

        public enum HEADERITEMSTATES
        {
            HIS_NORMAL = 1,
            HIS_HOT = 2,
            HIS_PRESSED = 3,
            HIS_SORTEDNORMAL = 4,
            HIS_SORTEDHOT = 5,
            HIS_SORTEDPRESSED = 6,
            HIS_ICONNORMAL = 7,
            HIS_ICONHOT = 8,
            HIS_ICONPRESSED = 9,
            HIS_ICONSORTEDNORMAL = 10,
            HIS_ICONSORTEDHOT = 11,
            HIS_ICONSORTEDPRESSED = 12,
        }

        public enum HEADERITEMLEFTSTATES
        {
            HILS_NORMAL = 1,
            HILS_HOT = 2,
            HILS_PRESSED = 3,
        }

        public enum HEADERITEMRIGHTSTATES
        {
            HIRS_NORMAL = 1,
            HIRS_HOT = 2,
            HIRS_PRESSED = 3,
        }

        public enum HEADERSORTARROWSTATES
        {
            HSAS_SORTEDUP = 1,
            HSAS_SORTEDDOWN = 2,
        }

        public enum HEADERDROPDOWNSTATES
        {
            HDDS_NORMAL = 1,
            HDDS_SOFTHOT = 2,
            HDDS_HOT = 3,
        }

        public enum HEADERDROPDOWNFILTERSTATES
        {
            HDDFS_NORMAL = 1,
            HDDFS_SOFTHOT = 2,
            HDDFS_HOT = 3,
        }

        public enum HEADEROVERFLOWSTATES
        {
            HOFS_NORMAL = 1,
            HOFS_HOT = 2,
        }

        #endregion

        #region LISTBOXSTYLE class parts and states

        public enum LISTBOXPARTS
        {
            LBCP_BORDER_HSCROLL = 1,
            LBCP_BORDER_HVSCROLL = 2,
            LBCP_BORDER_NOSCROLL = 3,
            LBCP_BORDER_VSCROLL = 4,
            LBCP_ITEM = 5,
        }

        public enum BORDER_HSCROLLSTATES
        {
            LBPSH_NORMAL = 1,
            LBPSH_FOCUSED = 2,
            LBPSH_HOT = 3,
            LBPSH_DISABLED = 4,
        }

        public enum BORDER_HVSCROLLSTATES
        {
            LBPSHV_NORMAL = 1,
            LBPSHV_FOCUSED = 2,
            LBPSHV_HOT = 3,
            LBPSHV_DISABLED = 4,
        }

        public enum BORDER_NOSCROLLSTATES
        {
            LBPSN_NORMAL = 1,
            LBPSN_FOCUSED = 2,
            LBPSN_HOT = 3,
            LBPSN_DISABLED = 4,
        }

        public enum BORDER_VSCROLLSTATES
        {
            LBPSV_NORMAL = 1,
            LBPSV_FOCUSED = 2,
            LBPSV_HOT = 3,
            LBPSV_DISABLED = 4,
        }

        public enum ITEMSTATES
        {
            LBPSI_HOT = 1,
            LBPSI_HOTSELECTED = 2,
            LBPSI_SELECTED = 3,
            LBPSI_SELECTEDNOTFOCUS = 4,
        }

        #endregion

        #region LISTVIEWSTYLE class parts and states

        public enum LISTVIEWPARTS
        {
            LVP_LISTITEM = 1,
            LVP_LISTGROUP = 2,
            LVP_LISTDETAIL = 3,
            LVP_LISTSORTEDDETAIL = 4,
            LVP_EMPTYTEXT = 5,
            LVP_GROUPHEADER = 6,
            LVP_GROUPHEADERLINE = 7,
            LVP_EXPANDBUTTON = 8,
            LVP_COLLAPSEBUTTON = 9,
            LVP_COLUMNDETAIL = 10,
        }

        public enum LISTITEMSTATES
        {
            LISS_NORMAL = 1,
            LISS_HOT = 2,
            LISS_SELECTED = 3,
            LISS_DISABLED = 4,
            LISS_SELECTEDNOTFOCUS = 5,
            LISS_HOTSELECTED = 6,
        }

        public enum GROUPHEADERSTATES
        {
            LVGH_OPEN = 1,
            LVGH_OPENHOT = 2,
            LVGH_OPENSELECTED = 3,
            LVGH_OPENSELECTEDHOT = 4,
            LVGH_OPENSELECTEDNOTFOCUSED = 5,
            LVGH_OPENSELECTEDNOTFOCUSEDHOT = 6,
            LVGH_OPENMIXEDSELECTION = 7,
            LVGH_OPENMIXEDSELECTIONHOT = 8,
            LVGH_CLOSE = 9,
            LVGH_CLOSEHOT = 10,
            LVGH_CLOSESELECTED = 11,
            LVGH_CLOSESELECTEDHOT = 12,
            LVGH_CLOSESELECTEDNOTFOCUSED = 13,
            LVGH_CLOSESELECTEDNOTFOCUSEDHOT = 14,
            LVGH_CLOSEMIXEDSELECTION = 15,
            LVGH_CLOSEMIXEDSELECTIONHOT = 16,
        }

        public enum GROUPHEADERLINESTATES
        {
            LVGHL_OPEN = 1,
            LVGHL_OPENHOT = 2,
            LVGHL_OPENSELECTED = 3,
            LVGHL_OPENSELECTEDHOT = 4,
            LVGHL_OPENSELECTEDNOTFOCUSED = 5,
            LVGHL_OPENSELECTEDNOTFOCUSEDHOT = 6,
            LVGHL_OPENMIXEDSELECTION = 7,
            LVGHL_OPENMIXEDSELECTIONHOT = 8,
            LVGHL_CLOSE = 9,
            LVGHL_CLOSEHOT = 10,
            LVGHL_CLOSESELECTED = 11,
            LVGHL_CLOSESELECTEDHOT = 12,
            LVGHL_CLOSESELECTEDNOTFOCUSED = 13,
            LVGHL_CLOSESELECTEDNOTFOCUSEDHOT = 14,
            LVGHL_CLOSEMIXEDSELECTION = 15,
            LVGHL_CLOSEMIXEDSELECTIONHOT = 16,
        }

        public enum EXPANDBUTTONSTATES
        {
            LVEB_NORMAL = 1,
            LVEB_HOVER = 2,
            LVEB_PUSHED = 3,
        }

        public enum COLLAPSEBUTTONSTATES
        {
            LVCB_NORMAL = 1,
            LVCB_HOVER = 2,
            LVCB_PUSHED = 3,
        }

        #endregion

        #region MENUSTYLE class parts and states

        public enum MENUPARTS
        {
            MENU_MENUITEM_TMSCHEMA = 1,
            MENU_MENUDROPDOWN_TMSCHEMA = 2,
            MENU_MENUBARITEM_TMSCHEMA = 3,
            MENU_MENUBARDROPDOWN_TMSCHEMA = 4,
            MENU_CHEVRON_TMSCHEMA = 5,
            MENU_SEPARATOR_TMSCHEMA = 6,
            MENU_BARBACKGROUND = 7,
            MENU_BARITEM = 8,
            MENU_POPUPBACKGROUND = 9,
            MENU_POPUPBORDERS = 10,
            MENU_POPUPCHECK = 11,
            MENU_POPUPCHECKBACKGROUND = 12,
            MENU_POPUPGUTTER = 13,
            MENU_POPUPITEM = 14,
            MENU_POPUPSEPARATOR = 15,
            MENU_POPUPSUBMENU = 16,
            MENU_SYSTEMCLOSE = 17,
            MENU_SYSTEMMAXIMIZE = 18,
            MENU_SYSTEMMINIMIZE = 19,
            MENU_SYSTEMRESTORE = 20,
        }

        public enum BARBACKGROUNDSTATES
        {
            MB_ACTIVE = 1,
            MB_INACTIVE = 2,
        }

        public enum BARITEMSTATES
        {
            MBI_NORMAL = 1,
            MBI_HOT = 2,
            MBI_PUSHED = 3,
            MBI_DISABLED = 4,
            MBI_DISABLEDHOT = 5,
            MBI_DISABLEDPUSHED = 6,
        }

        public enum POPUPCHECKSTATES
        {
            MC_CHECKMARKNORMAL = 1,
            MC_CHECKMARKDISABLED = 2,
            MC_BULLETNORMAL = 3,
            MC_BULLETDISABLED = 4,
        }

        public enum POPUPCHECKBACKGROUNDSTATES
        {
            MCB_DISABLED = 1,
            MCB_NORMAL = 2,
            MCB_BITMAP = 3,
        }

        public enum POPUPITEMSTATES
        {
            MPI_NORMAL = 1,
            MPI_HOT = 2,
            MPI_DISABLED = 3,
            MPI_DISABLEDHOT = 4,
        }

        public enum POPUPSUBMENUSTATES
        {
            MSM_NORMAL = 1,
            MSM_DISABLED = 2,
        }

        public enum SYSTEMCLOSESTATES
        {
            MSYSC_NORMAL = 1,
            MSYSC_DISABLED = 2,
        }

        public enum SYSTEMMAXIMIZESTATES
        {
            MSYSMX_NORMAL = 1,
            MSYSMX_DISABLED = 2,
        }

        public enum SYSTEMMINIMIZESTATES
        {
            MSYSMN_NORMAL = 1,
            MSYSMN_DISABLED = 2,
        }

        public enum SYSTEMRESTORESTATES
        {
            MSYSR_NORMAL = 1,
            MSYSR_DISABLED = 2,
        }

        #endregion

        #region NAVIGATION class parts and states

        public enum NAVIGATIONPARTS
        {
            NAV_BACKBUTTON = 1,
            NAV_FORWARDBUTTON = 2,
            NAV_MENUBUTTON = 3,
        }

        public enum NAV_BACKBUTTONSTATES
        {
            NAV_BB_NORMAL = 1,
            NAV_BB_HOT = 2,
            NAV_BB_PRESSED = 3,
            NAV_BB_DISABLED = 4,
        }

        public enum NAV_FORWARDBUTTONSTATES
        {
            NAV_FB_NORMAL = 1,
            NAV_FB_HOT = 2,
            NAV_FB_PRESSED = 3,
            NAV_FB_DISABLED = 4,
        }

        public enum NAV_MENUBUTTONSTATES
        {
            NAV_MB_NORMAL = 1,
            NAV_MB_HOT = 2,
            NAV_MB_PRESSED = 3,
            NAV_MB_DISABLED = 4,
        }

        #endregion

        #region PROGRESSSTYLE class parts and states

        public enum PROGRESSPARTS
        {
            PP_BAR = 1,
            PP_BARVERT = 2,
            PP_CHUNK = 3,
            PP_CHUNKVERT = 4,
            PP_FILL = 5,
            PP_FILLVERT = 6,
            PP_PULSEOVERLAY = 7,
            PP_MOVEOVERLAY = 8,
            PP_PULSEOVERLAYVERT = 9,
            PP_MOVEOVERLAYVERT = 10,
            PP_TRANSPARENTBAR = 11,
            PP_TRANSPARENTBARVERT = 12,
        }

        public enum TRANSPARENTBARSTATES
        {
            PBBS_NORMAL = 1,
            PBBS_PARTIAL = 2,
        }

        public enum TRANSPARENTBARVERTSTATES
        {
            PBBVS_NORMAL = 1,
            PBBVS_PARTIAL = 2,
        }

        public enum FILLSTATES
        {
            PBFS_NORMAL = 1,
            PBFS_ERROR = 2,
            PBFS_PAUSED = 3,
            PBFS_PARTIAL = 4,
        }

        public enum FILLVERTSTATES
        {
            PBFVS_NORMAL = 1,
            PBFVS_ERROR = 2,
            PBFVS_PAUSED = 3,
            PBFVS_PARTIAL = 4,
        }

        #endregion

        #region REBARSTYLE class parts and states

        public enum REBARPARTS
        {
            RP_GRIPPER = 1,
            RP_GRIPPERVERT = 2,
            RP_BAND = 3,
            RP_CHEVRON = 4,
            RP_CHEVRONVERT = 5,
            RP_BACKGROUND = 6,
            RP_SPLITTER = 7,
            RP_SPLITTERVERT = 8,
        }

        public enum CHEVRONSTATES
        {
            CHEVS_NORMAL = 1,
            CHEVS_HOT = 2,
            CHEVS_PRESSED = 3,
        }

        public enum CHEVRONVERTSTATES
        {
            CHEVSV_NORMAL = 1,
            CHEVSV_HOT = 2,
            CHEVSV_PRESSED = 3,
        }

        public enum SPLITTERSTATES
        {
            SPLITS_NORMAL = 1,
            SPLITS_HOT = 2,
            SPLITS_PRESSED = 3,
        }

        public enum SPLITTERVERTSTATES
        {
            SPLITSV_NORMAL = 1,
            SPLITSV_HOT = 2,
            SPLITSV_PRESSED = 3,
        }

        #endregion

        #region SCROLLBARSTYLE class parts and states

        public enum SCROLLBARPARTS
        {
            SBP_ARROWBTN = 1,
            SBP_THUMBBTNHORZ = 2,
            SBP_THUMBBTNVERT = 3,
            SBP_LOWERTRACKHORZ = 4,
            SBP_UPPERTRACKHORZ = 5,
            SBP_LOWERTRACKVERT = 6,
            SBP_UPPERTRACKVERT = 7,
            SBP_GRIPPERHORZ = 8,
            SBP_GRIPPERVERT = 9,
            SBP_SIZEBOX = 10,
        }

        public enum ARROWBTNSTATES
        {
            ABS_UPNORMAL = 1,
            ABS_UPHOT = 2,
            ABS_UPPRESSED = 3,
            ABS_UPDISABLED = 4,
            ABS_DOWNNORMAL = 5,
            ABS_DOWNHOT = 6,
            ABS_DOWNPRESSED = 7,
            ABS_DOWNDISABLED = 8,
            ABS_LEFTNORMAL = 9,
            ABS_LEFTHOT = 10,
            ABS_LEFTPRESSED = 11,
            ABS_LEFTDISABLED = 12,
            ABS_RIGHTNORMAL = 13,
            ABS_RIGHTHOT = 14,
            ABS_RIGHTPRESSED = 15,
            ABS_RIGHTDISABLED = 16,
            ABS_UPHOVER = 17,
            ABS_DOWNHOVER = 18,
            ABS_LEFTHOVER = 19,
            ABS_RIGHTHOVER = 20,
        }

        public enum SCROLLBARSTYLESTATES
        {
            SCRBS_NORMAL = 1,
            SCRBS_HOT = 2,
            SCRBS_PRESSED = 3,
            SCRBS_DISABLED = 4,
            SCRBS_HOVER = 5,
        }

        public enum SIZEBOXSTATES
        {
            SZB_RIGHTALIGN = 1,
            SZB_LEFTALIGN = 2,
            SZB_TOPRIGHTALIGN = 3,
            SZB_TOPLEFTALIGN = 4,
            SZB_HALFBOTTOMRIGHTALIGN = 5,
            SZB_HALFBOTTOMLEFTALIGN = 6,
            SZB_HALFTOPRIGHTALIGN = 7,
            SZB_HALFTOPLEFTALIGN = 8,
        }

        #endregion

        #region SPINSTYLE class parts and states

        public enum SPINPARTS
        {
            SPNP_UP = 1,
            SPNP_DOWN = 2,
            SPNP_UPHORZ = 3,
            SPNP_DOWNHORZ = 4,
        }

        public enum UPSTATES
        {
            UPS_NORMAL = 1,
            UPS_HOT = 2,
            UPS_PRESSED = 3,
            UPS_DISABLED = 4,
        }

        public enum DOWNSTATES
        {
            DNS_NORMAL = 1,
            DNS_HOT = 2,
            DNS_PRESSED = 3,
            DNS_DISABLED = 4,
        }

        public enum UPHORZSTATES
        {
            UPHZS_NORMAL = 1,
            UPHZS_HOT = 2,
            UPHZS_PRESSED = 3,
            UPHZS_DISABLED = 4,
        }

        public enum DOWNHORZSTATES
        {
            DNHZS_NORMAL = 1,
            DNHZS_HOT = 2,
            DNHZS_PRESSED = 3,
            DNHZS_DISABLED = 4,
        }

        #endregion

        #region STATUSSTYLE class parts and states

        public enum STATUSPARTS
        {
            SP_PANE = 1,
            SP_GRIPPERPANE = 2,
            SP_GRIPPER = 3,
        }

        #endregion

        #region TABSTYLE class parts and states

        public enum TABPARTS
        {
            TABP_TABITEM = 1,
            TABP_TABITEMLEFTEDGE = 2,
            TABP_TABITEMRIGHTEDGE = 3,
            TABP_TABITEMBOTHEDGE = 4,
            TABP_TOPTABITEM = 5,
            TABP_TOPTABITEMLEFTEDGE = 6,
            TABP_TOPTABITEMRIGHTEDGE = 7,
            TABP_TOPTABITEMBOTHEDGE = 8,
            TABP_PANE = 9,
            TABP_BODY = 10,
            TABP_AEROWIZARDBODY = 11,
        }

        public enum TABITEMSTATES
        {
            TIS_NORMAL = 1,
            TIS_HOT = 2,
            TIS_SELECTED = 3,
            TIS_DISABLED = 4,
            TIS_FOCUSED = 5,
        }

        public enum TABITEMLEFTEDGESTATES
        {
            TILES_NORMAL = 1,
            TILES_HOT = 2,
            TILES_SELECTED = 3,
            TILES_DISABLED = 4,
            TILES_FOCUSED = 5,
        }

        public enum TABITEMRIGHTEDGESTATES
        {
            TIRES_NORMAL = 1,
            TIRES_HOT = 2,
            TIRES_SELECTED = 3,
            TIRES_DISABLED = 4,
            TIRES_FOCUSED = 5,
        }

        public enum TABITEMBOTHEDGESTATES
        {
            TIBES_NORMAL = 1,
            TIBES_HOT = 2,
            TIBES_SELECTED = 3,
            TIBES_DISABLED = 4,
            TIBES_FOCUSED = 5,
        }

        public enum TOPTABITEMSTATES
        {
            TTIS_NORMAL = 1,
            TTIS_HOT = 2,
            TTIS_SELECTED = 3,
            TTIS_DISABLED = 4,
            TTIS_FOCUSED = 5,
        }

        public enum TOPTABITEMLEFTEDGESTATES
        {
            TTILES_NORMAL = 1,
            TTILES_HOT = 2,
            TTILES_SELECTED = 3,
            TTILES_DISABLED = 4,
            TTILES_FOCUSED = 5,
        }

        public enum TOPTABITEMRIGHTEDGESTATES
        {
            TTIRES_NORMAL = 1,
            TTIRES_HOT = 2,
            TTIRES_SELECTED = 3,
            TTIRES_DISABLED = 4,
            TTIRES_FOCUSED = 5,
        }

        public enum TOPTABITEMBOTHEDGESTATES
        {
            TTIBES_NORMAL = 1,
            TTIBES_HOT = 2,
            TTIBES_SELECTED = 3,
            TTIBES_DISABLED = 4,
            TTIBES_FOCUSED = 5,
        }

        #endregion

        #region TASKDIALOGSTYLE class parts and states

        public enum TASKDIALOGPARTS
        {
            TDLG_PRIMARYPANEL = 1,
            TDLG_MAININSTRUCTIONPANE = 2,
            TDLG_MAINICON = 3,
            TDLG_CONTENTPANE = 4,
            TDLG_CONTENTICON = 5,
            TDLG_EXPANDEDCONTENT = 6,
            TDLG_COMMANDLINKPANE = 7,
            TDLG_SECONDARYPANEL = 8,
            TDLG_CONTROLPANE = 9,
            TDLG_BUTTONSECTION = 10,
            TDLG_BUTTONWRAPPER = 11,
            TDLG_EXPANDOTEXT = 12,
            TDLG_EXPANDOBUTTON = 13,
            TDLG_VERIFICATIONTEXT = 14,
            TDLG_FOOTNOTEPANE = 15,
            TDLG_FOOTNOTEAREA = 16,
            TDLG_FOOTNOTESEPARATOR = 17,
            TDLG_EXPANDEDFOOTERAREA = 18,
            TDLG_PROGRESSBAR = 19,
            TDLG_IMAGEALIGNMENT = 20,
            TDLG_RADIOBUTTONPANE = 21,
        }

        public enum CONTENTPANESTATES
        {
            TDLGCPS_STANDALONE = 1,
        }

        public enum EXPANDOBUTTONSTATES
        {
            TDLGEBS_NORMAL = 1,
            TDLGEBS_HOVER = 2,
            TDLGEBS_PRESSED = 3,
            TDLGEBS_EXPANDEDNORMAL = 4,
            TDLGEBS_EXPANDEDHOVER = 5,
            TDLGEBS_EXPANDEDPRESSED = 6,
        }

        #endregion

        #region TEXTSTYLE class parts and states

        public enum TEXTSTYLEPARTS
        {
            TEXT_MAININSTRUCTION = 1,
            TEXT_INSTRUCTION = 2,
            TEXT_BODYTITLE = 3,
            TEXT_BODYTEXT = 4,
            TEXT_SECONDARYTEXT = 5,
            TEXT_HYPERLINKTEXT = 6,
            TEXT_EXPANDED = 7,
            TEXT_LABEL = 8,
            TEXT_CONTROLLABEL = 9,
        }

        public enum HYPERLINKTEXTSTATES
        {
            TS_HYPERLINK_NORMAL = 1,
            TS_HYPERLINK_HOT = 2,
            TS_HYPERLINK_PRESSED = 3,
            TS_HYPERLINK_DISABLED = 4,
        }

        public enum CONTROLLABELSTATES
        {
            TS_CONTROLLABEL_NORMAL = 1,
            TS_CONTROLLABEL_DISABLED = 2,
        }

        #endregion

        #region TOOLBARSTYLE class parts and states

        public enum TOOLBARPARTS
        {
            TP_BUTTON = 1,
            TP_DROPDOWNBUTTON = 2,
            TP_SPLITBUTTON = 3,
            TP_SPLITBUTTONDROPDOWN = 4,
            TP_SEPARATOR = 5,
            TP_SEPARATORVERT = 6,
        }

        public enum TOOLBARSTYLESTATES
        {
            TS_NORMAL = 1,
            TS_HOT = 2,
            TS_PRESSED = 3,
            TS_DISABLED = 4,
            TS_CHECKED = 5,
            TS_HOTCHECKED = 6,
            TS_NEARHOT = 7,
            TS_OTHERSIDEHOT = 8,
        }

        #endregion

        #region TOOLTIPSTYLE class parts and states

        public enum TOOLTIPPARTS
        {
            TTP_STANDARD = 1,
            TTP_STANDARDTITLE = 2,
            TTP_BALLOON = 3,
            TTP_BALLOONTITLE = 4,
            TTP_CLOSE = 5,
            TTP_BALLOONSTEM = 6,
        }

        public enum CLOSESTATES
        {
            TTCS_NORMAL = 1,
            TTCS_HOT = 2,
            TTCS_PRESSED = 3,
        }

        public enum STANDARDSTATES
        {
            TTSS_NORMAL = 1,
            TTSS_LINK = 2,
        }

        public enum BALLOONSTATES
        {
            TTBS_NORMAL = 1,
            TTBS_LINK = 2,
        }

        public enum BALLOONSTEMSTATES
        {
            TTBSS_POINTINGUPLEFTWALL = 1,
            TTBSS_POINTINGUPCENTERED = 2,
            TTBSS_POINTINGUPRIGHTWALL = 3,
            TTBSS_POINTINGDOWNRIGHTWALL = 4,
            TTBSS_POINTINGDOWNCENTERED = 5,
            TTBSS_POINTINGDOWNLEFTWALL = 6,
        }

        #endregion

        #region TRACKBARSTYLE class parts and states

        public enum TRACKBARPARTS
        {
            TKP_TRACK = 1,
            TKP_TRACKVERT = 2,
            TKP_THUMB = 3,
            TKP_THUMBBOTTOM = 4,
            TKP_THUMBTOP = 5,
            TKP_THUMBVERT = 6,
            TKP_THUMBLEFT = 7,
            TKP_THUMBRIGHT = 8,
            TKP_TICS = 9,
            TKP_TICSVERT = 10,
        }

        public enum TRACKBARSTYLESTATES
        {
            TKS_NORMAL = 1,
        }

        public enum TRACKSTATES
        {
            TRS_NORMAL = 1,
        }

        public enum TRACKVERTSTATES
        {
            TRVS_NORMAL = 1,
        }

        public enum THUMBSTATES
        {
            TUS_NORMAL = 1,
            TUS_HOT = 2,
            TUS_PRESSED = 3,
            TUS_FOCUSED = 4,
            TUS_DISABLED = 5,
        }

        public enum THUMBBOTTOMSTATES
        {
            TUBS_NORMAL = 1,
            TUBS_HOT = 2,
            TUBS_PRESSED = 3,
            TUBS_FOCUSED = 4,
            TUBS_DISABLED = 5,
        }

        public enum THUMBTOPSTATES
        {
            TUTS_NORMAL = 1,
            TUTS_HOT = 2,
            TUTS_PRESSED = 3,
            TUTS_FOCUSED = 4,
            TUTS_DISABLED = 5,
        }

        public enum THUMBVERTSTATES
        {
            TUVS_NORMAL = 1,
            TUVS_HOT = 2,
            TUVS_PRESSED = 3,
            TUVS_FOCUSED = 4,
            TUVS_DISABLED = 5,
        }

        public enum THUMBLEFTSTATES
        {
            TUVLS_NORMAL = 1,
            TUVLS_HOT = 2,
            TUVLS_PRESSED = 3,
            TUVLS_FOCUSED = 4,
            TUVLS_DISABLED = 5,
        }

        public enum THUMBRIGHTSTATES
        {
            TUVRS_NORMAL = 1,
            TUVRS_HOT = 2,
            TUVRS_PRESSED = 3,
            TUVRS_FOCUSED = 4,
            TUVRS_DISABLED = 5,
        }

        public enum TICSSTATES
        {
            TSS_NORMAL = 1,
        }

        public enum TICSVERTSTATES
        {
            TSVS_NORMAL = 1,
        }

        #endregion

        #region TREEVIEWSTYLE class parts and states

        public enum TREEVIEWPARTS
        {
            TVP_TREEITEM = 1,
            TVP_GLYPH = 2,
            TVP_BRANCH = 3,
            TVP_HOTGLYPH = 4,
        }

        public enum TREEITEMSTATES
        {
            TREIS_NORMAL = 1,
            TREIS_HOT = 2,
            TREIS_SELECTED = 3,
            TREIS_DISABLED = 4,
            TREIS_SELECTEDNOTFOCUS = 5,
            TREIS_HOTSELECTED = 6,
        }

        public enum GLYPHSTATES
        {
            GLPS_CLOSED = 1,
            GLPS_OPENED = 2,
        }

        public enum HOTGLYPHSTATES
        {
            HGLPS_CLOSED = 1,
            HGLPS_OPENED = 2,
        }

        #endregion

        #region WINDOWSTYLE class parts and states

        public enum WINDOWPARTS
        {
            WP_CAPTION = 1,
            WP_SMALLCAPTION = 2,
            WP_MINCAPTION = 3,
            WP_SMALLMINCAPTION = 4,
            WP_MAXCAPTION = 5,
            WP_SMALLMAXCAPTION = 6,
            WP_FRAMELEFT = 7,
            WP_FRAMERIGHT = 8,
            WP_FRAMEBOTTOM = 9,
            WP_SMALLFRAMELEFT = 10,
            WP_SMALLFRAMERIGHT = 11,
            WP_SMALLFRAMEBOTTOM = 12,
            WP_SYSBUTTON = 13,
            WP_MDISYSBUTTON = 14,
            WP_MINBUTTON = 15,
            WP_MDIMINBUTTON = 16,
            WP_MAXBUTTON = 17,
            WP_CLOSEBUTTON = 18,
            WP_SMALLCLOSEBUTTON = 19,
            WP_MDICLOSEBUTTON = 20,
            WP_RESTOREBUTTON = 21,
            WP_MDIRESTOREBUTTON = 22,
            WP_HELPBUTTON = 23,
            WP_MDIHELPBUTTON = 24,
            WP_HORZSCROLL = 25,
            WP_HORZTHUMB = 26,
            WP_VERTSCROLL = 27,
            WP_VERTTHUMB = 28,
            WP_DIALOG = 29,
            WP_CAPTIONSIZINGTEMPLATE = 30,
            WP_SMALLCAPTIONSIZINGTEMPLATE = 31,
            WP_FRAMELEFTSIZINGTEMPLATE = 32,
            WP_SMALLFRAMELEFTSIZINGTEMPLATE = 33,
            WP_FRAMERIGHTSIZINGTEMPLATE = 34,
            WP_SMALLFRAMERIGHTSIZINGTEMPLATE = 35,
            WP_FRAMEBOTTOMSIZINGTEMPLATE = 36,
            WP_SMALLFRAMEBOTTOMSIZINGTEMPLATE = 37,
            WP_FRAME = 38,
        }

        public enum FRAMESTATES
        {
            FS_ACTIVE = 1,
            FS_INACTIVE = 2,
        }

        public enum CAPTIONSTATES
        {
            CS_ACTIVE = 1,
            CS_INACTIVE = 2,
            CS_DISABLED = 3,
        }

        public enum MAXCAPTIONSTATES
        {
            MXCS_ACTIVE = 1,
            MXCS_INACTIVE = 2,
            MXCS_DISABLED = 3,
        }

        public enum MINCAPTIONSTATES
        {
            MNCS_ACTIVE = 1,
            MNCS_INACTIVE = 2,
            MNCS_DISABLED = 3,
        }

        public enum HORZSCROLLSTATES
        {
            HSS_NORMAL = 1,
            HSS_HOT = 2,
            HSS_PUSHED = 3,
            HSS_DISABLED = 4,
        }

        public enum HORZTHUMBSTATES
        {
            HTS_NORMAL = 1,
            HTS_HOT = 2,
            HTS_PUSHED = 3,
            HTS_DISABLED = 4,
        }

        public enum VERTSCROLLSTATES
        {
            VSS_NORMAL = 1,
            VSS_HOT = 2,
            VSS_PUSHED = 3,
            VSS_DISABLED = 4,
        }

        public enum VERTTHUMBSTATES
        {
            VTS_NORMAL = 1,
            VTS_HOT = 2,
            VTS_PUSHED = 3,
            VTS_DISABLED = 4,
        }

        public enum SYSBUTTONSTATES
        {
            SBS_NORMAL = 1,
            SBS_HOT = 2,
            SBS_PUSHED = 3,
            SBS_DISABLED = 4,
        }

        public enum MINBUTTONSTATES
        {
            MINBS_NORMAL = 1,
            MINBS_HOT = 2,
            MINBS_PUSHED = 3,
            MINBS_DISABLED = 4,
        }

        public enum MAXBUTTONSTATES
        {
            MAXBS_NORMAL = 1,
            MAXBS_HOT = 2,
            MAXBS_PUSHED = 3,
            MAXBS_DISABLED = 4,
        }

        public enum RESTOREBUTTONSTATES
        {
            RBS_NORMAL = 1,
            RBS_HOT = 2,
            RBS_PUSHED = 3,
            RBS_DISABLED = 4,
        }

        public enum HELPBUTTONSTATES
        {
            HBS_NORMAL = 1,
            HBS_HOT = 2,
            HBS_PUSHED = 3,
            HBS_DISABLED = 4,
        }

        public enum CLOSEBUTTONSTATES
        {
            CBS_NORMAL = 1,
            CBS_HOT = 2,
            CBS_PUSHED = 3,
            CBS_DISABLED = 4,
        }

        #endregion
    }
}
