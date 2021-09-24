//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.Linq;
//using Photon.Pun;
//using Photon.Realtime;
//using Sirenix.OdinInspector;

//public class GameManager : MonoBehaviourPunCallbacks//, IMatchmakingCallbacks//, IConnectionCallbacks
//{
//    public static GameManager Instance;

//    private void Awake()
//    {
//        Instance = this;
        
//    }
    
//    IEnumerator Start()
//    {
//        yield return new WaitForSeconds(3);

//        PhotonNetwork.GameVersion = "0.01";

//        PhotonNetwork.ConnectUsingSettings();
//    }

//    public void JoinRoom(string roomName)
//    {
//        PhotonNetwork.JoinRoom(roomName);
//    }

//    public void CreateRoom()
//    {
//        RoomOptions roomOptions = new RoomOptions();
//        roomOptions.IsVisible = true;
//        roomOptions.MaxPlayers = 2;
//        roomOptions.IsOpen = true;

//        PhotonNetwork.CreateRoom(PlayerData.Instance.playerData.character.username, roomOptions);
//    }

//    [PunRPC]
//    public void ShareCharacterName(string charName)
//    {
//        UIMatchManager.Instance.SpawnCharacterOnOpponentside(charName);
//    }

//    public void SpawnPlayer()
//    {
//        photonView.RPC("ShareCharacterName", RpcTarget.Others, PlayerData.Instance.playerData.character.name);
//        UIMatchManager.Instance.SpawnCharacterOnMyside();
//    }

//    private void CheckIfHaveTwoPlayers()
//    {
//        if(PhotonNetwork.CurrentRoom.PlayerCount == 2)
//        {
//            UIMatchManager.Instance.StartFight();
//        }
//    }

//    public override void OnPlayerEnteredRoom(Player newPlayer)
//    {
//        Debug.Log("OnPlayerEnteredRoom");
//        CheckIfHaveTwoPlayers();
//    }

//    public override void OnPlayerLeftRoom(Player otherPlayer)
//    {
//        Debug.Log("OnPlayerLeftRoom");
//        CheckIfHaveTwoPlayers();
//    }

//    public override void OnCreatedRoom()
//    {
//        Debug.Log("OnCreatedRoom");
//    }

//    public override void OnCreateRoomFailed(short returnCode, string message)
//    {
//        Debug.Log("OnCreateRoomFailed");
//    }

//    public override void OnFriendListUpdate(List<FriendInfo> friendList)
//    {
//        Debug.Log("OnFriendListUpdate");
//    }

//    public override void OnJoinedRoom()
//    {
//        Debug.Log("OnJoinedRoom");
//        UIMatchManager.Instance.MatchJoined();

//        CheckIfHaveTwoPlayers();
//    }

//    public override void OnJoinRandomFailed(short returnCode, string message)
//    {
//        Debug.Log("OnJoinRandomFailed");
//    }

//    public override void OnJoinRoomFailed(short returnCode, string message)
//    {
//        Debug.Log("OnJoinRoomFailed");
//    }

//    public override void OnLeftRoom()
//    {
//        Debug.Log("OnLeftRoom");
//    }

//    public override void OnConnected()
//    {
//        Debug.Log("OnConnected");
//    }
    
//    public override void OnConnectedToMaster()
//    {
//        Debug.Log("OnConnectedToMaster");
//        PhotonNetwork.JoinLobby(TypedLobby.Default);
//    }

//    public override void OnJoinedLobby()
//    {
//        Debug.Log("OnJoinedLobby");
//    }

//    public override void OnRoomListUpdate(List<RoomInfo> roomList)
//    {
//        Debug.Log("OnRoomListUpdate " + roomList.Count);

//        UILobbyManager.Instance.Initialize(roomList);
//    }

//    public override void OnLeftLobby()
//    {
//        Debug.Log("OnLeftLobby");
//    }

//    public override void OnErrorInfo(ErrorInfo errorInfo)
//    {
//        Debug.Log("OnErrorInfo");
//    }

//    public override void OnDisconnected(DisconnectCause cause)
//    {
//        Debug.Log("OnDisconnected");
//    }

//    public override void OnRegionListReceived(RegionHandler regionHandler)
//    {
//        Debug.Log("OnRegionListReceived");
//    }

//    public override void OnCustomAuthenticationResponse(Dictionary<string, object> data)
//    {
//        Debug.Log("OnCustomAuthenticationResponse");
//    }

//    public override void OnCustomAuthenticationFailed(string debugMessage)
//    {
//        Debug.Log("OnCustomAuthenticationFailed");
//    }
    
//}
