
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;


public class PlayerMovementController : PlayerStatController
{

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
        ActStat = BaseStat = stats.PlayerBaseMoveSpeed;
        MinModifierThreashold = stats.MinMoveModifierThreashold;
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
    
    public override void UpdateStat()
    {
        ActStat = BaseStat  * LastModifier;
    }
}
