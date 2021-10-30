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

    private LTDescr fillAmountTween = null;

    private void Awake()
    {
        health = GetComponent<Health>();
        health.OnHealthPctChanged += HandleHealthChanged;
    }

    private void HandleHealthChanged()
    {
        StopAllCoroutines();

        if(fillAmountTween != null)
        {
            LeanTween.cancel(fillAmountTween.uniqueId);
        }

        fillAmountTween = LeanTween.value(foregroundImage.fillAmount, health.CurrentHealth / health.MaxHealth, 0.25f).setOnUpdate((float val) =>
        {
            foregroundImage.fillAmount = val;
        }).setOnComplete(()=> { fillAmountTween = null; });

        //StartCoroutine(ChangeToPct());
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
}
