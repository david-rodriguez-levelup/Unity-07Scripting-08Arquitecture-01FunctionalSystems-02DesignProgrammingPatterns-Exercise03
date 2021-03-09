using System.Collections.Generic;
using UnityEngine;

public class StateNewTurn : AbstractState
{

    private readonly PlayerSlotArrayControl playerSlotArrayControl;
    private readonly List<ICommand> playerCommands;
    private readonly EnemySlotArrayControl enemySlotArrayControl;
    private readonly List<ICommand> enemyCommands;

    public StateNewTurn(GameStateControl gameStateControl,
                            PlayerSlotArrayControl playerSlotArrayControl,
                            List<ICommand> playerCommands,
                            EnemySlotArrayControl enemySlotArrayControl,
                            List<ICommand> enemyCommands) : base(gameStateControl)
    {
        this.playerSlotArrayControl = playerSlotArrayControl;
        this.playerCommands = playerCommands;
        this.enemySlotArrayControl = enemySlotArrayControl;
        this.enemyCommands = enemyCommands;
    }

    public override void Enter()
    {
        Debug.Log("NEW TURN:");
        Debug.Log("1) SELECTION:");

        playerCommands.Clear();
        playerSlotArrayControl.InitSlots();
        enemyCommands.Clear();
        enemySlotArrayControl.InitSlots();

        gameStateControl.ChangeState(gameStateControl.StatePlayerSelection);
    }

}
