using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


// Example for IronSource Unity.
public class IronSourceDemoScript : MonoBehaviour
{
    public void Start()
    {

#if UNITY_ANDROID
        string appKey = "1a46bef35";
#elif UNITY_IPHONE
        string appKey = "1a4922385";
#else
        string appKey = "unexpected_platform";
#endif

        Debug.Log("unity-script: IronSource.Agent.validateIntegration");
        IronSource.Agent.validateIntegration();

        IronSource.Agent.setManualLoadRewardedVideo(true);

        Debug.Log("unity-script: unity version" + IronSource.unityVersion());

        // SDK init
        Debug.Log("unity-script: IronSource.Agent.init");
        IronSource.Agent.init(appKey);

        SetupButtons();
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
        IronSourceInterstitialEvents.onAdOpenedEvent += onAdReadyEventInt;
        IronSourceInterstitialEvents.onAdReadyEvent += onAdReadyEventInt;
        IronSourceInterstitialEvents.onAdShowFailedEvent += onAdShowFailedEventInt;
        IronSourceInterstitialEvents.onAdShowSucceededEvent += onAdShowSucceededEventInt;

        // Other
        IronSourceEvents.onSdkInitializationCompletedEvent += SdkInitializationCompletedEvent;
        IronSourceEvents.onImpressionDataReadyEvent += ImpressionDataReadyEvent;
    }


    private void SetupButtons()
    {
        // REWARDED - Load
        TempoCanvas.Instance.RewardedLoad.onClick.AddListener(() =>
        {
            Debug.Log("unity-script: LoadRewardedButtonClicked");
            IronSource.Agent.loadRewardedVideo();
        });

        // REWARDED - Show
        TempoCanvas.Instance.RewardedPlay.onClick.AddListener(() =>
        {
            if (IronSource.Agent.isRewardedVideoAvailable())
            {
                Debug.Log("unity-script: ShowRewardedButtonClicked");
                IronSource.Agent.showRewardedVideo();
            }
            else
            {
                Debug.Log("unity-script: IronSource.Agent.isRewardedVideoAvailable - False");
            }
        });


        // INTERSTITIAL - Load
        TempoCanvas.Instance.InterstitialLoad.onClick.AddListener(() =>
        {
            Debug.Log("unity-script: LoadRewardedButtonClicked");
            IronSource.Agent.loadInterstitial();
        });

        // INTERSTITIAL - Show
        TempoCanvas.Instance.InterstitialPlay.onClick.AddListener(() =>
        {
            if (IronSource.Agent.isInterstitialReady())
            {
                Debug.Log("unity-script: ShowInterstitialButtonClicked");
                IronSource.Agent.showInterstitial();
            }
            else
            {
                Debug.Log("unity-script: IronSource.Agent.isInterstitialVideoAvailable - False");
            }
        });
    }


    private void Oi(string msg)
    {
        if (!string.IsNullOrWhiteSpace(msg))
        {
            Debug.Log($"!! *** {msg} ***");
        }
    }

    // INTERSTITIAL
    private void onAdShowSucceededEventInt(IronSourceAdInfo obj)
    {
        Oi("onAdShowSucceededEventInt");
    }
    private void onAdShowFailedEventInt(IronSourceError arg1, IronSourceAdInfo arg2)
    {
        Oi("onAdShowFailedEventInt");
    }
    private void onAdReadyEventInt(IronSourceAdInfo obj)
    {
        Oi("onAdReadyEventInt");
        TempoCanvas.Instance.EnableInterstitialAd();
    }
    private void onAdLoadFailedEventInt(IronSourceError obj)
    {
        Oi("onAdLoadFailedEventInt");
    }
    private void onAdClickedEventInt(IronSourceAdInfo obj)
    {
        Oi("onAdClosedEventInt");
    }
    private void onAdClosedEventInt(IronSourceAdInfo obj)
    {
        TempoCanvas.Instance.CloseInterstitialAd();
        Oi("onAdClosedEventInt");
    }

    // REWARDED 
    private void onAdUnavailableEventRew()
    {
        Oi("onAdUnavailableEventRew");
    }
    private void onAdShowFailedEventRew(IronSourceError arg1, IronSourceAdInfo arg2)
    {
        Oi("onAdShowFailedEventRew");
    }
    private void onAdRewardedEventRew(IronSourcePlacement arg1, IronSourceAdInfo arg2)
    {
        Oi("onAdRewardedEventRew");
    }
    private void onAdOpenedEventRew(IronSourceAdInfo obj)
    {
        Oi("onAdReadyEventRew");
    }
    private void onAdLoadFailedEventRew(IronSourceError obj)
    {
        Oi("onAdLoadFailedEventRew");
    }
    private void onAdClosedEventRew(IronSourceAdInfo obj)
    {
        TempoCanvas.Instance.CloseRewardedAd();
        Oi("onAdClosedEventRew");
    }
    private void onAdClickedEventRew(IronSourcePlacement arg1, IronSourceAdInfo arg2)
    {
        Oi("onAdClickedEventRew");
    }
    private void onAdAvailableEventRew(IronSourceAdInfo obj)
    {
        Oi("onAdAvailableEventRew");
    }
    private void onAdReadyEventRew(IronSourceAdInfo obj)
    {
        TempoCanvas.Instance.EnableRewardedAd();
        Oi("onAdReadyEventRew");
    }




    void OnApplicationPause(bool isPaused)
    {
        Debug.Log("unity-script: OnApplicationPause = " + isPaused);
        IronSource.Agent.onApplicationPause(isPaused);
    }



    void SdkInitializationCompletedEvent()
    {
        Debug.Log("unity-script: I got SdkInitializationCompletedEvent");
    }
  

    void ImpressionSuccessEvent(IronSourceImpressionData impressionData)
    {
        Debug.Log("unity - script: I got ImpressionSuccessEvent ToString(): " + impressionData.ToString());
        Debug.Log("unity - script: I got ImpressionSuccessEvent allData: " + impressionData.allData);
    }

    void ImpressionDataReadyEvent(IronSourceImpressionData impressionData)
    {
        Debug.Log("unity - script: I got ImpressionDataReadyEvent ToString(): " + impressionData.ToString());
        Debug.Log("unity - script: I got ImpressionDataReadyEvent allData: " + impressionData.allData);
    }


}
