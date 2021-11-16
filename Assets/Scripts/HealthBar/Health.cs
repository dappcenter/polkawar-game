using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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

    [SerializeField]
    private TextMeshProUGUI decreasingHP;

    private void OnEnable()
    {
        Reset();
    }

    public void Reset()
    {
        currentHealth = maxHealth;
    }

    [Button]
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
        decreasingHP.enabled = true;
        decreasingHP.text = damage.ToString();
        decreasingHP.GetComponent<Animator>().Play("DecresingHp");
        StartCoroutine(DisableDecreasingHp());
    }
    private IEnumerator DisableDecreasingHp()
    {
        yield return new WaitForSeconds(2);
        decreasingHP.enabled = false;
    }

    private void Die()
    {
        Debug.Log("Die function called");
    }
}

public interface IDamagable
{
    public void TakeDamage(int damage);
}