using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;

namespace wumgr
{
    public class ListViewExtended : ListView
    {
        private const int LVM_FIRST = 0x1000;
        private const int LVM_SETGROUPINFO = (LVM_FIRST + 147);
        private const int WM_LBUTTONUP = 0x0202;

        private delegate void CallBackSetGroupState(ListViewGroup lstvwgrp, ListViewGroupState state);
        private delegate void CallbackSetGroupString(ListViewGroup lstvwgrp, string value);

        [DllImport("User32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        private static int? GetGroupID(ListViewGroup lstvwgrp)
        {
            PropertyInfo pi = lstvwgrp.GetType().GetProperty("ID", BindingFlags.NonPublic | BindingFlags.Instance);
            if (pi != null)
            {
                object val = pi.GetValue(lstvwgrp, null);
                if (val != null)
                    return val as int?;
            }
            return null;
        }

        public static void setGrpState(ListViewGroup lstvwgrp, ListViewGroupState state)
        {
            if (lstvwgrp == null || lstvwgrp.ListView == null)
                return;
            if (lstvwgrp.ListView.InvokeRequired)
            {
                lstvwgrp.ListView.Invoke(new CallBackSetGroupState(setGrpState), lstvwgrp, state);
                return;
            }

            int? GrpId = GetGroupID(lstvwgrp);
            int gIndex = lstvwgrp.ListView.Groups.IndexOf(lstvwgrp);
            LVGROUP group = new LVGROUP();
            group.CbSize = Marshal.SizeOf(group);
            group.State = state;
            group.Mask = ListViewGroupMask.State;
            group.IGroupId = GrpId ?? gIndex;

            IntPtr ip = IntPtr.Zero;
            try
            {
                ip = Marshal.AllocHGlobal(group.CbSize);
                Marshal.StructureToPtr(group, ip, false);
                IntPtr id = (IntPtr)group.IGroupId;
                SendMessage(lstvwgrp.ListView.Handle, LVM_SETGROUPINFO, id, ip);
                SendMessage(lstvwgrp.ListView.Handle, LVM_SETGROUPINFO, id, ip);
                lstvwgrp.ListView.Refresh();
            }
            catch (Exception ex)
            {
                AppLog.Line("setGrpState error: {0}", ex.Message);
            }
            finally
            {
                if (ip != IntPtr.Zero) Marshal.FreeHGlobal(ip);
            }
        }

        public static void setGrpFooter(ListViewGroup lstvwgrp, string footer)
        {
            if (lstvwgrp == null || lstvwgrp.ListView == null)
                return;
            if (lstvwgrp.ListView.InvokeRequired)
            {
                lstvwgrp.ListView.Invoke(new CallbackSetGroupString(setGrpFooter), lstvwgrp, footer);
                return;
            }

            int? GrpId = GetGroupID(lstvwgrp);
            int gIndex = lstvwgrp.ListView.Groups.IndexOf(lstvwgrp);
            LVGROUP group = new LVGROUP();
            group.CbSize = Marshal.SizeOf(group);
            group.PszFooter = footer;
            group.Mask = ListViewGroupMask.Footer;
            group.IGroupId = GrpId ?? gIndex;

            IntPtr ip = IntPtr.Zero;
            try
            {
                ip = Marshal.AllocHGlobal(group.CbSize);
                Marshal.StructureToPtr(group, ip, false);
                SendMessage(lstvwgrp.ListView.Handle, LVM_SETGROUPINFO, (IntPtr)group.IGroupId, ip);
            }
            catch (Exception ex)
            {
                AppLog.Line("setGrpFooter error: {0}", ex.Message);
            }
            finally
            {
                if (ip != IntPtr.Zero) Marshal.FreeHGlobal(ip);
            }
        }

        public void SetGroupState(ListViewGroupState state)
        {
            foreach (ListViewGroup lvg in this.Groups)
                setGrpState(lvg, state);
        }

        public void SetGroupFooter(ListViewGroup lvg, string footerText)
        {
            setGrpFooter(lvg, footerText);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONUP)
            {
                base.DefWndProc(ref m);
                return;
            }
            base.WndProc(ref m);
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct LVGROUP
    {
        public int CbSize;
        public ListViewGroupMask Mask;
        [MarshalAs(UnmanagedType.LPWStr)] public string PszHeader;
        public int CchHeader;
        [MarshalAs(UnmanagedType.LPWStr)] public string PszFooter;
        public int CchFooter;
        public int IGroupId;
        public int StateMask;
        public ListViewGroupState State;
        public uint UAlign;
        public IntPtr PszSubtitle;
        public uint CchSubtitle;
        [MarshalAs(UnmanagedType.LPWStr)] public string PszTask;
        public uint CchTask;
        [MarshalAs(UnmanagedType.LPWStr)] public string PszDescriptionTop;
        public uint CchDescriptionTop;
        [MarshalAs(UnmanagedType.LPWStr)] public string PszDescriptionBottom;
        public uint CchDescriptionBottom;
        public int ITitleImage;
        public int IExtendedImage;
        public int IFirstItem;
        public IntPtr CItems;
        public IntPtr PszSubsetTitle;
        public IntPtr CchSubsetTitle;
    }

    public enum ListViewGroupMask
    {
        None             = 0x00000,
        Header           = 0x00001,
        Footer           = 0x00002,
        State            = 0x00004,
        Align            = 0x00008,
        GroupId          = 0x00010,
        SubTitle         = 0x00100,
        Task             = 0x00200,
        DescriptionTop   = 0x00400,
        DescriptionBottom= 0x00800,
        TitleImage       = 0x01000,
        ExtendedImage    = 0x02000,
        Items            = 0x04000,
        Subset           = 0x08000,
        SubsetItems      = 0x10000
    }

    public enum ListViewGroupState
    {
        Normal           = 0,
        Collapsed        = 1,
        Hidden           = 2,
        NoHeader         = 4,
        Collapsible      = 8,
        Focused          = 16,
        Selected         = 32,
        SubSeted         = 64,
        SubSetLinkFocused= 128,
    }
}
