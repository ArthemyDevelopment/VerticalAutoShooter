
using UnityEngine;

public abstract class BasePlayerBullet : MonoBehaviour
{
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

    public virtual void OnHit(EnemyHealthManager ehm)
    {
        Destroy(this.gameObject);
        ehm.ApplyDamage(Damage);
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            OnHit(other.GetComponent<EnemyHealthManager>());
        }
        
        else if (other.CompareTag("OutOfScreen"))
        {
            Destroy(this.gameObject);
        }
    }
}
