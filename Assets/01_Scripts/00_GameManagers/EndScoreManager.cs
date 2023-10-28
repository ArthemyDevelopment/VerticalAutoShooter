using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScoreManager : MonoBehaviour
{

    public EventObserver EventObserver;
    public GameObject NewHighScore;
    public TMP_Text Score;
    public GameObject Frame;

    private void Awake()
    {
        EventObserver.OnResetGame += OpenScreen;
        Frame.SetActive(false);
    }

    public void OpenScreen()
    {
        Frame.SetActive(true); 
        NewHighScore.SetActive(false);
        int temp = ScoreManager.current.Score;
        
        Score.text = temp.ToString();

        if (PlayerPrefs.HasKey("HighScore"))
        {
            int HS = PlayerPrefs.GetInt("HighScore");

            if (temp > HS)
            {
                NewHighScore.SetActive(true);
                PlayerPrefs.SetInt("HighScore", temp);
            }
        }
        else
        {
            NewHighScore.SetActive(true);
            PlayerPrefs.SetInt("HighScore", temp);
        }
    }

    public void PlayAgain()
    {
        EventObserver.StartGame();
        Frame.SetActive(false);
    }
}
