using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class UIMatchManager : SingletonMB<UIMatchManager>
{
    public GameObject container;
    public GameObject waitingForOpponentPanel;

    public void JoinMatch(UILobbySingleMatch uILobbySingleMatch)
    {
        container.SetActive(true);
    }

    public void StartMatch()
    {
        container.SetActive(true);
    }

    public void MatchJoined()
    {

    }
}
