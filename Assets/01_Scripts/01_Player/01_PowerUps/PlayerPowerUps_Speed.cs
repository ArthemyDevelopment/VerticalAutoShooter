

public class PlayerPowerUps_Speed : PlayerPowerUps_Base
{
    public float SpeedModifier;
    protected override void ApplyPowerUp(PlayerManager PM)
    {
        base.ApplyPowerUp(PM);
        PM.ChangeSpeed(SpeedModifier);
    }
}
