using UnityEngine;

public class StateGameOver : AbstractState
{

    public StateGameOver(GameStateControl gameStateControl) : base(gameStateControl) { }

    public override void Enter()
    {
        Debug.Log("GAME OVER!!!");

        gameStateControl.ChangeState(gameStateControl.StateNewGame);
    }

}
