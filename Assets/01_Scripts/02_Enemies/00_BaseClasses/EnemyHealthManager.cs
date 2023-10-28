
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;


public class EnemyHealthManager : HealthManager
{
    [FormerlySerializedAs("ScoreEvent")] [FormerlySerializedAs("EO")] [SerializeField] private EventObserver EventObserver;
    [BoxGroup("Stats"),SerializeField]protected Pools_Items thisEnemy_Type;
    [BoxGroup("Stats"),SerializeField]protected Renderer HealthShader;


    protected override void Awake()
    {
        base.Awake();
        EventObserver.OnResetGame += DestroyEnemy;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        ResetHealth();
    }

    public override void DeathBehaviour()
    {
        if(ActHealth<=0)EventObserver.AddScore(BaseHealth);
        else EventObserver.RestScore(BaseHealth);
        DestroyEnemy();
    }

    void DestroyEnemy()
    {
        Pools.current.StoreObject(thisEnemy_Type, this.gameObject);
    }

    public override void UpdateHealthGUI()
    {
        float temp = ScriptsTools.MapValues(ActHealth, 0, BaseHealth, 1, 0);
        HealthShader.material.SetFloat("_ClipUvRight", temp);
    }
}
