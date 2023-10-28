using System;
using System.Collections;

using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerShootingController : PlayerStatController
{
    [FoldoutGroup("State")] [SerializeField] private float RepeatedStateBuff;
    [FoldoutGroup("State")] private IShootingState _ShootingState;
    [FoldoutGroup("State"),SerializeField] private PlayerSingleShoot SingleShootState;
    [FoldoutGroup("State"),SerializeField] private PlayerDobleShoot DobleShootState;
    [FoldoutGroup("State"),SerializeField] private PlayerTripleShoot TripleShootState;
    [FoldoutGroup("State"),SerializeField] private PlayerSideShoot SideShootState;
    [FoldoutGroup("State"),SerializeField] private NoShooter DeathState;
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
        BaseStat = stats.PlayerBaseFireRate;
        actPlayerBullet = stats.PlayerDefaultBullet;
        actPlayerShooter = stats.PlayerDefaultShooter;
        RepeatedStateBuff = stats.PlayerRepeatedShootingStateBuff;
        MinModifierThreashold = stats.MinFireRateModifierThreashold;
        ActStat = BaseStat;
        LastModifier = 1;
        StateFireRateModifier = 1;
        ActShootingState = SingleShootState;
    }

    public void ChangeShootingState(PlayerShootingStates state)
    {
        switch (state)
        {
            case PlayerShootingStates.Single:
                if (ActShootingState == SingleShootState) ApplyModifier(RepeatedStateBuff);
                else ActShootingState = SingleShootState;
                break;
            case PlayerShootingStates.Double:
                if (ActShootingState == DobleShootState) ApplyModifier(RepeatedStateBuff);
                else ActShootingState = DobleShootState;
                break;
            case PlayerShootingStates.Triple:
                if (ActShootingState == TripleShootState) ApplyModifier(RepeatedStateBuff);
                else ActShootingState = TripleShootState;
                break;
            case PlayerShootingStates.Side:
                if (ActShootingState == SideShootState) ApplyModifier(RepeatedStateBuff);
                else ActShootingState = SideShootState;
                break;
            case PlayerShootingStates.Death:
                ActShootingState = DeathState;
                break;
        }

        StateFireRateModifier = ActShootingState.StateFireRateModifier;
        UpdateStat();
    }

    public override void UpdateStat()
    {
        ActStat = (BaseStat/StateFireRateModifier) / LastModifier;
    }

    public void StopShooting()
    {
        ChangeShootingState(PlayerShootingStates.Death);
    }

}
