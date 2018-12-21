using System;
using G2048.Tools.Ad.AdTools;
using GoogleMobileAds.Api;
using UnityEngine;


#pragma warning disable CS0436 // 型がインポートされた型と競合しています

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
            var appId = "ca-app-pub-3940256099942544~1458002511";

            MobileAds.Initialize(appId);
        }

        public static AdTool Create()
        {
            return new UnityAdTool();
        }
    }
}


#pragma warning restore CS0436 // 型がインポートされた型と競合しています
