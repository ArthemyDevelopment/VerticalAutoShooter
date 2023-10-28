
using Sirenix.OdinInspector;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    [BoxGroup("Basic Behavior"),SerializeField] protected bool CanShoot;
    [BoxGroup("Basic Behavior"),SerializeField] protected float BaseFireRate= 1;
    [BoxGroup("Basic Behavior")] protected PlayerShootingController _controller;
    
    public virtual void InitShooter(PlayerShootingController controller)
    {
        _controller = controller;
        _controller.SetBaseStat(BaseFireRate);
        CanShoot = true;
    }

    public virtual void StopShooter()
    {
        CanShoot = false;
    }
}
