using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;

public class TempoCanvas : MonoBehaviour
{
    public Button RewardedLoad;
    public Button RewardedShow;
    public TextMeshProUGUI RewardedMsg;
    public Button InterstitialLoad;
    public Button InterstitialShow;
    public TextMeshProUGUI InterstitialMsg;

    private Coroutine _rewardedLabelFade;
    private Coroutine _interstitialLabelFade;

    private float FADE_TIME = 3f;

    /// <summary>
    /// Enables 'Show' button for Interstitial ads, and clears output
    /// </summary>
    public void EnableInterstitialAd()
    {
        InterstitialMsg.text = "";
        InterstitialShow.interactable = true;
    }

    /// <summary>
    /// Disables 'Show' button for Interstitial ads, and clears output
    /// </summary>
    public void CloseInterstitialAd()
    {
        InterstitialMsg.text = "";
        InterstitialShow.interactable = false;
    }
    /// <summary>
    /// Disables 'Show' button for Interstitial ads, displays general error
    /// </summary>
    public void FailedLoadInterstitialAd()
    {
        InterstitialShow.interactable = false;
        StartFadingInterstitialLabel("Failed to load");
    }

    /// <summary>
    /// Enables 'Show' button for Rewarded ads, and clears output
    /// </summary>
    public void EnableRewardedAd()
    {
        RewardedMsg.text = "";
        RewardedShow.interactable = true;
    }
    /// <summary>
    /// Disables 'Show' button for Rewarded ads, and clears output
    /// </summary>
    public void CloseRewardedAd()
    {
        RewardedMsg.text = "";
        RewardedShow.interactable = false;
    }
    /// <summary>
    /// Disables 'Show' button for Rewarded ads, displays general error
    /// </summary>
    public void FailedLoadRewardedAd()
    {
        RewardedShow.interactable = false;
        StartFadingRewardedLabel("Failed to load");
    }

    /// <summary>
    /// Triggers Rewarded output fade-away coroutine, and interupts any current one 
    /// </summary>
    public void StartFadingRewardedLabel(string msg)
    {
        RewardedMsg.text = msg;
        if(_rewardedLabelFade != null)
        {
            StopCoroutine(_rewardedLabelFade);
        }
        _rewardedLabelFade = StartCoroutine(FadeRewarded());
    }

    /// <summary>
    /// Fades away the appearance of current Rewarded output over brief time and then removes value
    /// </summary>
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
    /// <summary>
    /// Triggers Interstitial output fade-away coroutine, and interupts any current one 
    /// </summary>
    public void StartFadingInterstitialLabel(string msg)
    {
        InterstitialMsg.text = msg;
        if (_interstitialLabelFade != null)
        {
            StopCoroutine(_interstitialLabelFade);
        }
        _interstitialLabelFade = StartCoroutine(FadeInterstitial());
    }
    /// <summary>
    /// Fades away the appearance of current Interstitial output over brief time and then removes value
    /// </summary>
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
