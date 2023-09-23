
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealthManager : MonoBehaviour
{

    [BoxGroup("Stats"),SerializeField]protected Pools_Items thisEnemy_Type;
    [BoxGroup("Stats"),SerializeField]protected float BaseHealth;
    [BoxGroup("Stats"),SerializeField, ReadOnly]private float _actHealth;
    public UnityEvent OnEnemyDeath;

    #if UNITY_EDITOR

    [FoldoutGroup("DEBUG")][Button]public void DEBUG_ApplyDamage(float damage){ApplyDamage(damage);}
    [FoldoutGroup("DEBUG")][Button]public void DEBUG_HealDamage(float damage){AddHealth(damage);}
    [FoldoutGroup("DEBUG")][Button]public void DEBUG_ResetHealth(){ResetHealth();}
    [FoldoutGroup("DEBUG")][Button] public void DEBUG_Kill() { ActHealth = 0;}

    #endif
    
    protected float ActHealth
    {
        get => _actHealth;
        set
        {
            _actHealth = value;
            CheckDeath();
            UpdateHealthGUI();
        }
    }

    private void OnEnable()
    {
        ResetHealth();
    }

    public void ResetHealth()
    {
        ActHealth = BaseHealth;
    }

    public void AddHealth(float heal)
    {
        ActHealth += heal;
    }

    public void ApplyDamage(float damage)
    {
        ActHealth -= damage;
    }

    public void CheckDeath()
    {
        if (ActHealth <= 0)
        {
            OnEnemyDeath.Invoke();
            Pools.current.StoreObject(thisEnemy_Type, this.gameObject);
        }
    }

    public void UpdateHealthGUI()
    {
        
    }
}
