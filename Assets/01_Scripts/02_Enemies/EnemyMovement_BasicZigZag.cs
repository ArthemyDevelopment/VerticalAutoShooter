
using System;
using System.Numerics;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class EnemyMovement_BasicZigZag : EnemyMovement
{
    [BoxGroup("ZigZag Movement")] public float ZigZagDistance;
    [BoxGroup("ZigZag Movement")] public Vector2 HorizontalSpeedRange;
    [BoxGroup("ZigZag Movement")] public float HorizontalSpeed;

    [BoxGroup("ZigZag Movement")] public Directions MoveDir;

    private Vector2 MoveVector;
    private Vector2 StartPosition;

    protected override void OnEnable()
    {
        base.OnEnable();
        HorizontalSpeed = Random.Range(HorizontalSpeedRange.x, HorizontalSpeedRange.y);
        StartPosition = transform.position;
    }

    public void Update()
    {
        CheckHorPosition();
    }

    public override void Movement()
    {
        base.Movement();
        MoveVector.y = -Speed;
        SetSpeed();
        rb.velocity = MoveVector;
    }

    public void CheckHorPosition()
    {
        switch (MoveDir)
        {
            case Directions.right:
                if (transform.position.x >= StartPosition.x + ZigZagDistance)
                {
                    ChangeDir();
                }
                break;
            case Directions.left:
                if (transform.position.x <= StartPosition.x - ZigZagDistance)
                {
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
                StartPosition = transform.position + Vector3.left * ZigZagDistance;
                MoveDir = Directions.left;
                SetSpeed();
                rb.velocity = MoveVector;
                break;
            case Directions.left:
                StartPosition = transform.position + Vector3.right * ZigZagDistance;
                MoveDir = Directions.right;
                SetSpeed();
                rb.velocity = MoveVector;
                break;
        }
    }

    void SetSpeed()
    {
        switch (MoveDir)
        {
            case Directions.right:
                MoveVector.x = HorizontalSpeed;
                break;
            case Directions.left:
                MoveVector.x = -HorizontalSpeed;
                break;
        }
    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("ScreenBorder"))
        {
            ChangeDir();
        }
    }
}
