
using Sirenix.OdinInspector;
using UnityEngine;


public class EnemyHealthManager : HealthManager
{
    [SerializeField] private EventObserver EO;
    [BoxGroup("Stats"),SerializeField]protected Pools_Items thisEnemy_Type;
    [BoxGroup("Stats"),SerializeField]protected Renderer HealthShader;

        
    public override void DeathBehaviour()
    {
        if(ActHealth<=0)EO.AddScore(BaseHealth);
        else EO.RestScore(BaseHealth);
        Pools.current.StoreObject(thisEnemy_Type, this.gameObject);
    }

    public override void UpdateHealthGUI()
    {
        float temp = ScriptsTools.MapValues(ActHealth, 0, BaseHealth, 1, 0);
        HealthShader.material.SetFloat("_ClipUvRight", temp);
    }
}
