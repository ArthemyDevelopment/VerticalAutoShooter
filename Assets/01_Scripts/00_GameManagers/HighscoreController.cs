using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoreController : MonoBehaviour
{

    public TMP_Text HighScoreText;
    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("Score"))
            HighScoreText.text = PlayerPrefs.GetInt("Score").ToString();
        
        else
            HighScoreText.text = "0";
        
    }
}
