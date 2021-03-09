using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateNewGame : AbstractState
{

    private readonly LevelCounter levelCounter;

    public StateNewGame(GameStateControl gameStateControl,
                            LevelCounter levelCounter) : base(gameStateControl)
    {
        this.levelCounter = levelCounter;
    }

    public override void Enter()
    {
        Debug.Log("NEW GAME!!!!!");

        levelCounter.Reset();

        gameStateControl.ChangeState(gameStateControl.StateNewLevel);
    }

}
