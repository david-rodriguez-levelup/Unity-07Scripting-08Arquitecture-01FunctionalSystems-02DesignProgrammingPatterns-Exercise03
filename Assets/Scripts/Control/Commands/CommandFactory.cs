using System;
using UnityEngine;

public static class CommandFactory
{

    public static ICommand[] CreateCommands(SlotState[] slotStates, GameObject commandReceiver)
    {
        ICommand[] commands = new ICommand[slotStates.Length];

        for (int i = 0; i < slotStates.Length; i++)
        {
            SlotState slotState = slotStates[i];
            slotState.Locked = true;
            if (slotState.Current != null)
            {
                commands[i] = CreateCommand(commandReceiver, slotState.Current.Id);
            }
            else
            {
                // Could player left an empty slot?
                commands[i] = null;
            }
        }

        return commands;
    }

    private static ICommand CreateCommand(GameObject commandReceiver, string id)
    {
        ICommandAction[] actions = commandReceiver.GetComponents<ICommandAction>();

        ICommand command = null;

        foreach (ICommandAction action in actions)
        {
            if (action.Id.Equals(id, StringComparison.OrdinalIgnoreCase))
            {
                command = new DefaultCommand(action);
            }
        }

        if (command != null)
        {
            return command;
        }
        else
        {
            throw new UnityException($"Action {id} doesn't exists in {commandReceiver.name}. Unable to create command.");
        }
    }

}
