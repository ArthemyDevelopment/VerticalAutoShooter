using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

//[DefaultExecutionOrder(-1)]
public class EnemiesSpawnManager : SingletonManager<EnemiesSpawnManager>
{
    [FormerlySerializedAs("ResetGameEvent")] public EventObserver EventObserver;

    [BoxGroup("Stats"),SerializeField] private List<Transform> SpawnPoints;
    [BoxGroup("Stats"), SerializeField] private bool CanSpawn;

    [BoxGroup("Stats")] public SpawnTier ActSpawnTier;

    private Coroutine SpawnerLoop;
    [FoldoutGroup("DEBUG")][Button] public void DEBUG_InitSpawner(){InitSpawner();}
    [FoldoutGroup("DEBUG")][Button] public void DEBUG_StopSpawner(){StopSpawner();}

    private void OnEnable()
    {
        //InitSpawner();
        EventObserver.OnResetGame += StopSpawner;
        EventObserver.OnStartGame += InitSpawner;
    }

    public void InitSpawner()
    {
        CanSpawn = true;
        SpawnerLoop= StartCoroutine(SpawnLoop());
    }

    public void StopSpawner()
    {
        CanSpawn = false;
        StopCoroutine(SpawnerLoop);
    }


    IEnumerator SpawnLoop()
    {
        while (CanSpawn)
        {
            int randPoint = Random.Range(0, SpawnPoints.Count);

            GameObject temp = Pools.current.GetObject(ActSpawnTier.GetEnemy());
            temp.transform.position = SpawnPoints[randPoint].position;
            temp.SetActive(true);
            temp.GetComponent<Rigidbody2D>().WakeUp();
            yield return ScriptsTools.GetWait(ActSpawnTier.SpawnRate);
            
        }
    }

}
