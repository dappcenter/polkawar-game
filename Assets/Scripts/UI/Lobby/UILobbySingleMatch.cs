using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Nakama;
using TMPro;
using Photon.Realtime;

public class UILobbySingleMatch : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI nameText;
    [HideInInspector]
    public RoomInfo myRoom;

    public void Initialize(RoomInfo roomInfo)
    {
        myRoom = roomInfo;
        nameText.text = myRoom.Name;
    }

    public void Fight()
    {
        UILobbyManager.Instance.Fight(this);
    }
}
