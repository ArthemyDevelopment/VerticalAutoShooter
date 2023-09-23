using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUp_FireRate : PlayerPowerUps_Base
{
    public float FireRateModifier;

    protected override void ApplyPowerUp(PlayerManager PM)
    {
        base.ApplyPowerUp(PM);
        PM.ChangeFireRate(FireRateModifier);
    }
}
