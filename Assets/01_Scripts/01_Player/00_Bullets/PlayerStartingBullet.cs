
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
        
    }

    public override void OnHit(EnemyHealthManager ehm)
    {
        base.OnHit(ehm);
        
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }
}
