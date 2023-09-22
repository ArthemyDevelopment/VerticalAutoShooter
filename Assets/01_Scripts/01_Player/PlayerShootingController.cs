using System;
using System.Collections;

using Sirenix.OdinInspector;
using UnityEngine;

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
    
    [BoxGroup("Stats")][SerializeField] private float BaseFireRate;
    [BoxGroup("Stats")]public float ActFireRate;
    [BoxGroup("Projectiles"), SerializeField] public GameObject actPlayerBullet;
    [BoxGroup("Projectiles"), SerializeField] public Transform BulletStartingPoint;


    public override void InitPlayerStats(PlayerStats stats)
    {
        ActFireRate = BaseFireRate = stats.PlayerBaseFireRate;
        ActShootingState = SingleShootState;
    }

    public void ChangeShootingState(PlayerShootingStates state)
    {
        switch (state)
        {
            case PlayerShootingStates.Single:
                ActShootingState = SingleShootState;
                Debug.Log("Set single shoot state");
                break;
            case PlayerShootingStates.Double:
                ActShootingState = DobleShootState;
                Debug.Log("Set doble shoot state");
                break;
            case PlayerShootingStates.Triple:
                ActShootingState = TripleShootState;
                Debug.Log("Set triple shoot state");
                break;
            case PlayerShootingStates.Side:
                ActShootingState = SideShootState;
                Debug.Log("Set side shoot state");
                break;
        }
    }
    
    public override void ApplyModifier(float modifier)
    {
        base.ApplyModifier(modifier);
        ActFireRate = BaseFireRate * modifier;
    }

    public override void ResetModifier()
    {
        base.ResetModifier();
        ActFireRate = BaseFireRate;
    }


}
