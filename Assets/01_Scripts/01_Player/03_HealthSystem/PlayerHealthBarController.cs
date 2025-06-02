using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarController : HealthManager
{
    [BoxGroup("Player health"), SerializeField] private bool IsHealthBarDeath = false;

    [BoxGroup("Player health"), SerializeField] private Image Gui_Bar;


    public override void SetHealth(int i)
    {
        base.SetHealth(i);
        IsHealthBarDeath = false;
    }

    public override void DeathBehaviour(AnalyticCustomEvent analyticEvent)
    {
        IsHealthBarDeath = true;
        GameManager.current.StopGame();

        AnalyticEvent_PlayerKilled deathEvent = new AnalyticEvent_PlayerKilled
        {
            entityName = OnDamageInfoAnalyticEvent.entityName,
            EnemyRemainingHealth = (OnDamageInfoAnalyticEvent as AnalyticEvent_PlayerDamaged).EnemyRemainingHealth,
            PowerUpName = (OnDamageInfoAnalyticEvent as AnalyticEvent_PlayerDamaged).PowerUpName,
            ShootingFireRate = (OnDamageInfoAnalyticEvent as AnalyticEvent_PlayerDamaged).ShootingFireRate,

        };
        
        AnalyticsService.Instance.RecordEvent(deathEvent);

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
        base.ResetHealth();
            return;
    }

    public override void ApplyDamage(float damage, AnalyticCustomEvent analyticEvent)
    {
        if (IsHealthBarDeath) return;
        
        AnalyticsService.Instance.RecordEvent(analyticEvent);
        
        base.ApplyDamage(damage,analyticEvent);
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
