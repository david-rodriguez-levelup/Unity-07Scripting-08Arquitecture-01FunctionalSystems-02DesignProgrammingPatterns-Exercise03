using UnityEngine;
using UnityEngine.UI;

public class BarChangeAction : MonoBehaviour
{

    [SerializeField] private float maxValue;

    public float MaxValue => maxValue;

    private Slider slider;
    private Text label;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        label = GetComponentInChildren<Text>();
    }

    public void Init()
    {
        Perform(0f);
    }

    public void Perform(float value)
    {
        slider.value = value;
        label.text = $"{value}/{maxValue}";
    }

}
