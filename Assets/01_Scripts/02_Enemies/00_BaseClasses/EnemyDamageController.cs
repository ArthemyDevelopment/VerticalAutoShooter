
using UnityEngine;
using UnityEngine.Events;

public class EnemyDamageController : MonoBehaviour
{
    [SerializeField] private float Damage;
    public UnityEvent<AnalyticCustomEvent> OnDamage;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerHealthBar"))
        {
            EnemyHealthManager healthManager = GetComponent<EnemyHealthManager>();

            AnalyticEvent_PlayerDamaged analyticEvent = new AnalyticEvent_PlayerDamaged
            {
                entityName = healthManager.thisEnemy_Type.ToString(),
                EnemyRemainingHealth = healthManager.ActHealth,
                PowerUpName = PlayerManager.current.shootingController.actPlayerShooter.ToString(),
                ShootingFireRate = PlayerManager.current.shootingController.ActStat
            };
            
            
            HitboxRecognitionSystem.ApplyDamage(col,Damage, analyticEvent);
            OnDamage.Invoke(null);
        }
    }
}
