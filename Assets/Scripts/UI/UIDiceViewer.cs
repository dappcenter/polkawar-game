using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDiceViewer : SingletonMB<UIDiceViewer>
{
    public GameObject container;

    public void ShowDiceRoll(System.Action onComplete)
    {
        container.SetActive(true);

        DicesController.Instance.GiveItARoll(()=>
        {
            container.SetActive(false);
            onComplete?.Invoke();

        });
    }
}
