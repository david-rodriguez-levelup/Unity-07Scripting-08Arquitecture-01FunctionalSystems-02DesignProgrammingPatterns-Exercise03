using UnityEngine;

public class PlayerSlotControl : MonoBehaviour
{

    private SlotState slotState;
    private IInputSensor[] inputSensors;

    private void Awake()
    {
        slotState = GetComponent<SlotState>();
        inputSensors = GetComponents<IInputSensor>();
    }

    private void OnEnable()
    {
        foreach (IInputSensor inputSensor in inputSensors)
        {
            inputSensor.OnPressed += SelectNext;
        }
    }

    private void OnDisable()
    {
        foreach (IInputSensor inputSensor in inputSensors)
        {
            inputSensor.OnPressed -= SelectNext;
        }
    }

    private void SelectNext()
    {
        if (!slotState.Locked)
        {
            slotState.Next(allowEmptyAction: true);
        }
    }   

}
