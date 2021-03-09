using System;
using UnityEngine;

public class OnKeyDownInputSensor : MonoBehaviour, IInputSensor
{

    public event Action OnPressed;

    [SerializeField] KeyCode keyCode = KeyCode.Alpha1;

    private void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            OnPressed?.Invoke();
        }
    }

}
