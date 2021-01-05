using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModdingTools.Steam
{
    public abstract partial class AbstractModUploader
    {
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
        private static string BytesToString(ulong byteCount)
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
                // normally, that shouldn't happen... but nah
                return byteCount + "B";
            }
        }


    }
}
