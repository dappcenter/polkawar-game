using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    [SerializeField]
    private Text roomName;

    public void OnCreateRoomClick()
    {
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }

        UIController.Instance.loadingPanel.SetActive(true);

        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom(roomName.text, options, TypedLobby.Default);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Created room Failed " + message, this);
    }
}
