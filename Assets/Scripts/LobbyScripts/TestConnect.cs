using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConnect : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Connecting to server");
        PhotonNetwork.NickName = "War";
        int value = Random.Range(0, 9999);
        string nickname = "War";
        nickname = nickname + value.ToString();
        PhotonNetwork.GameVersion = nickname;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to server");
        Debug.Log(PhotonNetwork.LocalPlayer.NickName);

        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Not Connected to server" + cause.ToString());
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Join Lobby");
    }
}
