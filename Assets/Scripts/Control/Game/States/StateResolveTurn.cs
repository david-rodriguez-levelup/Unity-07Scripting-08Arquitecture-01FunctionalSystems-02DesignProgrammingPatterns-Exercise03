using System.Collections.Generic;
using UnityEngine;

public class StateResolveTurn : AbstractState
{

    private readonly HealthState playerHealth;
    private readonly HealthState enemyHealth;
    private readonly List<ICommand> playerCommands;
    private readonly List<ICommand> enemyCommands;

    private bool someoneHasDead = false;

    public StateResolveTurn(GameStateControl gameStateControl,
                                    HealthState playerHealth,
                                    HealthState enemyHealth,
                                    List<ICommand> playerCommands,
                                    List<ICommand> enemyCommands) : base(gameStateControl)
    {

        this.playerHealth = playerHealth;
        this.enemyHealth = enemyHealth;
        this.playerCommands = playerCommands;
        this.enemyCommands = enemyCommands;
    }

    public override void Enter()
    {
        someoneHasDead = false;

        playerHealth.OnDeath += OnPlayerDeath;
        enemyHealth.OnDeath += OnEnemyDeath;

        Debug.Log("2) RESOLVE:");
        for (int i = 0; i < playerCommands.Count; i++)
        {
            Debug.Log($"Slot {i}:");

            ExecuteCommand(enemyCommands[i], "Enemy");

            // Esto está ok? <----------------------------------------------
            if (someoneHasDead)
            {
                return;
            }

            ExecuteCommand(playerCommands[i], "Player");

            // Esto está ok? <----------------------------------------------
            if (someoneHasDead)
            {
                return;
            }

        }

        Debug.Log("______________________________________________________________\n\n");

        // If we are here, neither player or enemy are dead!
        gameStateControl.ChangeState(gameStateControl.StateNewTurn);

    }

    private void ExecuteCommand(ICommand command, string who)
    {
        if (command != null)
        {
            command.Execute();
        }
        else
        {
            Debug.Log($"\t{who} does NOTHING!");
        }
    }

    public override void Exit()
    {
        playerHealth.OnDeath -= OnPlayerDeath;
        enemyHealth.OnDeath -= OnEnemyDeath;
    }

    private void OnPlayerDeath()
    {
Debug.Log("EL PLAYER HA MUERTO!!!");
        someoneHasDead = true;
        gameStateControl.ChangeState(gameStateControl.StateGameOver);
    }

    private void OnEnemyDeath()
    {
Debug.Log("EL ENEMY HA MUERTO!!!");
        someoneHasDead = true;
        gameStateControl.ChangeState(gameStateControl.StateNewLevel);
    }

}
