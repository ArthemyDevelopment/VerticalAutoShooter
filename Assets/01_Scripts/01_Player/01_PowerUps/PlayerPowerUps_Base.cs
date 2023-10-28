
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(PolygonCollider2D))]
public class PlayerPowerUps_Base : MonoBehaviour
{
    public EventObserver EventObserver;
    private Rigidbody2D rb;

    public float FallSpeed;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity= Vector2.down*FallSpeed;
        EventObserver.OnResetGame += DestroyPowerUp;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            ApplyPowerUp(PlayerManager.current);
            DestroyPowerUp();
        }
        else if(col.CompareTag("BottomScreen"))
            DestroyPowerUp();
    }

    void DestroyPowerUp()
    {
        Destroy(this.gameObject);
    }

    protected virtual void ApplyPowerUp(PlayerManager PM)
    {
        
    }
}
