using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarController : HealthManager
{
    [BoxGroup("Player health"), SerializeField] private bool IsHealthBarDeath = false;

    [BoxGroup("Player health"), SerializeField] private Image Gui_Bar;


    public override void SetHealth(int i)
    {
        base.SetHealth(i);
    }

    public override void DeathBehaviour()
    {
        IsHealthBarDeath = true;
    }

    public override void AddHealth(float heal)
    {
        if (!IsHealthBarDeath)
        {
            base.AddHealth(heal);
            return;
        }
        //TODO: Behaviour when bar is death
        
    }

    public override void ResetHealth()
    {
        if (!IsHealthBarDeath)
        {
            base.ResetHealth();
            return;
        } 
        
        //TODO: Behaviour when bar is death
    }

    public override void ApplyDamage(float damage)
    {
        if (IsHealthBarDeath) return;
        
        base.ApplyDamage(damage);
    }

    public void ReviveHealthBar()
    {
        
    }

    public override void UpdateHealthGUI()
    {
        float temp = ScriptsTools.MapValues(ActHealth, 0, BaseHealth, 0, 1);
        Gui_Bar.fillAmount = temp;
    }
}
