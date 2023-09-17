using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class IPlayerStates
{
    public PlayerController pc;

    public virtual void OnEnterState(PlayerController controller)
    {
        pc = controller;
    }

    public virtual void OnUpdate()
    {
        
    }

    public virtual void OnFixedUpdate()
    {
        
    }

    public virtual void OnExtiState()
    {
        
    }
}

[Serializable]
public class PlayerMovementState : IPlayerStates
{
    [SerializeField] private Vector2 HorizontalMove;
    
    public override void OnEnterState(PlayerController controller)
    {
        base.OnEnterState(controller);
        UserInputManager.OnLeftGetInputDown += SetPlayerMoveLeft;
        UserInputManager.OnRightGetInputDown += SetPlayerMoveRight;
        UserInputManager.OnLeftGetInputUp += ResetPlayerMoveLeft;
        UserInputManager.OnRightGetInputUp += ResetPlayerMoveRight;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        pc.rb.velocityX = (-HorizontalMove.x + HorizontalMove.y)*pc.ActMoveSpeed*100;
    }

    public void SetPlayerMoveLeft()
    {
        HorizontalMove.x = 1;
    }

    public void ResetPlayerMoveLeft()
    {
        HorizontalMove.x = 0;
    }

    public void SetPlayerMoveRight()
    {
        HorizontalMove.y = 1;
    }
    
    public void ResetPlayerMoveRight()
    {
        HorizontalMove.y = 0;
    }
    public override void OnExtiState()
    {
        base.OnExtiState();
    }
}

[Serializable]
public class PlayerDeathState : IPlayerStates
{
    public override void OnEnterState(PlayerController controller)
    {
        base.OnEnterState(controller);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
    }

    public override void OnExtiState()
    {
        base.OnExtiState();
    }
}

[Serializable]
public class PlayerStartingIdleState: IPlayerStates
{
    public override void OnEnterState(PlayerController controller)
    {
        base.OnEnterState(controller);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
    }

    public override void OnExtiState()
    {
        base.OnExtiState();
    }
}
