
using UnityEngine;



public class EnemyMovement_BasicFalling : EnemyMovement
{
    public override void Movement()
    {
        base.Movement();
        rb.velocity= Vector2.down*Speed;
    }
}
