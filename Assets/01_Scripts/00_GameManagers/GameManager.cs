using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Serialization;


public class GameManager : SingletonManager<GameManager>
{

    [FormerlySerializedAs("ResetGameEvent")] public EventObserver EventObserver;
    public PlayerStats CurrentPlayer;
    public BannerAd Ads;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
        Application.targetFrameRate = 120;
        UnityServices.InitializeAsync();
    }

    public void ConsentConfirmation()
    {
        AnalyticsService.Instance.StartDataCollection();
    }

    private void Start()
    {
        //TODO: SaveCurrPlayer system
        PlayerManager.current.SetPlayer(CurrentPlayer);
        Ads.LoadBanner();
        
    }

    public void ChangeCharacter(PlayerStats character)
    {
        if (CurrentPlayer == character) return;

        CurrentPlayer = character;
        PlayerManager.current.SetPlayer(CurrentPlayer);
    }


    public void StarGame()
    {
        EventObserver.StartGame();
        HideAd();
    }

    public void StopGame()
    {
        EventObserver.ResetGame();
        ShowAd();
    }

    public void ShowAd()
    {
        if(Ads!=null&&Ads.gameObject.activeSelf)
            Ads.ShowBannerAd();
    }

    public void HideAd()
    {
        if(Ads!=null&&Ads.gameObject.activeSelf)
            Ads.HideBannerAd();
    }
}
