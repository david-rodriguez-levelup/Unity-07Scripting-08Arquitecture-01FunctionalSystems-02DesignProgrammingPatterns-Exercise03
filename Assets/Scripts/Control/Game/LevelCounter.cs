using UnityEngine;

public class LevelCounter : MonoBehaviour
{

    [SerializeField] LevelCounterChangeAction levelCounterChangeAction;

    private int level = 0;

    public void IncreaseLevel()
    {
        level++;
        levelCounterChangeAction.Perform(level);
    }

}
