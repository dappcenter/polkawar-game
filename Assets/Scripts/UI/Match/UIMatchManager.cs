using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class UIMatchManager : SingletonMB<UIMatchManager>
{
    public GameObject container;
    public GameObject waitingForOpponentPanel;

    public Transform playerPosRot, opponentPosRot;

    public void JoinMatch(UILobbySingleMatch uILobbySingleMatch)
    {
        container.SetActive(true);
        GameManager.Instance.JoinRoom(uILobbySingleMatch.myRoom.Name);
    }

    public void StartMatch()
    {
        container.SetActive(true);
        GameManager.Instance.CreateRoom();
    }

    public void MatchJoined()
    {
        Debug.Log("MatchJoined");
    }

    public void StartFight()
    {
        waitingForOpponentPanel.SetActive(false);
        GameManager.Instance.SpawnPlayer();
    }

    public void SpawnCharacterOnMyside()
    {
        GameObject prefab = CharacterDataContainer.Instance.GetDataByName(PlayerData.Instance.playerData.character.name).characterPrefab;
        Instantiate(prefab, playerPosRot.position, playerPosRot.rotation, transform);
    }

    public void SpawnCharacterOnOpponentside(string chracterName)
    {
        GameObject prefab = CharacterDataContainer.Instance.GetDataByName(chracterName).characterPrefab;
        Instantiate(prefab, opponentPosRot.position, opponentPosRot.rotation, transform);
    }
}
