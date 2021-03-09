using System;
using UnityEngine;

public abstract class AbstractSlotArrayControl : MonoBehaviour
{

    public event Action<ICommand[]> OnSelectionDone;

    [SerializeField] private CommandConfigList commandConfigList;
    [SerializeField] private GameObject commandReceiver;

    protected SlotState[] SlotStates { get; private set; }

    private void Awake()
    {
        SlotStates = GetComponentsInChildren<SlotState>();
        foreach (SlotState slotState in SlotStates)
        {
            slotState.SetAvailableCommands(commandConfigList);
        }

        OnAwake();
    }

    protected virtual void OnAwake()
    {
        // Overrided in subclasses if needed.
    }

    public void InitSlots()
    {
        foreach (SlotState slotState in SlotStates)
        {
            slotState.Init();
        }
    }

    public abstract void MakeSelection();

    protected void SubmitSlots()
    {
        ICommand[] commands = CommandFactory.CreateCommands(SlotStates, commandReceiver);
        OnSelectionDone?.Invoke(commands);
    }

}
