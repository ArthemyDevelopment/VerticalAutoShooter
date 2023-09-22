
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{

    public PlayerMovementController movementController;
    public PlayerShootingController shootingController;
    public PlayerStats Stats;
    public List<PlayerController> playerControllers;

    private void OnEnable()
    {
        InitPlayerStats();
    }


    void InitPlayerStats()
    {
        foreach (PlayerController controller in playerControllers)
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


