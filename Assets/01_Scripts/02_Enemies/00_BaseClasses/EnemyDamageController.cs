
using UnityEngine;
using UnityEngine.Events;

public class EnemyDamageController : MonoBehaviour
{
    [SerializeField] private float Damage;
    public UnityEvent OnDamage;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerHealthBar"))
        {
            HitboxRecognitionSystem.ApplyDamage(col,Damage);
            OnDamage.Invoke();
        }
    }
}
