using UnityEngine;

public class PlayerSlotArrayControl : AbstractSlotArrayControl
{
   
    private PlayerOkButtonControl okButtonSensor;
    private BarChangeAction barChangeAction;

    private bool locked = true; // Starts locked by default!

    protected override void OnAwake()
    {
        okButtonSensor = GetComponentInChildren<PlayerOkButtonControl>();
        barChangeAction = GetComponentInChildren<BarChangeAction>();
    }

    private void OnEnable()
    {
        foreach (SlotState slotState in base.SlotStates)
        {
            slotState.OnChanged += ChangeActionBar;
        }
        
        okButtonSensor.OnPressed += OnOkButtonPressed;
    }

    private void OnDisable()
    {
        foreach (SlotState slotState in base.SlotStates)
        {
            slotState.OnChanged -= ChangeActionBar;
        }

        okButtonSensor.OnPressed -= OnOkButtonPressed;
    }

    public override void MakeSelection()
    {
        locked = false;
        barChangeAction.Init();
        SetSlotsLockedValue(false);
        // Wait for user selection and okButtonSensor.OnPressed!
    }

    private void OnOkButtonPressed()
    {
        if (!locked)
        {
            locked = true;
            SetSlotsLockedValue(true);
            base.SubmitSlots();
        }
    }

    private void SetSlotsLockedValue(bool value)
    {
        foreach (SlotState slotState in base.SlotStates)
        {
            slotState.Locked = value;
        }
    }

    private void ChangeActionBar()
    {
        float spentActionPoints = 0f;

        foreach (SlotState slotState in base.SlotStates)
        {
            if (slotState.Current != null)
            {
                spentActionPoints += slotState.Current.ActionPoints;
            }
        }
        barChangeAction.Perform(spentActionPoints);

        if (spentActionPoints > barChangeAction.MaxValue)
        {
            okButtonSensor.enabled = false;
        }
        else
        {
            okButtonSensor.enabled = true;
        }
    }

}
