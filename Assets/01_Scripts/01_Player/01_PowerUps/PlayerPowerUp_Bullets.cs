using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUp_Bullets : PlayerPowerUps_Base
{
    public Pools_Items PlayerBullets;
    
    protected override void ApplyPowerUp(PlayerManager PM)
    {
        base.ApplyPowerUp(PM);
        PM.shootingController.actPlayerBullet = PlayerBullets;
    }
}
