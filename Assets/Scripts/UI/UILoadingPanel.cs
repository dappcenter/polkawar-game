using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILoadingPanel : SingletonMB<UILoadingPanel>
{
    public GameObject container;

    public void ShowLoading()
    {
        container.SetActive(true);
    }

    public void HideLoading()
    {
        container.SetActive(false);
    }
}
