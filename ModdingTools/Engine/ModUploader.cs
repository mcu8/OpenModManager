using CUFramework.Dialogs;
using ModdingTools.Modding;
using ModdingTools.Windows;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
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

        public void UploadModAsync(ModObject mod, string changelog, string[] tags, bool keepCooked, bool keepScripts, int visibility, string description, string iconPath, List<string> ignoredFiles)
        {
            Task.Factory.StartNew(() =>
            {
                MainWindow.Instance.Invoke(new MethodInvoker(() => {
                    ModProperties.TemporaryHideAllPropertiesWindows();
                }));
                UploadMod(mod, changelog, tags, keepCooked, keepScripts, visibility, description, iconPath, ignoredFiles);
                MainWindow.Instance.Invoke(new MethodInvoker(() => {
                    ModProperties.RestoreTemporaryHiddenPropertiesWindows();
                }));
            });
        }

        public void ResetUploader()
        {
            publishID = 0;
            Message = "";
            m_itemCreated?.Dispose();
            m_itemSubmitted?.Dispose();
            ugcUpdateHandle = UGCUpdateHandle_t.Invalid;
        }

        public void UploadMod(ModObject mod, string changelog, string[] tags, bool keepUnCooked, bool keepScripts, int visibility, string description, string iconPath, List<string> ignoredFiles)
        {
            if (IsUploaderRunning)
            {
                MainWindow.Instance.Invoke(new MethodInvoker(() => {
                    CUMessageBox.Show(MainWindow.Instance, "Only one uploader instance can run at once!");
                }));
                return;
            }

            Toggle(true);
            ResetUploader();

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

                var ignorePathsDir = new List<string>();
                var ignorePathsFile = new List<string>();

                
                if (!keepScripts)
                {
                    ignorePathsDir.Add(Path.Combine(mod.RootPath, "CompiledScripts"));
                    ignorePathsDir.Add(Path.Combine(mod.RootPath, "Classes"));
                }

                if (!keepUnCooked)
                {
                    ignorePathsDir.Add(Path.Combine(mod.RootPath, "Maps"));
                    ignorePathsDir.Add(Path.Combine(mod.RootPath, "Content"));
                }

                ignorePathsDir.Add(Path.Combine(mod.RootPath, ".vscode"));
                ignorePathsDir.Add(Path.Combine(mod.RootPath, ".git"));
                ignorePathsDir.Add(Path.Combine(mod.RootPath, ".github"));

                ignorePathsFile.Add(Path.Combine(mod.RootPath, "vsc-modworkspace.code-workspace"));

                if (ignoredFiles != null)
                {
                    foreach (var c in ignoredFiles)
                    {
                        SetStatus($"Checking results for pattern '{c}'...");

                        var x = c.Replace("/", "\\").Trim();
                        var parts = x.Split('\\');
                        var mask = parts[parts.Length - 1];

                        var matches = new List<string>();
                        var matchesDir = new List<string>();

                        if (parts.Length == 1)
                        {
                            var ext = mask.Split('*');
                            var suffix = "";
                            
                            if (ext.Length > 0)
                            {
                                suffix = ext.Last();
                            }

                            var d = Directory.GetDirectories(mod.RootPath + "\\", mask, SearchOption.AllDirectories)
                                .Where(xy => string.IsNullOrEmpty(suffix) ? true : xy.EndsWith(suffix));
                            var f = Directory.GetFiles(mod.RootPath + "\\", mask, SearchOption.AllDirectories)
                                .Where(xy => string.IsNullOrEmpty(suffix) ? true : xy.EndsWith(suffix));

                            matchesDir.AddRange(d);
                            matches.AddRange(f);
                        }
                        else
                        {
                            var newPath = new string[parts.Length - 1];
                            for (var y = 0; y != parts.Length - 1; y++)
                                newPath[y] = parts[y];

                            var ph = Path.Combine(tmpDir, string.Join("\\", newPath));
                            var d = Directory.GetDirectories(ph, mask, SearchOption.TopDirectoryOnly);
                            var f = Directory.GetFiles(ph, mask, SearchOption.TopDirectoryOnly);

                            matchesDir.AddRange(d);
                            matches.AddRange(f);
                        }
                        
                        foreach(var r in matches)
                        {
                            SetStatus($"Adding ignore rule for file '{r.Split(new[] { tmpDir }, StringSplitOptions.None).Last()}'...");
                            ignorePathsFile.Add(r);
                        }

                        foreach (var r in matchesDir)
                        {
                            SetStatus($"Adding ignore rule for directory '{r.Split(new[] { tmpDir }, StringSplitOptions.None).Last()}'...");
                            ignorePathsDir.Add(r);
                        }
                    }
                }

                Utils.DirectoryCopy(mod.RootPath, tmpDir, true, ignorePathsFile, ignorePathsDir);

                var modid = mod.GetUploadedId();

                SetStatus("Creating callback...");

                m_itemCreated = CallResult<CreateItemResult_t>.Create(OnItemCreated);

                var appId = new AppId_t(uint.Parse(GameFinder.AppID));

                if (modid <= 100)
                {
                    SteamAPICall_t call = SteamUGC.CreateItem(appId, EWorkshopFileType.k_EWorkshopFileTypeCommunity);
                    m_itemCreated.Set(call);
                }
                else
                {
                    publishID = modid < 0 ? (ulong)(modid * -1) : (ulong)modid;
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
                    mod.SetUploadedId((long)publishID);
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
