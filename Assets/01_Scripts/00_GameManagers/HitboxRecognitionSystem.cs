using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HitboxRecognitionSystem
{
    private static Dictionary<Collider2D, Action<float,AnalyticCustomEvent>> _DamageDic= new Dictionary<Collider2D, Action<float,AnalyticCustomEvent>>();

    public static void AddDamagableObject(Collider2D col, Action<float, AnalyticCustomEvent> method)
    {
        _DamageDic.Add(col, method);
    }

    public static void RemoveDamagableObject(Collider2D col)
    {
        _DamageDic.Remove(col);
    }

    public static Action<float,AnalyticCustomEvent> GetDamage(Collider2D col)
    {
        if(_DamageDic.ContainsKey(col))
            return _DamageDic[col];
        else
        {
            Debug.LogError("Collider not found in dictionary: Please check the awake method of the target and verify its init", col.gameObject);
            return null;
        }
        
    }
    
    public static void ApplyDamage(Collider2D col, float damage, AnalyticCustomEvent analyticEvent)
    {
        if(_DamageDic.ContainsKey(col))
            _DamageDic[col].Invoke(damage, analyticEvent);
        else
            Debug.LogError("Collider not found in dictionary: Please check the awake method of the target and verify its init", col.gameObject);
    }
    
}
