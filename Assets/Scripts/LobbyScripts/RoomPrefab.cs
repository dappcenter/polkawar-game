using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Text text;
    
    public RoomInfo RoomInfo { get; private set; }
    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;
        text.text = "("+ roomInfo.PlayerCount + "/"+ roomInfo.MaxPlayers + ") , " + roomInfo.Name;
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);
        //SceneManager.LoadScene("GamePlay");
    }
}
