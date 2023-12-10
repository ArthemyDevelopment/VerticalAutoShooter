
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


//[DefaultExecutionOrder(-1)]
public class PlayerManager : SingletonManager<PlayerManager>
{

    [FormerlySerializedAs("ResetGameEvent")] public EventObserver EventObserver;

    public PlayerMovementController movementController;
    public PlayerShootingController shootingController;
    public PlayerHealthManager healthManager;
    public PlayerStats Stats;
    public SpriteRenderer PlayerSprite;
    [ShowInInspector]public List<IPlayerController> playerControllers= new List<IPlayerController>();

    private void OnEnable()
    {
        playerControllers.Add(movementController);
        playerControllers.Add(shootingController);
        playerControllers.Add(healthManager);
        EventObserver.OnResetGame += TriggerDeath;
        EventObserver.OnStartGame += InitPlayerStats;
        //InitPlayerStats();
    }

    public void SetPlayer(PlayerStats player)
    {
        Stats = player;
        PlayerSprite.sprite = Stats.CharSprite;
    }

    void InitPlayerStats()
    {
        foreach (IPlayerController controller in playerControllers)
        {
            controller.InitPlayerStats(Stats);
        }
    }

    public void ChangeSpeed(float speedModifier)
    {
        movementController.ApplyModifier(speedModifier);
    }

    public void ChangeFireRate(float fireRateModifier)
    {
        shootingController.ApplyModifier(fireRateModifier);
    }

    public void ChangeShootingState(PlayerShootingStates state)
    {
        shootingController.ChangeShootingState(state);
    }

    public void TriggerDeath()
    {
        movementController.SetPlayerDeath();
        shootingController.StopShooting();

    }


}


