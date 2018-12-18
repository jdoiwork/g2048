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
            return (sr) => ConvertCallbackResult(callback, sr);
        }

        private void ConvertCallbackResult(Action<AdResult> callback, ShowResult sr)
        {
            switch (sr)
            {
                case ShowResult.Failed: callback(AdResult.Failed); break;
                case ShowResult.Skipped: callback(AdResult.Skipped); break;
                case ShowResult.Finished: callback(AdResult.Finished); break;
            }
        }
    }
}


#pragma warning restore CS0436 // 型がインポートされた型と競合しています
