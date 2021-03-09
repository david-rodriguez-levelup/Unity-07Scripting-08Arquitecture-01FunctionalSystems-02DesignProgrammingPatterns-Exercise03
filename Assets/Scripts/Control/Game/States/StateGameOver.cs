using UnityEngine;

public class StateGameOver : AbstractState
{

    public StateGameOver(GameStateControl gameStateControl) : base(gameStateControl) { }

    protected override void Enter()
    {
        Debug.Log("GAME OVER!!!");
    }

}
