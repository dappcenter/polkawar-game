using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Sirenix.OdinInspector;

public class GameManager : MonoBehaviour
{
    public string playerName;
    public GameObject player = null;
    public List<GameObject> spawnPositions = new List<GameObject>();
    
    [SerializeField, ReadOnly]
    private int index = 0;


    private void Start() => NetworkManager.Instance.OnRoomJoinedEvent.AddListener(OnRoomJoined);

    public void OnRoomJoined()
    {
        player = PhotonNetwork.Instantiate("RPG-Character", spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);

        player.GetComponent<PlayerController>()?.SetPlayerName(playerName);

        index++;
    }
}
