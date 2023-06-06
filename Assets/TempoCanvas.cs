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

    private void Awake()
    {
        Instance = this;
        InterstitialLoad.onClick.AddListener(LoadInterstitialAdDisplay);
        RewardedLoad.onClick.AddListener(LoadRewardedAdDisplay);
    }

    private void LoadInterstitialAdDisplay()
    {
        InterstitialMsg.text = "Loading...";
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


    private void LoadRewardedAdDisplay()
    {
        RewardedMsg.text = "Loading...";
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
}
