using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionController : MonoBehaviour
{
    public CharacterUnlocksController controller;
    public PlayerStats thisCharacter;
    public GameObject IsSelected;
    public GameObject Locked;
    public Image CharacterSprite;
    public TMP_Text CharStats;

    private void Awake()
    {
        InitSelector();
    }

    private void OnEnable()
    {
        if (GameManager.current.CurrentPlayer == thisCharacter)
        {
            controller.ChangeCharacter(this);
        }
    }

    public void InitSelector()
    {
        CharacterSprite.sprite = thisCharacter.CharSprite;
        CharStats.text = thisCharacter.CharStats;
    }

    public void SelectCharacter()
    {
        controller.ChangeCharacter(this);
        IsSelected.SetActive(true);
    }

    public void DeselectCharacter()
    {
        IsSelected.SetActive(false);
    }
    
}
