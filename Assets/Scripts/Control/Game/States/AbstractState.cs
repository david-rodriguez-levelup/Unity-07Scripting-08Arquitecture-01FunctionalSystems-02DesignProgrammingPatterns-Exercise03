using UnityEngine;

public class AbstractState : IState
{

    protected GameStateControl gameStateControl;

    public AbstractState(GameStateControl gameStateControl)
    {
        this.gameStateControl = gameStateControl;
    }

    protected virtual void Enter() 
    {
        //Debug.Log($"ENTER {GetType()}");
    }

    protected virtual void Update()
    {
        //Debug.Log($"UPDATE {GetType()}");
    }

    protected virtual void FixedUpdate()
    {
        //Debug.Log($"FIXED UPDATE {GetType()}");
    }

    protected virtual void Exit()
    {
        //Debug.Log($"EXIT {GetType()}");
    }

}
