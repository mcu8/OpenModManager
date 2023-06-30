using CUFramework.Dialogs;
using CUFramework.Windows;
using ModdingTools.Engine;
using System;
using System.Drawing;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

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
                var testFile = Path.Combine(wsDir, ".test");
                File.WriteAllText(testFile, "test");
                File.Delete(testFile);
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
            try
            {
                RemoveOldProtection(path);
                var x = path + ".disabled";
                if (unlocked && Directory.Exists(x))
                {
                    ApplyProtection(path, false);
                    Directory.Delete(path, false);
                    Directory.Move(x, path);
                }
                else if (!unlocked && !Directory.Exists(x))
                {
                    Directory.Move(path, x);
                    Directory.CreateDirectory(path);
                    ApplyProtection(path, true);
                }
            }
            catch (Exception e)
            {
                CUMessageBox.Show(e.Message);
            }
            UpdateState();
        }

        public void RemoveOldProtection(string path)
        {
            // for compatibilty with old algo
            DirectoryInfo dInfo = new DirectoryInfo(path);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            var rule = new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null),
            FileSystemRights.Write | FileSystemRights.ReadAndExecute | FileSystemRights.ListDirectory, InheritanceFlags.None,
            PropagationFlags.NoPropagateInherit, AccessControlType.Deny);
            dSecurity.RemoveAccessRule(rule);
            dInfo.SetAccessControl(dSecurity);
        }


        public void ApplyProtection(string path, bool v)
        {
            DirectoryInfo dInfo = new DirectoryInfo(path);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            var rule = new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null),
            FileSystemRights.Write, InheritanceFlags.None,
            PropagationFlags.NoPropagateInherit, AccessControlType.Deny);
            if(v)
            {
                dSecurity.AddAccessRule(rule);
            }
            else
            {
                dSecurity.RemoveAccessRule(rule);
            }
            dInfo.SetAccessControl(dSecurity);
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
