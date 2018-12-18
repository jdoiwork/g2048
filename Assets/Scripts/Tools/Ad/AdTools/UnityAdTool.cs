using System;

using UnityEngine.Advertisements;
#pragma warning disable CS0436 // 型がインポートされた型と競合しています

namespace G2048.Tools.Ad.AdTools
{
    public class UnityAdTool : AdTool
    {
        public void Destroy()
        {

        }

        public bool IsReady()
        {
            return Advertisement.IsReady();
        }

        public void Show(Action<AdResult> resultCallback)
        {
            Advertisement.Show(CreateShowOptions(resultCallback));
        }

        private ShowOptions CreateShowOptions(Action<AdResult> resultCallback)
        {
            return new ShowOptions { resultCallback = CreateCallback(resultCallback) };
        }

        private Action<ShowResult> CreateCallback(Action<AdResult> callback)
        {
            return (sr) => callback(ConvertResult(sr));
        }

        private AdResult ConvertResult(ShowResult sr)
        {
            switch (sr)
            {
                case ShowResult.Failed: return AdResult.Failed;
                case ShowResult.Skipped: return AdResult.Skipped; 
                case ShowResult.Finished: return AdResult.Finished;
                default: return AdResult.Failed;
            }
        }
    }
}


#pragma warning restore CS0436 // 型がインポートされた型と競合しています
