using System;
using G2048.Tools.Ad.AdTools.AdMob;

namespace G2048.Tools.Ad.AdTools
{
    public static class AdMobIds
    {
        public static AdMobId Ids
        {
            get {
#if UNITY_ANDROID
                return new UnexpectedAdMobIds();
#elif UNITY_IPHONE
                return new IOsAdMobIds();
#else
                return new UnexpectedAdMobIds();
#endif
            }
        }
        public static string AppId
        {
            get
            {
                return Ids.AppId;
            }
        }

        public static string InterstitialId
        {
            get
            {
                return Ids.InterstitialId;
            }
        }

        public static string VideoId
        {
            get
            {
                return Ids.VideoId;
            }
        }

    }
}
