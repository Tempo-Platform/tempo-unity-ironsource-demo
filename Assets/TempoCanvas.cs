using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;

public class TempoCanvas : MonoBehaviour
{
    public Button RewardedLoad;
    public Button RewardedPlay;
    public TextMeshProUGUI RewardedMsg;
    public Button InterstitialLoad;
    public Button InterstitialPlay;
    public TextMeshProUGUI InterstitialMsg;

    public static TempoCanvas Instance;

    private Coroutine _rewardedLabelFade;
    private Coroutine _interstitialLabelFade;

    private float FADE_TIME = 3f;

    private void Awake()
    {
        Instance = this;
        InterstitialLoad.onClick.AddListener(LoadInterstitialAdDisplay);
        RewardedLoad.onClick.AddListener(LoadRewardedAdDisplay);
    }

    private void LoadInterstitialAdDisplay()
    {
        StartFadingInterstitialLabel("Loading...");
    }
    public void EnableInterstitialAd()
    {
        InterstitialMsg.text = "";
        InterstitialPlay.interactable = true;
    }
    public void CloseInterstitialAd()
    {
        InterstitialMsg.text = "";
        InterstitialPlay.interactable = false;
    }
    public void FailedLoadInterstitialAd()
    {
        InterstitialPlay.interactable = false;
        StartFadingInterstitialLabel("Failed to load");
    }

    private void LoadRewardedAdDisplay()
    {
        StartFadingRewardedLabel("Loading...");
    }
    public void EnableRewardedAd()
    {
        RewardedMsg.text = "";
        RewardedPlay.interactable = true;
    }
    public void CloseRewardedAd()
    {
        RewardedMsg.text = "";
        RewardedPlay.interactable = false;
    }
    public void FailedLoadRewardedAd()
    {
        RewardedPlay.interactable = false;
        StartFadingRewardedLabel("Failed to load");
    }

    private void StartFadingRewardedLabel(string msg)
    {
        RewardedMsg.text = msg;
        if(_rewardedLabelFade != null)
        {
            StopCoroutine(_rewardedLabelFade);
        }
        _rewardedLabelFade = StartCoroutine(FadeRewarded());
    }
    private IEnumerator FadeRewarded()
    {
        float t = 0;
        while (t < 1f)
        {
            t += Time.deltaTime / FADE_TIME;
            RewardedMsg.alpha = 1 - t;
            yield return null;
        }

        RewardedMsg.text = "";
        RewardedMsg.alpha = 1f;
    }
    private void StartFadingInterstitialLabel(string msg)
    {
        InterstitialMsg.text = msg;
        if (_interstitialLabelFade != null)
        {
            StopCoroutine(_interstitialLabelFade);
        }
        _interstitialLabelFade = StartCoroutine(FadeInterstitial());
    }
    private IEnumerator FadeInterstitial()
    {
        float t = 0;
        while (t < 1f)
        {
            t += Time.deltaTime / FADE_TIME;
            InterstitialMsg.alpha = 1 - t;
            yield return null;
        }

        InterstitialMsg.text = "";
        InterstitialMsg.alpha = 1f;
    } 
}
