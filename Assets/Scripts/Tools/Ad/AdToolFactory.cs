using System;
using G2048.Tools.Ad.AdTools;
using GoogleMobileAds.Api;
using UnityEngine;


namespace G2048.Tools.Ad
{
    public static class AdToolFactory
    {
        public static void Init()
        {
            InitAdMob();
            Debug.Log("Init Ad");
        }

        private static void InitAdMob()
        {
            MobileAds.Initialize(AdMobIds.AppId);
#if !UNITY_EDITOR
            preloadedAdmob = new AdMobInterstitialAdTool();
#endif
        }
#if !UNITY_EDITOR
        private static AdMobInterstitialAdTool preloadedAdmob;
#endif

        public static AdTool Create()
        {
#if UNITY_EDITOR
            return new UnityAdTool();
#else
            var admob = preloadedAdmob;
            preloadedAdmob = new AdMobInterstitialAdTool();
            return admob;
#endif
        }
    }
}

