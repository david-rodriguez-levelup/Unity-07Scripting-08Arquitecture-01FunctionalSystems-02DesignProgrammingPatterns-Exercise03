using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class HealthState : MonoBehaviour
{

    public event Action OnDeath;
    public event Action OnChange;

    [SerializeField] private float maxHealth;

    public float CurrentHealth => currentHealth;

    private float currentHealth;

    private void Start()
    {
        RestoreAll();
    }

    public void RestoreAll()
    {
        currentHealth = maxHealth;
        OnChange?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        Assert.IsTrue(damage > 0f);

        float previousHealth = currentHealth;

        currentHealth -= damage;

        if (currentHealth != previousHealth)
        {
            Debug.Log($"\t{name} receives {damage} points of damage (new health is {currentHealth})!!!");
            OnChange?.Invoke();
        }

        if (currentHealth <= 0f)
        {
            Debug.Log($"\t{name} is DEAD!!!");
            OnDeath?.Invoke();
        }
    }

}
