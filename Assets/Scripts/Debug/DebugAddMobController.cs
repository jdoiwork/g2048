using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class DebugAddMobController : MonoBehaviour
{
    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardBasedVideoAd rewardBasedVideo;

    // Use this for initialization
    void Start()
    {
        InitAd();
        InitStitial();
        InitVideo();

        this.RequestBanner();
    }

    private void InitVideo()
    {
        // Get singleton reward based video ad reference.
        this.rewardBasedVideo = RewardBasedVideoAd.Instance;

#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, adUnitId);
    }

    private void InitStitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        //string adUnitId = "ca-app-pub-3940256099942544/4411468910";
        string adUnitId = "ca-app-pub-3674324382300166/6927518620";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        this.interstitial.OnAdFailedToLoad += (_, e) => Debug.LogErrorFormat("" +
        	"!!!!!!!!OnAdFailedToLoad: {0}", e.Message);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder()
            .AddTestDevice("f17111d750a8109fb7f0710b36c68484")
            .Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    private static void InitAd()
    {
        //var appId = "ca-app-pub-3940256099942544~1458002511";
        var appId = "ca-app-pub-3674324382300166~6878459301";
        MobileAds.Initialize(appId);
    }

    private void RequestBanner()
    {
        var adUnitId = "ca-app-pub-3940256099942544/2934735716";

        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        var request = new AdRequest.Builder().Build();

        bannerView.LoadAd(request);
    }

    public void ShowInterstitial()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }

    public void ShowVideo()
    {
        if (this.rewardBasedVideo.IsLoaded())
        {
            this.rewardBasedVideo.Show();
        }
    }
}
