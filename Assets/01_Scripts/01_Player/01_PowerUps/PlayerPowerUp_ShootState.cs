using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUp_ShootState : PlayerPowerUps_Base
{
    public PlayerShootingStates stateToChange;

    protected override void ApplyPowerUp(PlayerManager PM)
    {
        base.ApplyPowerUp(PM);
        PM.ChangeShootingState(stateToChange);
    }
}
