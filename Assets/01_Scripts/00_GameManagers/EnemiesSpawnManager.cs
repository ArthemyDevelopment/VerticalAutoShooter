using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemiesSpawnManager : SingletonManager<EnemiesSpawnManager>
{
    [BoxGroup("SpawnPoints"),SerializeField] private List<Transform> SpawnPoints;
    [BoxGroup("SpawnPoints"), SerializeField] private bool CanSpawn;
    [BoxGroup("SpawnPoints"), SerializeField] private float SpawnRate;
    private Coroutine SpawnerLoop;
    [BoxGroup("Enemies")] public List<GameObject> EnemiesToSpawn;

    [FoldoutGroup("DEBUG")][Button] public void DEBUG_InitSpawner(){InitSpawner();}
    [FoldoutGroup("DEBUG")][Button] public void DEBUG_StopSpawner(){StopSpawner();}

    private void OnEnable()
    {
        InitSpawner();
    }

    void InitSpawner()
    {
        CanSpawn = true;
        SpawnerLoop= StartCoroutine(SpawnLoop());
    }

    void StopSpawner()
    {
        CanSpawn = false;
        StopCoroutine(SpawnerLoop);
    }


    IEnumerator SpawnLoop()
    {
        while (CanSpawn)
        {
            yield return ScriptsTools.GetWait(SpawnRate);
            int randPoint = Random.Range(0, SpawnPoints.Count);
            int randEnemy = Random.Range(0, EnemiesToSpawn.Count);

            Instantiate(EnemiesToSpawn[randEnemy], SpawnPoints[randPoint].position, Quaternion.identity);
        }
    }

}
