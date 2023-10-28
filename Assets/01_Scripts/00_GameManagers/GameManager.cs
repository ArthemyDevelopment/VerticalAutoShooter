using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class GameManager : SingletonManager<GameManager>
{

    [FormerlySerializedAs("ResetGameEvent")] public EventObserver EventObserver;


    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
        Application.targetFrameRate = 120;
        
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
