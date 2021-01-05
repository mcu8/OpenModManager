using CUFramework.Dialogs;
using ModdingTools.Modding;
using ModdingTools.Windows;
using Steamworks;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

// partially based on https://github.com/Doreamonsky/workshop-uploader
namespace ModdingTools.Engine
{
    public class ModUploader
    {
        protected static CallResult<CreateItemResult_t> m_itemCreated;
        protected static CallResult<SubmitItemUpdateResult_t> m_itemSubmitted;
        protected static UGCUpdateHandle_t ugcUpdateHandle = UGCUpdateHandle_t.Invalid;

        protected static ulong publishID = 0;
        protected static string Message;

        public bool IsUploaderRunning { get; protected set; } = false;

        public void UploadModAsync(ModObject mod, string changelog, string[] tags, bool keepCooked, bool keepScripts, int visibility, string description, string iconPath)
        {
            Task.Factory.StartNew(() =>
            {
                MainWindow.Instance.Invoke(new MethodInvoker(() => {
                    ModProperties.TemporaryHideAllPropertiesWindows();
                }));
                UploadMod(mod, changelog, tags, keepCooked, keepScripts, visibility, description, iconPath);
                MainWindow.Instance.Invoke(new MethodInvoker(() => {
                    ModProperties.RestoreTemporaryHiddenPropertiesWindows();
                }));
            });
        }

        public void UploadMod(ModObject mod, string changelog, string[] tags, bool keepUnCooked, bool keepScripts, int visibility, string description, string iconPath)
        {
            if (IsUploaderRunning)
            {
                MainWindow.Instance.Invoke(new MethodInvoker(() => {
                    CUMessageBox.Show(MainWindow.Instance, "Only one uploader instance can run at once!");
                }));
                return;
            }

            Toggle(true);

            success = true;
            IsUploaderRunning = true;
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

                Utils.DirectoryCopy(mod.RootPath, tmpDir, true);
                if (!keepScripts)
                {
                    if (Directory.Exists(Path.Combine(tmpDir, "CompiledScripts")))
                        Directory.Delete(Path.Combine(tmpDir, "CompiledScripts"), true);
                    if (Directory.Exists(Path.Combine(tmpDir, "Classes")))
                        Directory.Delete(Path.Combine(tmpDir, "Classes"), true);
                }

                if (!keepUnCooked)
                {
                    if (Directory.Exists(Path.Combine(tmpDir, "Maps")))
                        Directory.Delete(Path.Combine(tmpDir, "Maps"), true);
                    if (Directory.Exists(Path.Combine(tmpDir, "Content")))
                        Directory.Delete(Path.Combine(tmpDir, "Content"), true);
                }

                //var description = mod.GetDescription();

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
                    SetStatus("Updating the mod " + mod.Name + " with WorkshopID: " + publishID);
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

                SteamUGC.SetItemPreview(ugcUpdateHandle, iconPath);
                SteamUGC.SetItemContent(ugcUpdateHandle, tmpDir);

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
                    if (status == EItemUpdateStatus.k_EItemUpdateStatusInvalid && !success)
                    {
                        break;
                    }


                    var percent = bytesTotal > 0 ? Math.Floor(((double)bytesDone / (double)bytesTotal) * (double)100) : 100;
                    SetStatus(string.Format("[{3}%] Status: {0}    {1}/{2}", TranslateStatus(status), BytesToString(bytesDone), BytesToString(bytesTotal), percent));
                    SetProgress((int)percent);
                }

                DialogResult res = DialogResult.No;

                if (success)
                {
                    MainWindow.Instance.Invoke(new MethodInvoker(() => {
                        res = CUMessageBox.Show(MainWindow.Instance, "Done, mod url:" + "\nhttps://steamcommunity.com/sharedfiles/filedetails/?id=" + publishID + "\n\nOpen it in the browser?", "Uploader", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (res == DialogResult.Yes)
                        {
                            Process.Start("steam://openurl/https://steamcommunity.com/sharedfiles/filedetails/?id=" + publishID);
                        }
                    }));

                    SetStatus("Item uploaded successfully!");
                    Thread.Sleep(1000);
                }

                SetStatus("Cleanup");
                if (Directory.Exists(tmpDir))
                    Directory.Delete(tmpDir, true);

                Toggle(false);

                IsUploaderRunning = false;
            }
            catch (Exception e)
            {
                MainWindow.Instance.Invoke(new MethodInvoker(() => {
                    CUMessageBox.Show(MainWindow.Instance, e.Message + "\n" + e.ToString());
                }));
                IsUploaderRunning = false;
                SetStatus("");
                Toggle(false);
            }
        }

        static string BytesToString(ulong byteCount)
        {
            try
            {
                string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
                if (byteCount == 0)
                    return "0" + suf[0];
                long bytes = Math.Abs((long)byteCount);
                int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
                double num = Math.Round(bytes / Math.Pow(1024, place), 1);
                return (Math.Sign((long)byteCount) * num).ToString() + suf[place];
            }
            catch (Exception e)
            {
                return byteCount + "B";
            }
        }

        private static void SetStatus(string v)
        {
            MainWindow.Instance.GuiWorker.SetStatus(v);
        }

        private static void SetProgress(int v)
        {
            MainWindow.Instance.GuiWorker.SetProgress(v);
        }

        private static void Toggle(bool v)
        {
            MainWindow.Instance.SetCard(!v ? MainWindow.CardControllerTabs.Mods : MainWindow.CardControllerTabs.Worker);
        }

        private static string TranslateStatus(EItemUpdateStatus s)
        {
            switch (s)
            {
                case EItemUpdateStatus.k_EItemUpdateStatusInvalid:
                    return "...";
                case EItemUpdateStatus.k_EItemUpdateStatusCommittingChanges:
                    return "Committing changes...";
                case EItemUpdateStatus.k_EItemUpdateStatusPreparingConfig:
                    return "Preparing config...";
                case EItemUpdateStatus.k_EItemUpdateStatusPreparingContent:
                    return "Preparing content...";
                case EItemUpdateStatus.k_EItemUpdateStatusUploadingContent:
                    return "Uploading content...";
                case EItemUpdateStatus.k_EItemUpdateStatusUploadingPreviewFile:
                    return "Uploading preview file...";
                default:
                    return s.ToString();
            }
        }

        static bool success = false;
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
                    success = true;
                    break;
                default:
                    SetStatus("Item upload failed! Result code: " + param.m_eResult.ToString());
                    CUMessageBox.Show("Item upload failed! Result code: " + param.m_eResult.ToString());
                    ugcUpdateHandle = UGCUpdateHandle_t.Invalid;
                    success = false;
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
                default:
                    SetStatus("Unknown status: " + callBack.m_eResult.ToString());
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
