using System;
using System.Collections.Generic;
using UnityEngine;

public class StatePlayerSelection : AbstractState
{

    private readonly PlayerSlotArrayControl playerSlotArrayControl;
    private readonly List<ICommand> playerCommands;

    public StatePlayerSelection(GameStateControl gameStateControl,
                                    PlayerSlotArrayControl playerSlotArrayControl,
                                    List<ICommand> playerCommands) : base(gameStateControl)
    {
        this.playerSlotArrayControl = playerSlotArrayControl;
        this.playerCommands = playerCommands;
    }

    public override void Enter()
    {
        playerSlotArrayControl.OnSelectionDone += AddPlayerCommands;

        // Better with a callback?
        playerSlotArrayControl.MakeSelection();
        // ... and wait for event playerCommandSelection.OnSelectionDone!
    }

    public override void Exit()
    {
        playerSlotArrayControl.OnSelectionDone -= AddPlayerCommands;
    }

    private void AddPlayerCommands(ICommand[] commands)
    {

        Debug.Log("Player commands:");
        foreach (ICommand command in commands)
        {
            playerCommands.Add(command);
            Debug.Log($"\tCommand {(command != null ? command.ToString() : "EMPTY")} added to player's commands.");
        }

        gameStateControl.ChangeState(gameStateControl.StateEnemySelection);
    }

}
