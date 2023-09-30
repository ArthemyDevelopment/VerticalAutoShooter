using System;

using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
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

    [MinValue(0.001f)]public float StateFireRateModifier;
    
    public virtual void OnEnterState(PlayerShootingController controller)
    {
        pc = controller;
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
        pc.rb.velocityX = (-HorizontalMove.x + HorizontalMove.y)*pc.ActStat;
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
        GameObject temp = Pools.current.GetObject(pc.actPlayerShooter);
        temp.transform.position = pc.BulletStartingPoint.position;
        temp.transform.parent = pc.BulletStartingPoint;
        temp.transform.rotation=Quaternion.Euler(0,0,0);
        temp.SetActive(true);
        ProjectilesShooters.Add(temp.GetComponent<ProjectileShooter>());
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
            ProjectilesShooters[i].gameObject.SetActive(false);
            Pools.current.StoreObject(pc.actPlayerShooter, ProjectilesShooters[i].gameObject);
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
        GameObject temp = Pools.current.GetObject(pc.actPlayerShooter);
        temp.transform.position = pc.BulletStartingPoint.position;
        temp.transform.parent = pc.BulletStartingPoint;
        temp.transform.rotation=Quaternion.Euler(0,0,22.5f);
        temp.SetActive(true);
        
        GameObject temp1 = Pools.current.GetObject(pc.actPlayerShooter);
        temp1.transform.position = pc.BulletStartingPoint.position;
        temp1.transform.parent = pc.BulletStartingPoint;
        temp1.transform.rotation=Quaternion.Euler(0,0,-22.5f);
        temp1.SetActive(true);
        
        ProjectilesShooters.Add(temp.GetComponent<ProjectileShooter>());
        ProjectilesShooters.Add(temp1.GetComponent<ProjectileShooter>());
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
            ProjectilesShooters[i].gameObject.SetActive(false);
            Pools.current.StoreObject(pc.actPlayerShooter, ProjectilesShooters[i].gameObject);
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
        GameObject temp = Pools.current.GetObject(pc.actPlayerShooter);
        temp.transform.position = pc.BulletStartingPoint.position;
        temp.transform.parent = pc.BulletStartingPoint;
        temp.transform.rotation=Quaternion.Euler(0,0,45f);
        temp.SetActive(true);
        
        GameObject temp1 = Pools.current.GetObject(pc.actPlayerShooter);
        temp1.transform.position = pc.BulletStartingPoint.position;
        temp1.transform.parent = pc.BulletStartingPoint;
        temp1.transform.rotation=Quaternion.Euler(0,0,0f);
        temp1.SetActive(true);
        
        GameObject temp2 = Pools.current.GetObject(pc.actPlayerShooter);
        temp2.transform.position = pc.BulletStartingPoint.position;
        temp2.transform.parent = pc.BulletStartingPoint;
        temp2.transform.rotation=Quaternion.Euler(0,0,-45f);
        temp2.SetActive(true);
        
        ProjectilesShooters.Add(temp.GetComponent<ProjectileShooter>());
        ProjectilesShooters.Add(temp1.GetComponent<ProjectileShooter>());
        ProjectilesShooters.Add(temp2.GetComponent<ProjectileShooter>());
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
            ProjectilesShooters[i].gameObject.SetActive(false);
            Pools.current.StoreObject(pc.actPlayerShooter, ProjectilesShooters[i].gameObject);
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
        GameObject temp = Pools.current.GetObject(pc.actPlayerShooter);
        temp.transform.position = pc.BulletStartingPoint.position;
        temp.transform.parent = pc.BulletStartingPoint;
        temp.transform.rotation=Quaternion.Euler(0,0,90f);
        temp.SetActive(true);
        
        GameObject temp1 = Pools.current.GetObject(pc.actPlayerShooter);
        temp1.transform.position = pc.BulletStartingPoint.position;
        temp1.transform.parent = pc.BulletStartingPoint;
        temp1.transform.rotation=Quaternion.Euler(0,0,0f);
        temp1.SetActive(true);
        
        GameObject temp2 = Pools.current.GetObject(pc.actPlayerShooter);
        temp2.transform.position = pc.BulletStartingPoint.position;
        temp2.transform.parent = pc.BulletStartingPoint;
        temp2.transform.rotation=Quaternion.Euler(0,0,-90f);
        temp2.SetActive(true);
        
        ProjectilesShooters.Add(temp.GetComponent<ProjectileShooter>());
        ProjectilesShooters.Add(temp1.GetComponent<ProjectileShooter>());
        ProjectilesShooters.Add(temp2.GetComponent<ProjectileShooter>());
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
            ProjectilesShooters[i].gameObject.SetActive(false);
            Pools.current.StoreObject(pc.actPlayerShooter, ProjectilesShooters[i].gameObject);
        }
        ProjectilesShooters.Clear();
    }
}



#endregion

