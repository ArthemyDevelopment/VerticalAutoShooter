
using System;
using UnityEngine;

public abstract class BasePlayerBullet : MonoBehaviour
{
    public Pools_Items thisBullet_Type;
    public float Damage;
    public float BulletSpeed;
    public Rigidbody2D rb;

    public virtual void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void FixedUpdate()
    {
        Movement();
    }



    public virtual void Movement()
    {
        rb.velocity = transform.TransformDirection(Vector2.up*BulletSpeed);
    }

    public virtual void OnHit(Action<float> DamageMethod)
    {
        Pools.current.StoreObject(thisBullet_Type,this.gameObject);
        DamageMethod(Damage);
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
