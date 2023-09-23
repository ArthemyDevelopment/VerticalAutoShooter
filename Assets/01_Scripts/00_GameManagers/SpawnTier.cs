using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpawnTier", menuName = "Custom Scriptables/SpawnTier")]
public class SpawnTier : ScriptableObject
{
    [BoxGroup("Stats")] public float SpawnRate;
    [BoxGroup("Stats")] public List<Pools_Items> EnemiesToSpawn;
}
