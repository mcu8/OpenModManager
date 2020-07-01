using ModdingTools.Modding;
using Steamworks;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

// partially based on https://github.com/Doreamonsky/workshop-uploader
namespace ModdingTools.UEngine
{
    public class ModUploader
    {
        protected static CallResult<CreateItemResult_t> m_itemCreated;
        protected static CallResult<SubmitItemUpdateResult_t> m_itemSubmitted;
        protected static UGCUpdateHandle_t ugcUpdateHandle = UGCUpdateHandle_t.Invalid;

        protected static ulong publishID = 0;
        protected static string Message;

        protected bool isRunning = false;

        public void UploadModAsync(ModObject mod, string changelog, string[] tags, bool keepCooked, bool keepScripts, int visibility)
        {
            Task.Factory.StartNew(() =>
            {
                UploadMod(mod, changelog, tags, keepCooked, keepScripts, visibility);
            });
        }

        public void UploadMod(ModObject mod, string changelog, string[] tags, bool keepUnCooked, bool keepScripts, int visibility)
        {
            if (isRunning)
            {
                MainWindow.Instance.Invoke(new MethodInvoker(() => {
                    MessageBox.Show(MainWindow.Instance, "Only one uploader instance can run at once!");
                }));
                return;
            }

            isRunning = true;
            try
            {
                ERemoteStoragePublishedFileVisibility fileVisibility 
                    = (ERemoteStoragePublishedFileVisibility)Enum.ToObject(typeof(ERemoteStoragePublishedFileVisibility), visibility); ;

                mod.Refresh();
                SetStatus("Preparing the uploader...");
                var tmpDir = Path.Combine(Program.GetAppRoot(), "uploader_tmp");
                if (Directory.Exists(tmpDir))
                    Directory.Delete(tmpDir, true);
                Directory.CreateDirectory(tmpDir);

                Utils.DirectoryCopy(mod.RootPath, "uploader_tmp", true);
                if (!keepScripts)
                {
                    Directory.Delete(Path.Combine("uploader_tmp", "CompiledScripts"), true);
                    Directory.Delete(Path.Combine("uploader_tmp", "Classes"), true);
                }

                if (!keepUnCooked)
                {
                    Directory.Delete(Path.Combine("uploader_tmp", "Maps"), true);
                    Directory.Delete(Path.Combine("uploader_tmp", "Localization"), true);
                }

                var description = mod.GetDescription();

                var modid = mod.GetUploadedId();

                SetStatus("Creating callback...");

                m_itemCreated = CallResult<CreateItemResult_t>.Create(OnItemCreated);

                var appId = new AppId_t(uint.Parse(GameFinder.AppID));

                if (modid == 0)
                {
                    SteamAPICall_t call = SteamUGC.CreateItem(appId, EWorkshopFileType.k_EWorkshopFileTypeCommunity);
                    m_itemCreated.Set(call);
                }
                else
                {
                    publishID = modid;
                }
                while (publishID == 0)
                {
                    SteamAPI.RunCallbacks();
                    Thread.Sleep(1000);
                }

                Thread.Sleep(1000);

                if (modid == 0)
                {
                    SetStatus("Uploading an new mod " + mod.Name + " with WorkshopID: " + publishID);
                    mod.SetUploadedId(publishID);
                }
                else
                {
                    SetStatus("Updating an mod " + mod.Name + " with WorkshopID: " + publishID);
                }
                var publishFileID_t = new PublishedFileId_t(publishID);

                ugcUpdateHandle = SteamUGC.StartItemUpdate(appId, publishFileID_t);

                SteamUGC.SetItemTitle(ugcUpdateHandle, mod.Name);
                SteamUGC.SetItemDescription(ugcUpdateHandle, description);
                SteamUGC.SetItemVisibility(ugcUpdateHandle, fileVisibility);
                if (tags != null)
                {
                    SteamUGC.SetItemTags(ugcUpdateHandle, tags);
                }
                SteamUGC.SetItemPreview(ugcUpdateHandle, Path.Combine(mod.RootPath, mod.Icon));
                SteamUGC.SetItemContent(ugcUpdateHandle, Path.GetFullPath("uploader_tmp"));

                SteamAPICall_t t = SteamUGC.SubmitItemUpdate(ugcUpdateHandle, changelog);
                m_itemSubmitted = CallResult<SubmitItemUpdateResult_t>.Create(OnItemSubmitted);
                m_itemSubmitted.Set(t);

                while (true)
                {
                    Thread.Sleep(1000);

                    if (ugcUpdateHandle == UGCUpdateHandle_t.Invalid)
                    {
                        break;
                    }

                    SteamAPI.RunCallbacks();

                    ulong bytesDone, bytesTotal;

                    EItemUpdateStatus status = SteamUGC.GetItemUpdateProgress(ugcUpdateHandle, out bytesDone, out bytesTotal);

                    SetStatus(string.Format("[{3}%] Status: {0} Done: {1}b Total: {2}b", status, bytesDone, bytesTotal, bytesTotal > 0 ? Math.Floor(((double)bytesDone / (double)bytesTotal) * (double)100) : 100));
                }

                DialogResult res = DialogResult.No;

                MainWindow.Instance.Invoke(new MethodInvoker(() => {
                    res = MessageBox.Show(MainWindow.Instance, "Done, mod url:" + "\nhttps://steamcommunity.com/sharedfiles/filedetails/?id=" + publishID + "\n\nOpen it in the browser?", "Uploader", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (res == DialogResult.Yes)
                    {
                        Process.Start("https://steamcommunity.com/sharedfiles/filedetails/?id=" + publishID);
                    }
                }));

                SetStatus("Item uploaded successfully!");
                Thread.Sleep(1000);
                SetStatus("Cleanup");
                if (Directory.Exists(tmpDir))
                    Directory.Delete(tmpDir, true);

                SetStatus(null);
            }
            catch (Exception e)
            {
                MainWindow.Instance.Invoke(new MethodInvoker(() => {
                    MessageBox.Show(MainWindow.Instance, e.Message + "\n" + e.ToString());
                }));
                isRunning = false;
            }
        }

        private static void SetStatus(string v)
        {
            MainWindow.Instance.SetModListStatus(v);
        }

        private static void OnItemSubmitted(SubmitItemUpdateResult_t param, bool bIOFailure)
        {
            if (bIOFailure)
            {
                SetStatus("Error: I/O Failure!");
                return;
            }

            switch (param.m_eResult)
            {
                case EResult.k_EResultOK:
                    SetStatus("SUCCESS! Item submitted!");
                    ugcUpdateHandle = UGCUpdateHandle_t.Invalid;
                    break;
            }
        }

        private static void OnItemCreated(CreateItemResult_t callBack, bool bIOFailure)
        {
            if (bIOFailure)
            {
                SetStatus("Error: I/O Failure!");
                return;
            }

            switch (callBack.m_eResult)
            {
                case EResult.k_EResultInsufficientPrivilege:
                    SetStatus("Error: Unfortunately, you're banned from uploading to the workshop!");
                    break;
                case EResult.k_EResultTimeout:
                    SetStatus("Error: Timeout");
                    break;
                case EResult.k_EResultNotLoggedOn:
                    SetStatus("Error: You're not logged into Steam!");
                    break;
            }

            if (callBack.m_eResult == EResult.k_EResultOK)
            {
                var callback_publishID = callBack.m_nPublishedFileId;
                publishID = ulong.Parse(callback_publishID.ToString());
                Console.WriteLine(callback_publishID);
            }
        }
    }
}
