using System.Collections;

using Sirenix.OdinInspector;
using UnityEngine;

public class ProjectileShooter_Basic : ProjectileShooter
{
    
    private Coroutine ShootingLoopRoutine;
    
    public override void InitShooter(PlayerShootingController controller)
    {
        base.InitShooter(controller);
        ShootingLoopRoutine = StartCoroutine(ShootingLoop());
    }
    
    
    private IEnumerator ShootingLoop()
    {
        while (CanShoot)
        {
            GameObject temp = Pools.current.GetObject(_controller.actPlayerBullet);
            temp.transform.position = transform.position;
            temp.transform.rotation = transform.rotation;
            temp.SetActive(true);
            //Debug.Log(_controller.ActStat);
            yield return ScriptsTools.GetWait(_controller.ActStat);
        }
    }

    public override void StopShooter()
    {
        StopCoroutine(ShootingLoopRoutine);
    }
}
