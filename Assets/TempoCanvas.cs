using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        InterstitialLoad.onClick.AddListener(OnInterstitialLoad);
        InterstitialPlay.onClick.AddListener(OnInterstitialPlay);
        RewardedLoad.onClick.AddListener(OnRewardedLoad);
        RewardedPlay.onClick.AddListener(OnRewardedReady);
    }

    public void OnInterstitialLoad()
    {
        InterstitialMsg.text = "Loading...";
    }

    public void OnInterstitialReady()
    {
        InterstitialMsg.text = "";
        InterstitialPlay.interactable = true;
    }

    public void OnInterstitialPlay()
    {
        InterstitialMsg.text = "";
        InterstitialPlay.interactable = false;
    }


    public void OnRewardedLoad()
    {
        RewardedMsg.text = "Loading...";
    }

    public void OnRewardedReady()
    {
        RewardedMsg.text = "";
        RewardedPlay.interactable = true;
    }

    public void OnRewardedPlay()
    {
        RewardedMsg.text = "";
        RewardedPlay.interactable = false;
    }
}
