using System;
using UnityEngine;
using UnityEngine.UI;

public class OnClickInputSensor : MonoBehaviour, IInputSensor
{

	public event Action OnPressed;

	void Start()
	{
		Button button = GetComponent<Button>();
		button.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		OnPressed?.Invoke();
	}

}
