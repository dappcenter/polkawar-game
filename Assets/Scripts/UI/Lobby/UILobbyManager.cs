using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Nakama;

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

    public void Initialize(List<IApiMatch> apiMatches)
    {
        mainPortrait.sprite = GameDataManager.Instance.GetMyCharacterData().uiLobbyPortrait;

        uILobbySingleMatches.ReturnAll();
        noMatchPanel.SetActive(apiMatches.Count == 0);
        container.SetActive(true);

        if(apiMatches.Count == 0) return;

        for (int i = 0; i < apiMatches.Count; i++)
        {
            uILobbySingleMatches.Get().Initialize(apiMatches[i]);
        }
    }

    public void Fight(UILobbySingleMatch uILobbySingleMatch)
    {

    }

    public void CreateMatch()
    {

    }
}
