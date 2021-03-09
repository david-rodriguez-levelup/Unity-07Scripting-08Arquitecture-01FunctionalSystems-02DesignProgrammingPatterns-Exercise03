using System.Collections.Generic;
using UnityEngine;

public class HealingAction : MonoBehaviour, ICommandAction
{
    private const string ID = "HEALING";

    public string Id => ID;

    public void Perform()
    {
        Debug.Log($"\t{name} performs ACTION {ID}!");
    }

}
