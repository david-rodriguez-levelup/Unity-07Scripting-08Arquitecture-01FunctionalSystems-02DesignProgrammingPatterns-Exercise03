using UnityEngine;

[CreateAssetMenu(fileName = "CommandConfigList", menuName = "Assets/CommandConfigList")]
public class CommandConfigList : ScriptableObject
{

    [SerializeField] private CommandConfig[] commandConfigs;

    public int Length => commandConfigs.Length;

    public CommandConfig Get(int index)
    {
        return commandConfigs[index];
    }

}
