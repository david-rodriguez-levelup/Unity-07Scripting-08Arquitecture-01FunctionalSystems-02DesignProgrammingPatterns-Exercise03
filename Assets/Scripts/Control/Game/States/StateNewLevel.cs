using UnityEngine;

public class StateNewLevel : AbstractState
{

    private readonly HealthState playerHealth;
    private readonly HealthState enemyHealth;
    private readonly LevelCounter levelCounter;

    public StateNewLevel(GameStateControl gameStateControl,
                         HealthState playerHealth,
                         HealthState enemyHealth,
                         LevelCounter levelCounter) : base(gameStateControl)
    {
        this.playerHealth = playerHealth;
        this.enemyHealth = enemyHealth;
        this.levelCounter = levelCounter;
    }

    public override void Enter()
    {
        Debug.Log("NEW LEVEL!!!");

        playerHealth.RestoreAll();
        enemyHealth.RestoreAll();

        levelCounter.IncreaseLevel();

        gameStateControl.ChangeState(gameStateControl.StateNewTurn);
    }

}