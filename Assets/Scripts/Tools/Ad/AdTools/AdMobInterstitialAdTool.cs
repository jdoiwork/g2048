using System;
using GoogleMobileAds.Api;
using UnityEngine;

namespace G2048.Tools.Ad.AdTools
{
    public class AdMobInterstitialAdTool : AdTool
    {
        private InterstitialAd interstitial;
        private Action<AdResult> callback;
        private bool isFailedToLoad = false;

        public AdMobInterstitialAdTool()
        {
            var id = AdMobIds.InterstitialId;
            Debug.LogFormat("ID = {0}", id);
            this.interstitial = new InterstitialAd(id);
            RegisterEvents();

            var request = CreateRequest();
            this.interstitial.LoadAd(request);
        }

        private AdRequest CreateRequest()
        {
            return new AdRequest
                .Builder()
                .AddTestDevice("f17111d750a8109fb7f0710b36c68484")
                .Build();
        }

        private void RegisterEvents()
        {
            this.interstitial.OnAdFailedToLoad += OnAdFailedToLoad;
            this.interstitial.OnAdClosed += OnAdClosed;
        }

        private void OnAdClosed(object sender, EventArgs e)
        {
            Debug.Log("OnAdClosed");
            InvokeCallback(AdResult.Finished);
        }


        private void OnAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
        {
            Debug.Log("OnAdFailedToLoad");

            InvokeCallback(AdResult.Failed);
        }

        private void InvokeCallback(AdResult ar)
        {
            if (this.callback == null)
            {
                Debug.Log("callback is NULL");
            }
            else
            {
                Debug.Log("callback is OK");
                this.callback(ar);
            }
        }

        public void Destroy()
        {
            this.interstitial.Destroy();
        }

        public bool IsReady()
        {
            Debug.LogFormat("IsLoaded == {0}", this.interstitial.IsLoaded());
            return this.interstitial.IsLoaded();
        }

        public void Show(Action<AdResult> resultCallback)
        {
            if (resultCallback == null)
            {
                Debug.Log("resultCallback is NULL");
            }
            else if (isFailedToLoad)
            {
                resultCallback(AdResult.Failed);
            }
            else
            {
                this.callback = resultCallback;
                this.interstitial.Show();
            }
        }
    }
}
