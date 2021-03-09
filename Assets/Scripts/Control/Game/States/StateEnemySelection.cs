using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateEnemySelection : AbstractState
{

    private readonly EnemySlotArrayControl enemySlotArrayControl;
    private readonly List<ICommand> enemyCommands;

    public StateEnemySelection(GameStateControl gameStateControl,
                                    EnemySlotArrayControl enemySlotArrayControl,
                                    List<ICommand> enemyCommands) : base(gameStateControl)
    {
        this.enemySlotArrayControl = enemySlotArrayControl;
        this.enemyCommands = enemyCommands;
    }

    public override void Enter()
    {
        enemySlotArrayControl.OnSelectionDone += AddEnemyCommands;

        // Better with a callback?
        enemySlotArrayControl.MakeSelection();
        // ... and wait for event enemyCommandSelection.OnSelectionDone!
    }

    public override void Exit()
    {
        enemySlotArrayControl.OnSelectionDone -= AddEnemyCommands;
    }

    private void AddEnemyCommands(ICommand[] commands)
    {
        Debug.Log("Enemy commands:");
        foreach (ICommand command in commands)
        {
            enemyCommands.Add(command);
            Debug.Log($"\tCommand {(command != null ? command.ToString() : "EMPTY")} added to enemy's commands.");
        }

        gameStateControl.ChangeState(gameStateControl.StateResolveTurn);
    }

}
