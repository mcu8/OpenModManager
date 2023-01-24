using CUFramework.Windows;
using ModdingTools.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace ModdingTools.Windows
{
    public partial class WorkshopLocker : CUWindow
    {
        public WorkshopLocker()
        {
            InitializeComponent();
            UpdateState();
        }

        private void UpdateState()
        {
            var wsDir = GameFinder.GetWorkshopDir();
            if (!Directory.Exists(wsDir))
                Directory.CreateDirectory(wsDir);
            DirectoryInfo dInfo = new DirectoryInfo(wsDir);
            try
            {
                dInfo.GetFiles();
                label1.Text = "UNLOCKED";
                label1.ForeColor = Color.Green;
            }
            catch (UnauthorizedAccessException ex)
            {
                label1.Text = "LOCKED";
                label1.ForeColor = Color.Red;
            }
        }


        public void ChangeLockState(string path, bool unlocked)
        {
            DirectoryInfo dInfo = new DirectoryInfo(path);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();

            var rule = new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                FileSystemRights.Write | FileSystemRights.ReadAndExecute | FileSystemRights.ListDirectory, InheritanceFlags.None,
                PropagationFlags.NoPropagateInherit, AccessControlType.Deny);

            if (unlocked)
            {
                dSecurity.RemoveAccessRule(rule);
            }
            else
            {
                dSecurity.AddAccessRule(rule);
            }
            dInfo.SetAccessControl(dSecurity);

            UpdateState();
        }

        private void mButton2_Click(object sender, EventArgs e)
        {
            var wsDir = GameFinder.GetWorkshopDir();
            if (!Directory.Exists(wsDir))
                Directory.CreateDirectory(wsDir);

            ChangeLockState(wsDir, false);
        }

        private void cuButton1_Click(object sender, EventArgs e)
        {
            var wsDir = GameFinder.GetWorkshopDir();
            if (!Directory.Exists(wsDir))
                Directory.CreateDirectory(wsDir);

            ChangeLockState(wsDir, true);
        }
    }
}
