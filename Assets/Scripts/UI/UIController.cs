using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviourPunCallbacks
{
    public static UIController Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void JoinTheRoom(RoomInfo roomInfo)
    {
        PhotonNetwork.JoinRoom(roomInfo.Name);
    }

    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
