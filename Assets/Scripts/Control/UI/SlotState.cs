using System;
using UnityEngine;

public class SlotState : MonoBehaviour
{
    private const int EMPTY = -1;

    public event Action OnChanged;

    [SerializeField] Sprite emptyIcon;

    public bool Locked { get; set; } = false;

    private SlotIconChangeAction slotIconChangeAction;

    private CommandConfigList availableCommands;
    private int currentIndex = EMPTY;

    private void Awake()
    {
        slotIconChangeAction = GetComponentInChildren<SlotIconChangeAction>();
    }

    public void SetAvailableCommands(CommandConfigList commandConfigList)
    {
        availableCommands = commandConfigList;
    }

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        Locked = false;
        currentIndex = EMPTY;
        ChangeIcon();
    }

    public CommandConfig Current => currentIndex != EMPTY ? availableCommands.Get(currentIndex) : null;

    public void Next(bool allowEmptyAction)
    {
        currentIndex++;
        if (currentIndex == availableCommands.Length)
        {
            if (allowEmptyAction)
            {
                currentIndex = EMPTY;
            }
            else
            {
                currentIndex = 0;
            }
        } 
        ChangeIcon();
    }

    public void Random(bool allowEmptyAction)
    {
        int minRange = allowEmptyAction ? EMPTY : 0;
        currentIndex = UnityEngine.Random.Range(minRange, availableCommands.Length);
        ChangeIcon();
    }

    private void ChangeIcon()
    {
        if (currentIndex == EMPTY)
        {
            slotIconChangeAction.Perform(emptyIcon);
        }
        else
        {
            slotIconChangeAction.Perform(Current.Icon);
        }
        OnChanged?.Invoke();
    }

}
