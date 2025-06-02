
using UnityEngine;



public class EnemyMovement_BasicFalling : EnemyMovement
{
    public override void Movement()
    {
        base.Movement();
        rb.linearVelocity= Vector2.down*Speed;
    }
}
