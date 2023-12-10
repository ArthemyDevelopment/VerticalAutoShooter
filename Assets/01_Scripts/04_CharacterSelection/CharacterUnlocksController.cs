using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class CharacterUnlocksController : SerializedMonoBehaviour
{
    private CharacterSelectionController currCharacter;
    public Dictionary<int, CharacterSelectionController> CharacterUnlocksThreasholds;

    
    private List<int> DicKeys;

    private void OnEnable()
    {
        DicKeys = new List<int>(CharacterUnlocksThreasholds.Keys);

        if (PlayerPrefs.HasKey("HighScore"))
        {
            int HS = PlayerPrefs.GetInt("HighScore");

            for (int i = 0; i < DicKeys.Count; i++)
            {
                if (DicKeys[i] <= HS)
                    CharacterUnlocksThreasholds[DicKeys[i]].Locked.SetActive(false);
                else
                    CharacterUnlocksThreasholds[DicKeys[i]].Locked.SetActive(true);
            }
        }
        else
        {
            foreach (var selector in CharacterUnlocksThreasholds)
            {
                selector.Value.Locked.SetActive(true);
            }
            CharacterUnlocksThreasholds[0].Locked.SetActive(false);
        }
            
        
        
    }
    
    public int GetKeyToCheck(int score)
    {
        for (int i = 0; i < DicKeys.Count; i++)
        {
            if (i == DicKeys.Count - 1) return DicKeys[i];

            if (score >= DicKeys[i] && score < DicKeys[i + 1]) return DicKeys[i];
            
        }

        return score;
    }

    public void ChangeCharacter(CharacterSelectionController thisCharacter)
    {
        if (currCharacter == thisCharacter) return;
        
        if(currCharacter!=null) currCharacter.DeselectCharacter();

        currCharacter = thisCharacter;
        GameManager.current.ChangeCharacter(currCharacter.thisCharacter);
    }
}
