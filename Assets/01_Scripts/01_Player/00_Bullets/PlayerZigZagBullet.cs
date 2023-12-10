using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZigZagBullet : BasePlayerBullet
{
    [SerializeField] private float HorizontalSpeed;
    [SerializeField] private float HorizontalDistance;
    [SerializeField] private Directions MoveDir;
    
    private Vector2 MoveVector;
    private Vector2 StartPosition;
    
    public override void OnEnable()
    {
        base.OnEnable();
        StartPosition = transform.position;
    }
    
    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void Update()
    {
        //CheckHorPosition();
    }


    public override void Movement()
    {
        base.Movement();
        rb.velocity = transform.TransformDirection(Vector2.up*BulletSpeed);
        //SetSpeed();
        
        
    }

    public override void OnHit(Action<float> DamageMethod)
    {
        base.OnHit(DamageMethod);
        
    }
    
    
    public void CheckHorPosition()
    {
        Debug.Log("CheckHor");
        switch (MoveDir)
        {
            case Directions.right:
                if (transform.position.x >= StartPosition.x + HorizontalDistance)
                {
                    Debug.Log("CheckHor Right");
                    ChangeDir();
                }
                break;
            case Directions.left:
                if (transform.position.x <= StartPosition.x - HorizontalDistance)
                {
                    Debug.Log("CheckHor Left");
                    ChangeDir();
                }
                break;
        }
    }
    
    public void ChangeDir()
    {
        
        switch (MoveDir)
        {
            case Directions.right:
                MoveDir = Directions.left;
                
                break;
            case Directions.left:
                MoveDir = Directions.right;
                
                break;
        }
    }

    void SetSpeed()
    {
        switch (MoveDir)
        {
            case Directions.right:
                MoveVector = transform.TransformDirection((Vector3.up*BulletSpeed));
                break;
            case Directions.left:
                MoveVector = transform.TransformDirection((Vector3.up*BulletSpeed));
                break;
        }
        rb.velocity = MoveVector;
    }
    
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            OnHit(HitboxRecognitionSystem.GetDamage(other));
        }
        
        else if (other.CompareTag("OutOfScreen"))
        {
            Pools.current.StoreObject(thisBullet_Type,this.gameObject);
        }

    }
}
