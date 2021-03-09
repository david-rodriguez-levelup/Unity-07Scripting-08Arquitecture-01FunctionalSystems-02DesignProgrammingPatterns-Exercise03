using UnityEngine;

public class DefaultCommand : ICommand
{

    private readonly ICommandAction action;

    public DefaultCommand(ICommandAction _action)
    {
        action = _action;
    }

    public virtual void Execute()
    {
        action.Perform();
    }

    public override string ToString()
    {
        return $"{action.Id}[{action.GetType()}]";
    }

}
