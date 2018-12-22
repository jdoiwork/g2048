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
        }

        public static AdTool Create()
        {
            //return new UnityAdTool();
            return new AdMobInterstitialAdTool();
        }
    }
}

