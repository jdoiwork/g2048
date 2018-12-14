using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class DebugAddMobController : MonoBehaviour
{
    private BannerView bannerView;

    // Use this for initialization
    void Start()
    {
        var appId = "ca-app-pub-3940256099942544~1458002511";

        MobileAds.Initialize(appId);

        this.RequestBanner();
    }

    private void RequestBanner()
    {
        var adUnitId = "ca-app-pub-3940256099942544/2934735716";

        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        var request = new AdRequest.Builder().Build();

        bannerView.LoadAd(request);
    }
}
