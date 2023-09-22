
using Sirenix.OdinInspector;
using UnityEngine;

public class EnemyMovement_BasicZigZag : EnemyMovement
{
    [BoxGroup("ZigZag Movement")] public float ZigZagDistance;
    [BoxGroup("ZigZag Movement")] public float HorizontalSpeed;
    public enum Directions { right, left, }
    [BoxGroup("ZigZag Movement")] public Directions MoveDir;

    private Vector2 MoveVector;
    private Vector2 StartPosition;

    protected override void OnEnable()
    {
        base.OnEnable();
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
        MoveVector.x = HorizontalSpeed;
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
                MoveVector.x = -HorizontalSpeed;
                MoveDir = Directions.left;
                rb.velocity = MoveVector;
                break;
            case Directions.left:
                StartPosition = transform.position + Vector3.right * ZigZagDistance;
                MoveVector.x = HorizontalSpeed;
                MoveDir = Directions.right;
                rb.velocity = MoveVector;
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
