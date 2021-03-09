using UnityEngine;

public class AbstractState : IState
{

    protected GameStateControl gameStateControl;

    public AbstractState(GameStateControl gameStateControl)
    {
        this.gameStateControl = gameStateControl;
    }

    public virtual void Enter() 
    {
        //Debug.Log($"ENTER {GetType()}");
    }

    public virtual void Update()
    {
        //Debug.Log($"UPDATE {GetType()}");
    }

    public virtual void FixedUpdate()
    {
        //Debug.Log($"FIXED UPDATE {GetType()}");
    }

    public virtual void Exit()
    {
        //Debug.Log($"EXIT {GetType()}");
    }

}
