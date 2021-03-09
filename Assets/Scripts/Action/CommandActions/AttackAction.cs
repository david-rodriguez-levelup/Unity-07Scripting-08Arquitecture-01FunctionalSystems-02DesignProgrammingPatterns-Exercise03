using System.Collections.Generic;
using UnityEngine;

public class AttackAction : MonoBehaviour, ICommandAction, ISubject<AttackArgs>
{
    private const string ID = "ATTACK";
    public string Id => ID;

    [SerializeField] private int damage;

    private List<IObserver<AttackArgs>> observers = new List<IObserver<AttackArgs>>();

    public void AddObserver(IObserver<AttackArgs> observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver<AttackArgs> observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (IObserver<AttackArgs> observer in observers)
        {
            observer.OnNotify(new AttackArgs(damage));
        }
    }

    public void Perform()
    {
        Debug.Log($"\t{name} performs ACTION {ID}!");
        Notify();
    }

}
