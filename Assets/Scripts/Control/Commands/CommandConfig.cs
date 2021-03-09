using System;
using UnityEngine;

[Serializable]
public class CommandConfig
{

    [SerializeField] private string id;
    [SerializeField] private Sprite icon;
    [SerializeField] private float actionPoints;

    public string Id => id;

    public Sprite Icon => icon;

    public float ActionPoints => actionPoints;

}
