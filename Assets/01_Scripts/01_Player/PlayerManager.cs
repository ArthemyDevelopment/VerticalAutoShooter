using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public PlayerController PC;
    public PlayerStats Stats;

    private void OnEnable()
    {
        PC.InitPlayerStats(Stats);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
