
using Sirenix.OdinInspector;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    [BoxGroup("Basic Behavior")] protected bool CanShoot;
    [BoxGroup("Basic Behavior")] protected PlayerShootingController _controller; 
    
    public virtual void InitShooter(PlayerShootingController controller)
    {
        _controller = controller;
        CanShoot = true;
    }

    public virtual void StopShooter()
    {
        
    }
}
