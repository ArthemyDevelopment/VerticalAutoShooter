using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class EnemyMovement_Barrier : EnemyMovement
{

    public Vector3 StartingScale;
    public Vector2 MoveDownDistace;
    public float ScaleSize;
    public float MoveTime;
    public float ScaleTime;
    private Vector2 startPosition;
    private float startY;
    private float endValue;
    private float actY;

    private Vector2 startScale;
    private float startX;
    private float actX;
    protected override void OnEnable()
    {
        base.OnEnable();
        transform.localScale = StartingScale;
    }

    public override void Movement()
    {
        base.Movement();
        StartCoroutine(InitMoveFunction(MoveTime));
    }
    
    IEnumerator InitMoveFunction(float duration)
    {
        float time = 0;
        startPosition= transform.position;
        startY = transform.position.y;
        yield return endValue = startPosition.y - Random.Range(MoveDownDistace.x, MoveDownDistace.y); 

        while (time < duration)
        {
            actY = Mathf.Lerp(startY, endValue, time / duration);
            transform.position = new Vector2(startPosition.x, actY);
            time += Time.deltaTime;
            yield return null;
        }
        actY = endValue;
        transform.position = new Vector2(startPosition.x, actY);
        StartCoroutine(LateScaleFunction(ScaleTime));
    }
    
    IEnumerator LateScaleFunction(float duration)
    {
        float time = 0;
        startScale= transform.localScale;
        startX = transform.localScale.x;
        endValue = startScale.x + ScaleSize;

        while (time < duration)
        {
            actX = Mathf.Lerp(startX, endValue, time / duration);
            transform.localScale = new Vector2(actX, startScale.y);
            time += Time.deltaTime;
            yield return null;
        }
        actX = endValue;
        transform.localScale = new Vector2(actX, startScale.y);
    }
}
