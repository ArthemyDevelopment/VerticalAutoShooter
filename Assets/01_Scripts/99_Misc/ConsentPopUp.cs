using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class ConsentPopUp : MonoBehaviour
{
    public const string ConsentKey = "ConsentDataCollection";
    
    private void Start()
    {
        if (PlayerPrefs.GetInt(ConsentKey) == 1)
        {
            gameObject.SetActive(false);
            GameManager.current.ConsentConfirmation();
        }
    }
    
    public void AcceptConsent()
    {
        PlayerPrefs.SetInt(ConsentKey, 1);
        GameManager.current.ConsentConfirmation();
    }
    
  #if UNITY_EDITOR
    
    [Button]
    public void CleanConsentKey()
    {
        PlayerPrefs.DeleteKey(ConsentKey);
    }
    
    
    #endif
}
