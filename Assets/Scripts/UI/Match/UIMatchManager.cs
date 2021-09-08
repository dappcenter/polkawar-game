using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Nakama;

public class UIMatchManager : SingletonMB<UIMatchManager>
{
    public GameObject container;
    public GameObject waitingForOpponentPanel;

    public void JoinMatch(IApiMatch apiMatch)
    {

    }

    public void StartMatch()
    {
        container.SetActive(true);
        waitingForOpponentPanel.SetActive(true);
    }
}
