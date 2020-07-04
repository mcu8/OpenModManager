using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ModdingTools.Engine
{
    public class UpdateChecker
    {
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
            Task.Factory.StartNew(() =>
            {
                try
                {
                    using (var wc = new WebClient())
                    {
                        var remoteVersion = long.Parse(wc.DownloadString(UpdateUrl));
                        if (remoteVersion > BuildNumber)
                        {
                            OnUpdateAvaiable?.Invoke();
                        }
                    }
                }
                catch (Exception e)
                {
                    // just do nothing...
                }
            });
        }
    }
}
