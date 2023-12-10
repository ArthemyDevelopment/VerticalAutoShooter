using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "NewSpawnTier", menuName = "Custom Scriptables/SpawnTier")]
public class SpawnTier : ScriptableObject
{
    
    [BoxGroup("Stats")] public float SpawnRate;
    [BoxGroup("Stats")] public List<EnemyChance> EnemiesToSpawn;

    public Pools_Items GetEnemy()
    {
        //Debug.Log(name);
        int maxChances=0;
        foreach (EnemyChance i in EnemiesToSpawn)
        {
            maxChances += i.chance;
        }

        int roll = Random.Range(0, maxChances+1);
        int chanceSum = 0;
        
        foreach (EnemyChance i in EnemiesToSpawn)
        {
            chanceSum += i.chance;
            if(roll>=chanceSum) continue;
            //Debug.Log(i.EnemyToSpawn + " - Spawn from roll: " +roll);
            return i.EnemyToSpawn;
            break;
        }

        return default;
    }
}


[Serializable]
public struct EnemyChance
{
    public int chance;
    public Pools_Items EnemyToSpawn;
} 