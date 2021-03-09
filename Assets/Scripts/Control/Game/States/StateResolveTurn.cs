using System.Collections.Generic;
using UnityEngine;

public class StateResolveTurn : AbstractState
{

    private readonly List<ICommand> playerCommands;
    private readonly List<ICommand> enemyCommands;

    public StateResolveTurn(GameStateControl gameStateControl,
                                    List<ICommand> playerCommands,
                                    List<ICommand> enemyCommands) : base(gameStateControl)
    {
        this.playerCommands = playerCommands;
        this.enemyCommands = enemyCommands;
    }

    protected override void Enter()
    {
        Debug.Log("2) RESOLVE:");
        for (int i = 0; i < playerCommands.Count; i++)
        {
            Debug.Log($"Slot {i}:");

            ICommand enemyCommand = enemyCommands[i];
            if (enemyCommand != null)
            {
                enemyCommands[i].Execute();
            }
            else
            {
                Debug.Log("\tEnemy does NOTHING!");
            }

            ICommand playerCommand = playerCommands[i];
            if (playerCommand != null)
            {
                playerCommands[i].Execute();
            }
            else
            {
                Debug.Log("\tPlayer does NOTHING!");
            }
        }

        Debug.Log("______________________________________________________________\n\n");

        gameStateControl.ChangeState(gameStateControl.StateNewTurn);

    }

}
