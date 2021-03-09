using UnityEngine;
using UnityEngine.UI;

public class LevelCounterChangeAction : MonoBehaviour
{

    private Text counter;

    private void Awake()
    {
        counter = GetComponent<Text>();
    }

    public void Perform(int value)
    {
        counter.text = value.ToString("00");
    }

}
