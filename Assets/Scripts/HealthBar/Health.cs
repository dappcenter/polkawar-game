using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int maxHealth = 100;
    private int currentHealth;


    public event Action<float> OnHealthPctChanged = delegate { };
    //public event Action<int> OnCharaterDie = delegate { };
    public UnityEvent OnCharaterDie;

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
        if (currentHealth < 1)
        {
            Debug.Log("Die");
            OnCharaterDie.Invoke();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ModifyHealth(-10);
        }
    }
}
