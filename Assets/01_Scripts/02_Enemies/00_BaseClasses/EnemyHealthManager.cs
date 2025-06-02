
using System;
using Sirenix.OdinInspector;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.Serialization;


public class EnemyHealthManager : HealthManager
{
    [FormerlySerializedAs("ScoreEvent")] [FormerlySerializedAs("EO")] [SerializeField] private EventObserver EventObserver;
    [BoxGroup("Stats"),SerializeField]public Pools_Items thisEnemy_Type;
    [BoxGroup("Stats"),SerializeField]protected Renderer HealthShader;


    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        EventObserver.OnResetGame += DestroyEnemy;
        ResetHealth();
    }

    private void OnDisable()
    {
        EventObserver.OnResetGame -= DestroyEnemy;
        
    }

    public override void DeathBehaviour(AnalyticCustomEvent analyticEvent)
    {
        if (ActHealth <= 0)
        {
            EventObserver.AddScore(1);
            if (analyticEvent != null)
            {
                analyticEvent.entityName = thisEnemy_Type.ToString();
            
                AnalyticsService.Instance.RecordEvent(analyticEvent);
            }
        }
        else
        {
            EventObserver.RestScore(BaseHealth);
            
        }
        DestroyEnemy();
    }

    void DestroyEnemy()
    {
        Pools.current.StoreObject(thisEnemy_Type, this.gameObject);

    }

    public override void ApplyDamage(float damage, AnalyticCustomEvent analyticEvent)
    {
        base.ApplyDamage(damage, analyticEvent);
    }

    public override void UpdateHealthGUI()
    {
        float temp = ScriptsTools.MapValues(ActHealth, 0, BaseHealth, 1, 0);
        HealthShader.material.SetFloat("_ClipUvRight", temp);
    }
    
    
}
