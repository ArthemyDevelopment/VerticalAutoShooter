
using Sirenix.OdinInspector;
using UnityEngine;


public class PlayerMovementController : PlayerController
{
    [BoxGroup("PlayerStats")]
    [BoxGroup("PlayerStats/BaseStats")][SerializeField] private float BaseMoveSpeed;
    [BoxGroup("PlayerStats/ActStats")]public float ActMoveSpeed;
    [BoxGroup("PlayerStats")] public Rigidbody2D rb;


    private IMovementState _actState;
    [BoxGroup("Player states")]public IMovementState ActState
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

    public override void InitPlayerStats(PlayerStats stats)
    {
        ActMoveSpeed = BaseMoveSpeed = stats.PlayerBaseMoveSpeed;
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

    public override void ApplyModifier(float modifier)
    {
        ActMoveSpeed = BaseMoveSpeed * modifier;
    }

    public override void ResetModifier()
    {
        ActMoveSpeed = BaseMoveSpeed;
    }
}
