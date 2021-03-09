using UnityEngine;

public class StateNewLevel : AbstractState
{

    private readonly LevelCounter levelCounter;

    public StateNewLevel(GameStateControl gameStateControl,
                            LevelCounter levelCounter) : base(gameStateControl)
    {
        this.levelCounter = levelCounter;
    }

    protected override void Enter()
    {
        Debug.Log("NEW LEVEL!!!");

        levelCounter.IncreaseLevel();

        gameStateControl.ChangeState(gameStateControl.StateNewTurn);
    }

}