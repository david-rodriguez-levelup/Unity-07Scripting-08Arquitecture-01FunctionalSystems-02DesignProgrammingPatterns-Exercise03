using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOkButtonControl : MonoBehaviour
{
    public event Action OnPressed;

    private Image image;
    private IInputSensor[] inputSensors;

    private void Awake()
    {
        image = GetComponent<Image>();
        inputSensors = GetComponents<IInputSensor>();
    }

    private void OnEnable()
    {
        image.color = Color.white;

        foreach (IInputSensor inputSensor in inputSensors)
        {
            inputSensor.OnPressed += InvokeOnPressed;
        }
    }

    private void OnDisable()
    {
        image.color = Color.grey;

        foreach (IInputSensor inputSensor in inputSensors)
        {
            inputSensor.OnPressed -= InvokeOnPressed;
        }
    }

    private void InvokeOnPressed()
    {
        if (enabled)
        {
            OnPressed?.Invoke();
        }
    }

}
