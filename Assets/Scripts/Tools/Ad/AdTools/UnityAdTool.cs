using System;

#if !UNITY_WEBGL
using UnityEngine.Advertisements;
#endif

namespace G2048.Tools.Ad.AdTools
{
    public class UnityAdTool : AdTool
    {
        public void Destroy()
        {
            // do nothing
        }

        public bool IsReady()
        {
#if UNITY_WEBGL
          return true;
#else
          return Advertisement.IsReady();
#endif
        }

        public void Show(Action<AdResult> resultCallback)
        {
#if UNITY_WEBGL
          resultCallback(AdResult.Failed);
#else
      Advertisement.Show(CreateShowOptions(resultCallback));
#endif
        }
#if !UNITY_WEBGL

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
#endif

  }
}


