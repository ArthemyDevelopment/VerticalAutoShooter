using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour, IPlayerController
{
    public List<PlayerHealthBarController> HealthBars= new List<PlayerHealthBarController>();
    


    public void InitPlayerStats(PlayerStats stats)
    {
        foreach (PlayerHealthBarController HealthBar in HealthBars)
        {
            HealthBar.SetHealth(stats.PlayerBaseHealth);
        }
    }
}
