using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class Health : MonoBehaviour, IDamagable
{
    // Start is called before the first frame update
    [SerializeField]
    private int maxHealth = 100;
    [SerializeField, ReadOnly]
    private int currentHealth = 100;

    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;

    public event Action OnHealthPctChanged = delegate { };
    public UnityEvent OnCharacterDie;

    [SerializeField, ReadOnly]
    private bool isAlive = true;

    private void OnEnable()
    {
        Reset();
    }

    public void Reset()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (!isAlive) return;

        currentHealth = Mathf.Clamp(currentHealth, 0, currentHealth - damage);

        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged();

        if (currentHealth <= 0)
        {
            isAlive = false;
            Debug.Log("Died");
            Die();
            OnCharacterDie.Invoke();
        }
    }

    private void Die()
    {
        throw new NotImplementedException();
    }
}


public interface IDamagable
{
    public void TakeDamage(int damage);
}