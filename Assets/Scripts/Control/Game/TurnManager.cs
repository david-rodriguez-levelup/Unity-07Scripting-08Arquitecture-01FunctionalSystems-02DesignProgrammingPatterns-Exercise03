using UnityEngine;

public class TurnManager : MonoBehaviour
{

    [SerializeField] PlayerSlotArrayControl playerCommandSelection;
    [SerializeField] EnemySlotArrayControl enemyCommandSelection;

    private LevelCounter levelCounter;

    private ICommand[] playerCommands;
    private ICommand[] enemyCommands;

    private void Start()
    {
        NewTurn();
    }

    private void Awake()
    {
        levelCounter = GetComponent<LevelCounter>();
    }

    private void OnEnable()
    {
        playerCommandSelection.OnSelectionDone += AddPlayerCommands;
        enemyCommandSelection.OnSelectionDone += AddEnemyCommands;
    }

    private void OnDisable()
    {
        playerCommandSelection.OnSelectionDone -= AddPlayerCommands;
        enemyCommandSelection.OnSelectionDone -= AddEnemyCommands;
    }

    private void NewTurn()
    {
        Debug.Log("NEW TURN:");
        Debug.Log("1) SELECTION:");

        playerCommands = null;
        playerCommandSelection.InitSlots();
        enemyCommands = null;
        enemyCommandSelection.InitSlots();
        levelCounter.IncreaseLevel();

        // Better with a callback?
        playerCommandSelection.MakeSelection();
        // ... and wait for event playerCommandSelection.OnSelectionDone!
    }


    private void AddPlayerCommands(ICommand[] commands)
    {
        playerCommands = commands;

        Debug.Log("Player commands:");
        foreach (ICommand command in playerCommands)
        {
            Debug.Log($"\tCommand {(command != null ? command.ToString() : "EMPTY")} added to player's commands.");
        }

        // Better with a callback?
        enemyCommandSelection.MakeSelection();
        // ... and wait for event enemyCommandSelection.OnSelectionDone!
    }

    private void AddEnemyCommands(ICommand[] commands)
    {
        enemyCommands = commands;

        Debug.Log("Enemy commands:");
        foreach (ICommand command in enemyCommands)
        {
            Debug.Log($"\tCommand {(command != null ? command.ToString() : "EMPTY")} added to enemy's commands.");
        }

        // Now we can resolve the turn!
        ResolveTurn();
    }

    private void ResolveTurn()
    {
        Debug.Log("2) RESOLVE:");
        for (int i = 0; i < playerCommands.Length; i++)
        {
            Debug.Log($"Slot {i}:");

            ICommand playerCommand = playerCommands[i];
            if (playerCommand != null)
            {
                playerCommands[i].Execute();
            }
            else
            {
                Debug.Log("\tPlayer does NOTHING!");
            }

            ICommand enemyCommand = enemyCommands[i];
            if (enemyCommand != null)
            {
                enemyCommands[i].Execute();
            }
            else
            {
                Debug.Log("\tEnemy does NOTHING!");
            }
        }

        Debug.Log("______________________________________________________________\n\n");

        // Invoke new turn after X seconds...
        Invoke(nameof(NewTurn), 5f);
    }

}
