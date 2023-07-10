using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TempoIronSourceController : MonoBehaviour
{
    [Header("APP KEY from ironSource account")]
    [SerializeField] private string _androidAppKey = "ANDROID_APP_KEY";
    [SerializeField] private string _iosAppKey = "IOS_APP_KEY";

    [Header("Project settings")]
    [SerializeField] private TempoCanvas _tempoCanvas;
    [SerializeField] private bool _isDebugging = true;

    private string _appKey;

    public void Start()
    {
        // Setup for manual control of reward ads
        IronSource.Agent.setManualLoadRewardedVideo(true);

        // Initialise the ironSource SDK
        _appKey = GetAppKey();
        IronSource.Agent.init(_appKey);

        // Configures behaviour of UI elements in demo scene
        SetupUI();
    }
   
    void OnEnable()
    {
        // Rewarded
        IronSourceRewardedVideoEvents.onAdAvailableEvent += onAdAvailableEventRew;
        IronSourceRewardedVideoEvents.onAdClickedEvent += onAdClickedEventRew;
        IronSourceRewardedVideoEvents.onAdClosedEvent += onAdClosedEventRew;
        IronSourceRewardedVideoEvents.onAdLoadFailedEvent += onAdLoadFailedEventRew;
        IronSourceRewardedVideoEvents.onAdOpenedEvent += onAdOpenedEventRew;
        IronSourceRewardedVideoEvents.onAdReadyEvent += onAdReadyEventRew;
        IronSourceRewardedVideoEvents.onAdRewardedEvent += onAdRewardedEventRew;
        IronSourceRewardedVideoEvents.onAdShowFailedEvent += onAdShowFailedEventRew;
        IronSourceRewardedVideoEvents.onAdUnavailableEvent += onAdUnavailableEventRew;

        // Interstitial
        IronSourceInterstitialEvents.onAdClickedEvent += onAdClickedEventInt;
        IronSourceInterstitialEvents.onAdClosedEvent += onAdClosedEventInt;
        IronSourceInterstitialEvents.onAdLoadFailedEvent += onAdLoadFailedEventInt;
        IronSourceInterstitialEvents.onAdOpenedEvent += onAdOpenedEventInt;
        IronSourceInterstitialEvents.onAdReadyEvent += onAdReadyEventInt;
        IronSourceInterstitialEvents.onAdShowFailedEvent += onAdShowFailedEventInt;
        IronSourceInterstitialEvents.onAdShowSucceededEvent += onAdShowSucceededEventInt;
    }

    /// <summary>
    /// Assigns behaviour to Unity UI components
    /// </summary>
    private void SetupUI()
    {
        // Rewarded Ads
        _tempoCanvas.RewardedLoad.onClick.AddListener(() =>
        {
            IronSource.Agent.loadRewardedVideo();
            _tempoCanvas.StartFadingRewardedLabel($"Loading... [REW:{_appKey}]");
        });
        _tempoCanvas.RewardedShow.onClick.AddListener(() =>
        {
            if (IronSource.Agent.isRewardedVideoAvailable())
            {
                IronSource.Agent.showRewardedVideo();
            }
            else
            {
                Debug.LogWarning("IronSource.Agent.isRewardedVideoAvailable: False");
            }
        });

        // Interstitial Ads
        _tempoCanvas.InterstitialLoad.onClick.AddListener(() =>
        {
            IronSource.Agent.loadInterstitial();
            _tempoCanvas.StartFadingInterstitialLabel($"Loading... [INT:{_appKey}]");
        });
        _tempoCanvas.InterstitialShow.onClick.AddListener(() =>
        {
            if (IronSource.Agent.isInterstitialReady())
            {
                IronSource.Agent.showInterstitial();
            }
            else
            {
                Debug.LogWarning("IronSource.Agent.isInterstitialVideoAvailable: False");
            }
        });
    }

    /// <summary>
    /// Returns key value dependent on current iOS/Android platform
    /// </summary>
    private string GetAppKey()
    {
#if UNITY_ANDROID
        return _androidAppKey;
#elif UNITY_IPHONE
        return _iosAppKey;
#else
        return "";
#endif
    }

    /// <summary>
    /// Make comment markers standout when console debugging
    /// </summary>
    private void Shout(string msg)
    {
        if (_isDebugging && !string.IsNullOrWhiteSpace(msg))
        {
            Debug.Log($"*** {msg} ***");
        }
    }


    // INTERSTITIAL
    private void onAdReadyEventInt(IronSourceAdInfo obj)
    {
        Shout("onAdReadyEventInt");
        _tempoCanvas.EnableInterstitialAd();
    }
    private void onAdShowSucceededEventInt(IronSourceAdInfo obj)
    {
        Shout("onAdShowSucceededEventInt");
    }
    private void onAdClosedEventInt(IronSourceAdInfo obj)
    {
        _tempoCanvas.CloseInterstitialAd();
        Shout("onAdClosedEventInt");
    }


    // REWARDED 
    private void onAdReadyEventRew(IronSourceAdInfo obj)
    {
        _tempoCanvas.EnableRewardedAd();
        Shout("onAdReadyEventRew");
    }
    private void onAdClosedEventRew(IronSourceAdInfo obj)
    {
        _tempoCanvas.CloseRewardedAd();
        Shout("onAdClosedEventRew");
    }


    #region TODO
    // WIP: Currently not called from Tempo adapter (I)
    private void onAdShowFailedEventInt(IronSourceError arg1, IronSourceAdInfo arg2)
    {
        Shout("onAdShowFailedEventInt");
    }
    private void onAdLoadFailedEventInt(IronSourceError obj)
    {
        _tempoCanvas.FailedLoadInterstitialAd();
        Shout("onAdLoadFailedEventInt");
    }
    private void onAdClickedEventInt(IronSourceAdInfo obj)
    {
        Shout("onAdClickedEventInt");
    }
    private void onAdOpenedEventInt(IronSourceAdInfo obj)
    {
        Shout("onAdOpenedEventInt");
    }
    // WIP: Currently not called from Tempo adapter (R)
    private void onAdUnavailableEventRew()
    {
        Shout("onAdUnavailableEventRew");
    }
    private void onAdShowFailedEventRew(IronSourceError arg1, IronSourceAdInfo arg2)
    {
        Shout("onAdShowFailedEventRew");
    }
    private void onAdRewardedEventRew(IronSourcePlacement arg1, IronSourceAdInfo arg2)
    {
        Shout("onAdRewardedEventRew");
    }
    private void onAdOpenedEventRew(IronSourceAdInfo obj)
    {
        Shout("onAdReadyEventRew");
    }
    private void onAdLoadFailedEventRew(IronSourceError obj)
    {
        _tempoCanvas.FailedLoadRewardedAd();
        Shout("onAdLoadFailedEventRew");
    }
    private void onAdClickedEventRew(IronSourcePlacement arg1, IronSourceAdInfo arg2)
    {
        Shout("onAdClickedEventRew");
    }
    private void onAdAvailableEventRew(IronSourceAdInfo obj)
    {
        Shout("onAdAvailableEventRew");
    }
    #endregion
}
