using System;
namespace G2048.Tools.Ad.AdTools
{
    public static class AdMobIds
    {
        public static string AppId
        {
            get
            {
#if UNITY_ANDROID
                return "ca-app-pub-3940256099942544~3347511713"; // example id
#elif UNITY_IPHONE
                return "ca-app-pub-3674324382300166~6878459301";
#else
                return "unexpected_platform";
#endif
            }
        }
        
        public static string InterstitialId
        {
            get
            {
#if UNITY_ANDROID
                return "ca-app-pub-3940256099942544/1033173712"; // example id
#elif UNITY_IPHONE
                return "ca-app-pub-3674324382300166/6927518620";
#else
                return "unexpected_platform";
#endif
            }
        }

    }
}
