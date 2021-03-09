using UnityEngine;
using UnityEngine.UI;

public class SlotIconChangeAction : MonoBehaviour
{

    private Image icon;

    private void Awake()
    {
        icon = GetComponent<Image>();
    }

    public void Perform(Sprite sprite)
    {
        icon.sprite = sprite;
    }

}
