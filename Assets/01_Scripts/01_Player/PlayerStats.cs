
using System;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerStats", menuName = "Custom Scriptables/Player Stats")]
public class PlayerStats : ScriptableObject
{
    [BoxGroup("HealthStats")]public int PlayerBaseHealth;
    [BoxGroup("MoveStats")]public float PlayerBaseMoveSpeed;
    [BoxGroup("MoveStats")]public float MinMoveModifierThreashold;
    [BoxGroup("ShootStats")]public float PlayerBaseFireRate;
    [BoxGroup("ShootStats")]public float PlayerRepeatedShootingStateBuff;
    [BoxGroup("ShootStats")]public float MinFireRateModifierThreashold;
    [BoxGroup("ShootStats")]public Pools_Items PlayerDefaultShooter;
    [BoxGroup("ShootStats")]public Pools_Items PlayerDefaultBullet;
    [BoxGroup("CharacterInfo")] public Sprite CharSprite;
    [BoxGroup("CharacterInfo"), TextArea] public string CharStats;
}
