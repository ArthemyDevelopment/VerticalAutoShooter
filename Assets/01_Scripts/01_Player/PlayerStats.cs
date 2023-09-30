
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerStats", menuName = "Custom Scriptables/Player Stats")]
public class PlayerStats : ScriptableObject
{
    public int PlayerBaseHealth;
    public float PlayerBaseMoveSpeed;
    public float MinMoveModifierThreashold;
    public float PlayerBaseFireRate;
    public float PlayerRepeatedShootingStateBuff;
    public float MinFireRateModifierThreashold;
    public Pools_Items PlayerDefaultShooter;
    public Pools_Items PlayerDefaultBullet;
}
