using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [BoxGroup("PlayerStats")]
    [BoxGroup("PlayerStats/BaseStats")][SerializeField] private float BaseMoveSpeed;
    [BoxGroup("PlayerStats/ActStats")]public float ActMoveSpeed;
    [BoxGroup("PlayerStats/BaseStats")][SerializeField] private float BaseFireRate;
    [BoxGroup("PlayerStats/ActStats")]public float ActFireRate;
    [BoxGroup("PlayerStats"), SerializeField] private BasePlayerBullet actPlayerBullet;
    [BoxGroup("PlayerStats")] public Rigidbody2D rb;


    private IPlayerStates _actState;
    [BoxGroup("Player states")]public IPlayerStates ActState
    {
        get => _actState;
        set
        {
            if(_actState!=null)
                _actState.OnExtiState();
            _actState = value;
            if(_actState!=null)
                _actState.OnEnterState(this);
        }
    }

    [BoxGroup("Player states"),SerializeField] private PlayerMovementState PlayerMovement;
    [BoxGroup("Player states"),SerializeField] private PlayerDeathState PlayerDeath;
    [BoxGroup("Player states"), SerializeField] private PlayerStartingIdleState PlayerStartingIdle;

    public void InitPlayerStats(PlayerStats stats)
    {
        ActMoveSpeed = BaseMoveSpeed = stats.PlayerBaseMoveSpeed;
        ActFireRate = BaseFireRate = stats.PlayerBaseFireRate;
        SetPlayerMovement();
    }


    
    void Update()
    {
        if(ActState!=null)
            ActState.OnUpdate();
    }

    private void FixedUpdate()
    {
        if(ActState!=null)
             ActState.OnFixedUpdate();
    }

    public void SetPlayerMovement()
    {
        ActState = PlayerMovement;
    }

    public void SetPlayerDeath()
    {
        ActState = PlayerDeath;
    }

    public void SetPlayerStartingIdle()
    {
        ActState = PlayerStartingIdle;
        
    }
}
