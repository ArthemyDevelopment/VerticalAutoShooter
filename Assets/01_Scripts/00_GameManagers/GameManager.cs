using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class GameManager : SingletonManager<GameManager>
{

    [FormerlySerializedAs("ResetGameEvent")] public EventObserver EventObserver;
    public PlayerStats CurrentPlayer;


    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
        Application.targetFrameRate = 120;
        
    }

    private void Start()
    {
        //TODO: SaveCurrPlayer system
        PlayerManager.current.SetPlayer(CurrentPlayer);
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
        
    }

    public void StopGame()
    {
        EventObserver.ResetGame();
    }
}
