using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// let's rewrite that shit...
namespace ModdingTools.Steam.SteamApiCallback
{
    public class SteamCallbackEventArgs<T> : EventArgs
    {
        public T CallbackResult { get; set; }
        public bool IOFailed { get; protected set; }

        public SteamCallbackEventArgs(T CallbackResult, bool IOFailed)
        {
            this.IOFailed = IOFailed;
            this.CallbackResult = CallbackResult;
        }
    }

    public abstract class SteamCallback<T>
    {
        protected static CallResult<T> CallResult;
        
        // it's static, cuz we only can run one callback at once...
        protected static bool IsRunning = false;

        public event EventHandler<SteamCallbackEventArgs<T>> OnCallbackFinished;

        public SteamCallback()
        {
            CallResult = CallResult<T>.Create(OnItemCreated);
        }

        protected abstract SteamAPICall_t CreateCall();

        public void Run()
        {
            if (IsRunning)
            {
                throw new Exception("Another callback is already running!");
            }
            IsRunning = true;
            CallResult.Set(CreateCall());
            SteamAPI.RunCallbacks();
        }

        public Task RunAsync()
        {
            return Task.Factory.StartNew(() => Run());
        }

        protected void OnCallFinished()
        {
            IsRunning = false;
        }

        protected void OnItemCreated(T callBack, bool bIOFailure)
        {
            OnCallFinished();
            OnCallbackFinished?.Invoke(this, new SteamCallbackEventArgs<T>(callBack, bIOFailure));
        }
    }

    public class SteamCreateItemCallback : SteamCallback<CreateItemResult_t>
    {
        private AppId_t AppId;
        private EWorkshopFileType EWorkshopFileType;

        public SteamCreateItemCallback(uint appId, EWorkshopFileType eWorkshopFileType = EWorkshopFileType.k_EWorkshopFileTypeCommunity)
        {
            AppId = new AppId_t(appId);
            EWorkshopFileType = eWorkshopFileType;
        }

        protected override SteamAPICall_t CreateCall()
        {
            return SteamUGC.CreateItem(AppId, EWorkshopFileType);
        }
    }
}
