
using System;
using UnityEngine;

public abstract class BasePlayerBullet : MonoBehaviour
{
    public Pools_Items ActPlayerShooter_Type;
    
    public Pools_Items thisBullet_Type;
    public float Damage;
    public float BulletSpeed;
    public Rigidbody2D rb;

    public virtual void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        ActPlayerShooter_Type = PlayerManager.current.shootingController.actPlayerShooter;
    }

    public virtual void FixedUpdate()
    {
        Movement();
    }



    public virtual void Movement()
    {
        
    }

    public virtual void OnHit(Action<float,AnalyticCustomEvent> DamageMethod)
    {
        Pools.current.StoreObject(thisBullet_Type,this.gameObject);

        AnalyticEvent_EnemyKilled EnemyKilledEvent = new AnalyticEvent_EnemyKilled
        {
            PowerUpName = thisBullet_Type.ToString(),
            BulletName = ActPlayerShooter_Type.ToString(),
        };
    
        
        DamageMethod(Damage, EnemyKilledEvent);
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            OnHit(HitboxRecognitionSystem.GetDamage(other));
            
            
            
            
        }
        
        else if (other.CompareTag("OutOfScreen")||other.CompareTag("ScreenBorder"))
        {
            Pools.current.StoreObject(thisBullet_Type,this.gameObject);
        }

    }
}
