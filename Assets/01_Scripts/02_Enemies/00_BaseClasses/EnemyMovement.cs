
using Sirenix.OdinInspector;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(PolygonCollider2D))]
public class EnemyMovement : MonoBehaviour
{
    protected Rigidbody2D rb;
    [BoxGroup("Movement Stats"),SerializeField]protected float baseSpeed;
    protected float Speed;

    [FoldoutGroup("DEBUG")][Button]public void DEBUG_ChangeSpeed(float newSpeed){ChangeSpeed(newSpeed);}
    [FoldoutGroup("DEBUG")][Button]public void DEBUG_ResetSpeed(){ResetSpeed();}
    [FoldoutGroup("DEBUG")][Button]public void DEBUG_StartMovement(){StartMovement();}
    [FoldoutGroup("DEBUG")][Button] public void DEBUG_StopMovement() { StopMovement();}


    protected virtual void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        StartMovement();
    }




    public virtual void Movement()
    {
        
    }

    public virtual void StartMovement()
    {
        ResetSpeed();
        Movement();
    }

    public virtual void StopMovement()
    {
        Speed = 0;
    }

    public virtual void ChangeSpeed(float newSpeed)
    {
        Speed = newSpeed;
    }

    public virtual void ResetSpeed()
    {
        Speed = baseSpeed;
    }


}


