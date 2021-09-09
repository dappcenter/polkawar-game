using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks//, IMatchmakingCallbacks//, IConnectionCallbacks
{
    public GameObject NetworkLocalPlayerPrefab;
    public GameObject NetworkRemotePlayerPrefab;
    public Transform[] spawnPoints;

    private void Start()
    {
        PhotonNetwork.GameVersion = "0.01";

        PhotonNetwork.ConnectUsingSettings();

    }

    public override void OnCreatedRoom()
    {
        Debug.Log("OnCreatedRoom");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("OnCreateRoomFailed");
    }

    public override void OnFriendListUpdate(List<FriendInfo> friendList)
    {
        Debug.Log("OnFriendListUpdate");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("OnJoinRandomFailed");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("OnJoinRoomFailed");
    }

    public override void OnLeftRoom()
    {
        Debug.Log("OnLeftRoom");
    }

    public override void OnConnected()
    {
        Debug.Log("OnConnected");
    }
    
    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster");
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby");
        //PhotonNetwork.GetCustomRoomList(TypedLobby.Default, "*");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("OnRoomListUpdate " + roomList.Count);

        if(roomList.Count == 0)
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.IsVisible = true;
            roomOptions.MaxPlayers = 2;
            roomOptions.IsOpen = true;

            PhotonNetwork.CreateRoom(null, roomOptions);
        }
    }

    public override void OnLeftLobby()
    {
        Debug.Log("OnLeftLobby");
    }

    public override void OnErrorInfo(ErrorInfo errorInfo)
    {
        Debug.Log("OnErrorInfo");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("OnDisconnected");
    }

    public override void OnRegionListReceived(RegionHandler regionHandler)
    {
        Debug.Log("OnRegionListReceived");
    }

    public override void OnCustomAuthenticationResponse(Dictionary<string, object> data)
    {
        Debug.Log("OnCustomAuthenticationResponse");
    }

    public override void OnCustomAuthenticationFailed(string debugMessage)
    {
        Debug.Log("OnCustomAuthenticationFailed");
    }
}
