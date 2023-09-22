using System;

using System.Collections.Generic;

using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public abstract class IPlayerStates
{
    
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
public abstract class IMovementState : IPlayerStates
{
    public PlayerMovementController pc;
    
    public virtual void OnEnterState(PlayerMovementController controller)
    {
        pc = controller;
    }

}

[Serializable]
public abstract class IShootingState : IPlayerStates
{
    public PlayerShootingController pc;

    public List<ProjectileShooter> ProjectilesShooters;
    
    public virtual void OnEnterState(PlayerShootingController controller)
    {
        pc = controller;
        Debug.Log("Entering state "+this);
    }

}

#region MovementStates
[Serializable]
public class PlayerMovementState : IMovementState
{
    [SerializeField] private Vector2 HorizontalMove;

    public override void OnEnterState(PlayerMovementController movementController)
    {
        base.OnEnterState(movementController);
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
        pc.rb.velocityX = (-HorizontalMove.x + HorizontalMove.y)*pc.ActMoveSpeed;
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
public class PlayerDeathState : IMovementState
{
    public override void OnEnterState(PlayerMovementController movementController)
    {
        base.OnEnterState(movementController);
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
public class PlayerStartingIdleState: IMovementState
{
    public override void OnEnterState(PlayerMovementController movementController)
    {
        base.OnEnterState(movementController);
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

#endregion

#region ShootingStates

[Serializable]
public class PlayerSingleShoot : IShootingState
{
    public override void OnEnterState(PlayerShootingController controller)
    {
        base.OnEnterState(controller);
        ProjectilesShooters.Add(Object.Instantiate(pc.actPlayerBullet, pc.BulletStartingPoint.transform.position, pc.actPlayerBullet.transform.rotation, pc.BulletStartingPoint.transform).GetComponent<ProjectileShooter>());
        foreach (var shooter in ProjectilesShooters)
        {
            shooter.InitShooter(controller);
        }
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
        for (int i = 0; i < ProjectilesShooters.Count; i++)
        {
            ProjectilesShooters[i].StopShooter();
            Object.Destroy(ProjectilesShooters[i].gameObject);
        }
        ProjectilesShooters.Clear();
    }
}

[Serializable]
public class PlayerDobleShoot : IShootingState
{
    public override void OnEnterState(PlayerShootingController controller)
    {
        base.OnEnterState(controller);
        ProjectilesShooters.Add(Object.Instantiate(pc.actPlayerBullet, pc.BulletStartingPoint.transform.position,Quaternion.Euler(new Vector3(0,0,pc.actPlayerBullet.transform.rotation.z + 22.5f)) , pc.BulletStartingPoint.transform).GetComponent<ProjectileShooter>());
        ProjectilesShooters.Add(Object.Instantiate(pc.actPlayerBullet, pc.BulletStartingPoint.transform.position,Quaternion.Euler(new Vector3(0,0,pc.actPlayerBullet.transform.rotation.z - 22.5f)) , pc.BulletStartingPoint.transform).GetComponent<ProjectileShooter>());
        foreach (var shooter in ProjectilesShooters)
        {
            shooter.InitShooter(controller);
        }
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
        for (int i = 0; i < ProjectilesShooters.Count; i++)
        {
            ProjectilesShooters[i].StopShooter();
            Object.Destroy(ProjectilesShooters[i].gameObject);
        }
        ProjectilesShooters.Clear();
        
    }
}

[Serializable]
public class PlayerTripleShoot : IShootingState
{
    public override void OnEnterState(PlayerShootingController controller)
    {
        base.OnEnterState(controller);
        ProjectilesShooters.Add(Object.Instantiate(pc.actPlayerBullet, pc.BulletStartingPoint.transform.position,pc.actPlayerBullet.transform.rotation , pc.BulletStartingPoint.transform).GetComponent<ProjectileShooter>());
        ProjectilesShooters.Add(Object.Instantiate(pc.actPlayerBullet, pc.BulletStartingPoint.transform.position,Quaternion.Euler(new Vector3(0,0,pc.actPlayerBullet.transform.rotation.x + 45)) , pc.BulletStartingPoint.transform).GetComponent<ProjectileShooter>());
        ProjectilesShooters.Add(Object.Instantiate(pc.actPlayerBullet, pc.BulletStartingPoint.transform.position,Quaternion.Euler(new Vector3(0,0,pc.actPlayerBullet.transform.rotation.x - 45f)) , pc.BulletStartingPoint.transform).GetComponent<ProjectileShooter>());
        foreach (var shooter in ProjectilesShooters)
        {
            shooter.InitShooter(controller);
        }
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
        for (int i = 0; i < ProjectilesShooters.Count; i++)
        {
            ProjectilesShooters[i].StopShooter();
            Object.Destroy(ProjectilesShooters[i].gameObject);
        }
        ProjectilesShooters.Clear();
    }
}

[Serializable]
public class PlayerSideShoot : IShootingState
{
    public override void OnEnterState(PlayerShootingController controller)
    {
        base.OnEnterState(controller);
        ProjectilesShooters.Add(Object.Instantiate(pc.actPlayerBullet, pc.BulletStartingPoint.transform.position,pc.actPlayerBullet.transform.rotation , pc.BulletStartingPoint.transform).GetComponent<ProjectileShooter>());
        ProjectilesShooters.Add(Object.Instantiate(pc.actPlayerBullet, pc.BulletStartingPoint.transform.position,Quaternion.Euler(new Vector3(0,0,pc.actPlayerBullet.transform.rotation.x + 90)) , pc.BulletStartingPoint.transform).GetComponent<ProjectileShooter>());
        ProjectilesShooters.Add(Object.Instantiate(pc.actPlayerBullet, pc.BulletStartingPoint.transform.position,Quaternion.Euler(new Vector3(0,0,pc.actPlayerBullet.transform.rotation.x - 90)) , pc.BulletStartingPoint.transform).GetComponent<ProjectileShooter>());
        foreach (var shooter in ProjectilesShooters)
        {
            shooter.InitShooter(controller);
        }
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
        for (int i = 0; i < ProjectilesShooters.Count; i++)
        {
            ProjectilesShooters[i].StopShooter();
            Object.Destroy(ProjectilesShooters[i].gameObject);
        }
        ProjectilesShooters.Clear();
    }
}



#endregion

