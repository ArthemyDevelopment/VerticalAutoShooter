
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;


//[DefaultExecutionOrder(-1)]
public class PlayerManager : SingletonManager<PlayerManager>
{

    public PlayerMovementController movementController;
    public PlayerShootingController shootingController;
    public PlayerHealthManager healthManager;
    public PlayerStats Stats;
    [ShowInInspector]public List<IPlayerController> playerControllers= new List<IPlayerController>();

    private void OnEnable()
    {
        playerControllers.Add(movementController);
        playerControllers.Add(shootingController);
        playerControllers.Add(healthManager);
        InitPlayerStats();
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
}


