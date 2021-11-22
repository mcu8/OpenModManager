using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace ModdingTools.Engine
{

    public class UpdateChecker
    {
        static readonly bool TestMode = false;

        private Action OnUpdateAvaiable;
        private string UpdateUrl;
        private long BuildNumber;

        public UpdateChecker(long buildNumber, string updateUrl, Action onUpdateAvaiable)
        {
            BuildNumber = buildNumber;
            UpdateUrl = updateUrl;
            OnUpdateAvaiable = onUpdateAvaiable;
        }

        public void CheckForUpdatesAsync()
        {
            if (!Properties.Settings.Default.UpdateCheck)
            {
                Debug.WriteLine("Updates disabled");
                return;
            }
            Task.Factory.StartNew(() =>
            {
                try
                {
                    using (var wc = new WebClient())
                    {
                        var remoteVersion = long.Parse(wc.DownloadString(UpdateUrl).Trim());
                        if (remoteVersion > BuildNumber || TestMode)
                        {
                            OnUpdateAvaiable?.Invoke();
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine("!!" + e.Message);
                    Debug.WriteLine("!!" + e.StackTrace);
                }
            });
        }
    }
}
