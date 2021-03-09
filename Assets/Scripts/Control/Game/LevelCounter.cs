using UnityEngine;

public class LevelCounter : MonoBehaviour
{

    [SerializeField] LevelCounterChangeAction levelCounterChangeAction;

    private int level = 0;

    public void Reset()
    {
        level = 0;
        levelCounterChangeAction.Perform(level);
    }

    public void IncreaseLevel()
    {
        level++;
        levelCounterChangeAction.Perform(level);
    }

}
