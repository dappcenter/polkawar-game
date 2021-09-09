using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Photon.Pun;
//using Photon.Realtime;

public class UILobbyManager : SingletonMB<UILobbyManager>
{
    public Image mainPortrait;

    public UILobbySingleMatch singleMatchPrefab;
    public EasyPool<UILobbySingleMatch> uILobbySingleMatches;

    public Transform matchesParent;

    public GameObject container;
    public GameObject noMatchPanel;

    protected override void Awake()    
    {
        base.Awake();
        uILobbySingleMatches = new EasyPool<UILobbySingleMatch>(singleMatchPrefab, matchesParent);
    }
    /*
    public void Initialize(List<RoomInfo> roomList)
    {
        UILoadingPanel.Instance.HideLoading();

        mainPortrait.sprite = GameDataManager.Instance.GetMyCharacterData().uiLobbyPortrait;

        uILobbySingleMatches.ReturnAll();
        noMatchPanel.SetActive(roomList.Count == 0);
        container.SetActive(true);

        if(roomList.Count == 0) return;

        for (int i = 0; i < roomList.Count; i++)
        {
            uILobbySingleMatches.Get().Initialize(roomList[i]);
        }
    }
    */
    public void Fight(UILobbySingleMatch uILobbySingleMatch)
    {
        UIMatchManager.Instance.JoinMatch(uILobbySingleMatch);
        container.SetActive(false);
    }

    public void CreateMatch()
    {
        container.SetActive(false);
        UIMatchManager.Instance.StartMatch();
    }
}
