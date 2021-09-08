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
        NakamaClient.Instance.JoinMatch(apiMatch);
        container.SetActive(true);
        waitingForOpponentPanel.SetActive(true);
    }

    public void StartMatch()
    {
        NakamaClient.Instance.StartMatch();
        container.SetActive(true);
        waitingForOpponentPanel.SetActive(true);
    }
}
