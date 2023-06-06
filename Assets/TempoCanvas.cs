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
        InterstitialLoad.onClick.AddListener(LoadInterstitialAd);
        InterstitialPlay.onClick.AddListener(ShowInterstitialAd);
        RewardedLoad.onClick.AddListener(LoadRewardedAd);
        RewardedPlay.onClick.AddListener(ShowRewardedlAd);
    }

    private void LoadInterstitialAd()
    {
        InterstitialMsg.text = "Loading...";
    }
    private void ShowInterstitialAd()
    {
        InterstitialMsg.text = "";
        InterstitialPlay.interactable = false;
    }
    public void EnableInterstitialAd()
    {
        InterstitialMsg.text = "";
        InterstitialPlay.interactable = true;
    }


    private void LoadRewardedAd()
    {
        RewardedMsg.text = "Loading...";
    }
    private void ShowRewardedlAd()
    {
        RewardedMsg.text = "";
        RewardedPlay.interactable = false;
    }
    public void EnableRewardedAd()
    {
        RewardedMsg.text = "";
        RewardedPlay.interactable = true;
    }
}
