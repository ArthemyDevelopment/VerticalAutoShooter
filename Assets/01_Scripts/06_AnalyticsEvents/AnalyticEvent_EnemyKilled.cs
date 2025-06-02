
using UnityEngine;


public class AnalyticCustomEvent : Unity.Services.Analytics.Event
{
    public AnalyticCustomEvent(string name) : base(name) { }
    public string entityName { set { _entityName = value; SetParameter("entityName", value); } get => _entityName; }
    private string _entityName;
}

public class AnalyticEvent_EnemyKilled : AnalyticCustomEvent
{
    public AnalyticEvent_EnemyKilled() : base("AnalyticEvent_EnemyKilled") { }

    public string BulletName {set => SetParameter("BulletName", value); }
    public string PowerUpName {set => SetParameter("PowerUpName", value);}
}


public class AnalyticEvent_PlayerDamaged : AnalyticCustomEvent
{
    public AnalyticEvent_PlayerDamaged() : base("AnalyticEvent_PlayerDamaged") { }

    public float EnemyRemainingHealth {set { _EnemyRemainingHealth= value; SetParameter("EnemyRemainingHealth", value); } get => _EnemyRemainingHealth;}
    private float _EnemyRemainingHealth;
    public string PowerUpName {set { _powerUpName= value; SetParameter("PowerUpName", value); } get => _powerUpName;}
    private string _powerUpName;
    public float ShootingFireRate {set { _ShootingFireRate= value; SetParameter("ShootingFireRate", value); } get => _ShootingFireRate;}
    private float _ShootingFireRate;
}

public class AnalyticEvent_PlayerKilled : AnalyticCustomEvent
{
    public AnalyticEvent_PlayerKilled() : base("AnalyticEvent_PlayerKilled") { }

    public float EnemyRemainingHealth {set { _EnemyRemainingHealth= value; SetParameter("EnemyRemainingHealth", value); } get => _EnemyRemainingHealth;}
    private float _EnemyRemainingHealth;
    public string PowerUpName {set { _powerUpName= value; SetParameter("PowerUpName", value); } get => _powerUpName;}
    private string _powerUpName;
    public float ShootingFireRate {set { _ShootingFireRate= value; SetParameter("ShootingFireRate", value); } get => _ShootingFireRate;}
    private float _ShootingFireRate;
}

public class AnalyticEvent_ScoreWhenDied : AnalyticCustomEvent
{
    public AnalyticEvent_ScoreWhenDied() : base("AnalyticEvent_ScoreWhenDied") { }
    
    public int Score {set => SetParameter("Score", value); }
}

public class AnalyticEvent_HighScore : AnalyticCustomEvent
{
    public AnalyticEvent_HighScore() : base("AnalyticEvent_HighScore") { }
    
    public int Score {set => SetParameter("Score", value); }
}

public class AnalyticEvent_WeaponsStats_PowerUpPicked : AnalyticCustomEvent
{
    public AnalyticEvent_WeaponsStats_PowerUpPicked() : base("AnalyticEvent_WeaponsStats_PowerUpPicked") { }
    
}

public class AnalyticEvent_WeaponsStats_PowerUpTimeUsed : AnalyticCustomEvent
{
    public AnalyticEvent_WeaponsStats_PowerUpTimeUsed() : base("AnalyticEvent_WeaponsStats_PowerUpTimeUsed") { }
    
    public float UsageTime {set => SetParameter("UsageTime", value); }
    public float ShootingFireRate {set => SetParameter("ShootingFireRate", value); }
}


