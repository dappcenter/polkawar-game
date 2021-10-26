using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Image foregroundImage;

    [SerializeField]
    private float updateSpeedSeconds = 0.5f;

    [SerializeField]
    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
        health.OnHealthPctChanged += HandleHealthChanged;
    }

    private void HandleHealthChanged()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeToPct());
    }

    private IEnumerator ChangeToPct()
    {
        float preChangePct = foregroundImage.fillAmount;
        float newPct = health.CurrentHealth / health.MaxHealth;

        float elapsed = 0f;

        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            foregroundImage.fillAmount = Mathf.Lerp(preChangePct, newPct, elapsed / updateSpeedSeconds);
            yield return null;
        }

        foregroundImage.fillAmount = newPct;
    }

    public void FrontFacingHealthBar()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }

    private void Update()
    {
        FrontFacingHealthBar();
    }

}
