using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModdingTools.Updater
{
    public partial class MainWindow : CUFormEx
    {
        private int CurrentProgress = -1;
        private string CurrentStatus;
        private bool DownloadCompleted;
        private bool IsCancelling = false;
        private bool IsLocked = false;

        public MainWindow()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Shown += MainWindow_Shown;
            label2.MouseDown += HandleDrag;
            timer1.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = CurrentStatus;
            button1.Enabled = !IsLocked;
            if (CurrentProgress >= 0)
            {
                progressBar1.Value = CurrentProgress;
                progressBar1.Style = ProgressBarStyle.Blocks;
            }
            else progressBar1.Style = ProgressBarStyle.Marquee;
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                if (!Debugger.IsAttached)
                {
                    try
                    {
                        RunUpdaterTasks();
                    }
                    catch (Exception ex)
                    {
                        Program.FatalExceptionObject(ex);
                    }
                }
                else
                {
                    RunUpdaterTasks();
                } 
            });
        }

        public void RunUpdaterTasks()
        {
            CurrentStatus = "Killing OMM instances...";
            OMMHelper.KillOMM();

            CurrentStatus = "Downloading update data...";
            var data = OMMHelper.GetUpdateData();

            if (IsCancelling)
            {
                Program.CloseApp(-1);
                return;
            }

            var appRoot = Program.GetAppRoot();
            var updateZipPath = Path.Combine(appRoot, "update.zip");

            CurrentStatus = "Downloading update package...";
            using(var wc = new WebClient())
            {
                wc.Headers.Add("User-agent", "OpenModManager.Updater/1.0");
                if (File.Exists(updateZipPath)) File.Delete(updateZipPath);
                wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
                DownloadCompleted = false;
                wc.DownloadFileAsync(new Uri(data.URL), updateZipPath);
                wc.DownloadFileCompleted += Wc_DownloadFileCompleted;

                while (!DownloadCompleted)
                {
                    if (IsCancelling)
                        wc.CancelAsync();
                    
                }

                if (IsCancelling)
                {
                    if (File.Exists(updateZipPath))
                        File.Delete(updateZipPath);
                    Program.CloseApp(-1);
                    return;
                }

                CurrentProgress = -1;
                IsLocked = true;
                CurrentStatus = "Verifying downloaded package...";
                if (data.Verify(updateZipPath))
                {
                    CurrentStatus = "Extracting downloaded package...";
                    OMMHelper.ExtractZIP(updateZipPath, appRoot);
                    CurrentStatus = "OK!";
                    CurrentProgress = 100;
                    File.Delete(updateZipPath);
                    System.Diagnostics.Process.Start(Path.Combine(appRoot, "ModdingTools.exe"));
                    Program.CloseApp(0);
                }
                else
                {
                    throw new Exception("Checksum verify failed!");
                }
            } 
        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            DownloadCompleted = true;
        }

        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            CurrentProgress = e.ProgressPercentage;
            CurrentStatus = $"Downloading update package... [{e.BytesReceived}/{e.TotalBytesToReceive}]";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsLocked)
                IsCancelling = true;
        }
    }
}
