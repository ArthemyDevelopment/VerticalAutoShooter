using System.Collections;

using Sirenix.OdinInspector;
using UnityEngine;

public class ProjectileShooter_Basic : ProjectileShooter
{
    [BoxGroup("Local Behaviour"), SerializeField] private GameObject Bullet;
    private Coroutine ShootingLoopRoutine;
    
    public override void InitShooter(PlayerShootingController controller)
    {
        base.InitShooter(controller);
        ShootingLoopRoutine = StartCoroutine(ShootingLoop());
    }
    
    
    private IEnumerator ShootingLoop()
    {
        while (true)
        {
            yield return ScriptsTools.GetWait(_controller.ActFireRate);
            Instantiate(Bullet, transform.position, transform.rotation);
        }
    }

    public override void StopShooter()
    {
        StopCoroutine(ShootingLoopRoutine);
    }
}
