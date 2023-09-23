using System;
using System.Collections;

using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerShootingController : PlayerController
{
    
    [FoldoutGroup("State")] private IShootingState _ShootingState;
    [FoldoutGroup("State"),SerializeField] private PlayerSingleShoot SingleShootState;
    [FoldoutGroup("State"),SerializeField] private PlayerDobleShoot DobleShootState;
    [FoldoutGroup("State"),SerializeField] private PlayerTripleShoot TripleShootState;
    [FoldoutGroup("State"),SerializeField] private PlayerSideShoot SideShootState;
    [FoldoutGroup("State")]  public IShootingState ActShootingState
    {
        get => _ShootingState;
        set
        {
            if(_ShootingState!=null) _ShootingState.OnExtiState();
            _ShootingState = value;
            if (_ShootingState != null) _ShootingState.OnEnterState(this);
        }
    }
    
    [BoxGroup("Stats")][SerializeField] protected float StateFireRateModifier;
    [BoxGroup("Projectiles"), SerializeField] public Pools_Items actPlayerShooter;
    [BoxGroup("Projectiles"), SerializeField] public Pools_Items actPlayerBullet;
    [BoxGroup("Projectiles"), SerializeField] public Transform BulletStartingPoint;


    public override void InitPlayerStats(PlayerStats stats)
    {
        ActStat = BaseStat = stats.PlayerBaseFireRate;
        actPlayerBullet = stats.PlayerDefaultBullet;
        actPlayerShooter = stats.PlayerDefaultShooter;
        ActShootingState = SingleShootState;
    }

    public void ChangeShootingState(PlayerShootingStates state)
    {
        switch (state)
        {
            case PlayerShootingStates.Single:
                ActShootingState = SingleShootState;
                break;
            case PlayerShootingStates.Double:
                ActShootingState = DobleShootState;
                break;
            case PlayerShootingStates.Triple:
                ActShootingState = TripleShootState;
                break;
            case PlayerShootingStates.Side:
                ActShootingState = SideShootState;
                break;
        }

        StateFireRateModifier = ActShootingState.StateFireRateModifier;
        UpdateStat();
    }

    public override void UpdateStat()
    {
        ActStat = (BaseStat/StateFireRateModifier) / LastModifier;
    }

}
