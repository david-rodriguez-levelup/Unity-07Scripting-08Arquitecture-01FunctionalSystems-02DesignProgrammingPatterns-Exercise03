using System.Collections.Generic;
using UnityEngine;

public class DefenseAction : MonoBehaviour, ICommandAction
{

    private const string ID = "DEFENSE";

    public string Id => ID;

    public void Perform()
    {
        Debug.Log($"\t{name} performs ACTION {ID}!");
    }

}
