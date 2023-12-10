using System;
using UnityEngine;

public class PlayerStartingBullet : BasePlayerBullet
{
    public override void OnEnable()
    {
        base.OnEnable();
    }
    
    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }


    public override void Movement()
    {
        base.Movement();
        rb.velocity = transform.TransformDirection(Vector2.up*BulletSpeed);
    }

    public override void OnHit(Action<float> DamageMethod)
    {
        base.OnHit(DamageMethod);
        
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }
}
