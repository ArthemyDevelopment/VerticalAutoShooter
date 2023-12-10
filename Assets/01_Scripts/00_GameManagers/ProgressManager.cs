
using System;
using System.Collections.Generic;
using UnityEngine;

//[DefaultExecutionOrder(-1)]
public class ProgressManager : SingletonManager<ProgressManager>
{
    [SerializeField]private Dictionary<int, SpawnTier> ProgressSpawn = new Dictionary<int, SpawnTier>();

    private List<int> DicKeys;
    public EventObserver EventObserver;

    private void OnEnable()
    {
        DicKeys = new List<int>(ProgressSpawn.Keys);
        EventObserver.OnStartGame += ResetProgress;
    }

    public void CheckProgress(int score)
    {
        int LevelToCheck = GetKeyToCheck(score);
        
        if (ProgressSpawn.ContainsKey(LevelToCheck))
            EnemiesSpawnManager.current.ActSpawnTier = ProgressSpawn[LevelToCheck];
    }

    public int GetKeyToCheck(int score)
    {
        for (int i = 0; i < DicKeys.Count; i++)
        {
            if (i == DicKeys.Count - 1) return DicKeys[i];

            if (score >= DicKeys[i] && score < DicKeys[i + 1]) return DicKeys[i];
            
        }

        return score;
    }

    void ResetProgress()
    {
        CheckProgress(0);
    }
    
}