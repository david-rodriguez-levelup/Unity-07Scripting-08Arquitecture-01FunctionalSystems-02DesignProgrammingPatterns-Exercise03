using UnityEngine;

// PENDIENTE el tema del 50% de daño!!!!!
// OPCIONES:
// 1) public bool IsDefending y hacer el set desde TurnManager (no mola nada).
// 2) IObserver<AttackAction> (y el damage es una property de solo lectura), 
//    IObserver<DefenseAction>
//    IObserver<HealingAction>
//    En el OnNotify(AttackAction action) habrá que comprobar si el parameter "action" es la del personaje o la del enemigo para poner isDefending a false o no.
//    En el OnNotify(DefenseAction action) pondremos isDefending a true.
//    En el OnNotify(HealingAction action) pondremos isDefending a false.
//    Problema con esta solución: si no se usan interfaces el resto de métodos quedan expuestos.

public class ActionControl /* = DamageControl de la solución de David */ : MonoBehaviour, IObserver<AttackArgs>
{
    [SerializeField] private float health; // Aquí de forma temporal, irá a un HealtControl o HealthState.

    [SerializeField] private GameObject attacker;

    private ISubject<AttackArgs> attackAgainstMeAction;
    //private ISubject<AttackArgs> attackAction;
    //private ISubject defenseAction;
    //private ISubject healingAction;

    private void Awake()
    {
        attackAgainstMeAction = attacker.GetComponent<ISubject<AttackArgs>>();
        //attackAction = GetComponent<ISubject<AttackArgs>>(); // Es necesario para poner isDefending a false! - PROBLEMA: Como distinguimos en el OnNotify(AttackArgs parameter) si es el atacante o somos nosotros.
        //defenseAction = GetComponent<DefenseAction>(); // Para poner isDefending a true! - PROBLEMA: Si no hay args como sabemos en el OnNotify si es el DefenseAction o el HealingAction. ¿Pasar un ID? Uf!
        //healingAction = GetComponent<HealingAction>(); // Para poner isDefending a false!
    }

    private void OnEnable()
    {
        attackAgainstMeAction.AddObserver(this);
        //attackAction.AddObserver(this);
        //defenseAction.AddObserver(this); // Necesitamos DefenseArgs y HealingArgs porque sinó irán a parar al mismo OnNotify!
        //healingAction.AddObserver(this);
    }

    private void OnDisable()
    {
        attackAgainstMeAction.RemoveObserver(this);
        //attackAction.RemoveObserver(this);
        //defenseAction.RemoveObserver(this);
        //healingAction.RemoveObserver(this);
    }

    public void OnNotify(AttackArgs parameter)
    {
        health -= parameter.Damage;
        Debug.Log($"\t{name} receives {parameter.Damage} points of damage (new health is {health})!!!");
    }

}
