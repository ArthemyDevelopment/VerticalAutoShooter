
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [BoxGroup("Stats")][SerializeField] protected float BaseStat;
    [BoxGroup("Stats")][SerializeField]protected float LastModifier;
    [BoxGroup("Stats")][SerializeField]protected float MinModifierThreashold;
    [BoxGroup("Stats")]public float ActStat;
    
    public virtual void InitPlayerStats(PlayerStats stats)
    {
        
    }
    
    public virtual void SetBaseStat(float baseStat)
    {
        BaseStat = baseStat;
        UpdateStat();
    }
    
    public virtual void ApplyModifier(float modifier)
    {
        LastModifier *= modifier;
        if (LastModifier < MinModifierThreashold) LastModifier = MinModifierThreashold;
        UpdateStat();
    }

    public virtual void ResetModifier()
    {
        LastModifier = 1;
        UpdateStat();
    }

    public virtual void UpdateStat()
    {
        
    }
}
    

