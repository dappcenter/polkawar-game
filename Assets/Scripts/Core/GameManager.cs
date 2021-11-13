using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Sirenix.OdinInspector;
using RPGCharacterAnims;

public class GameManager : MonoBehaviourPunCallbacks
{
    public string playerName;
    public GameObject player = null;
    public List<GameObject> spawnPositions = new List<GameObject>();
    
    [SerializeField, ReadOnly]
    private int index = 0;

    private void Start()
    {
        InitializePlayer();
    }

    public void InitializePlayer()
    {
        player = PhotonNetwork.Instantiate(player.name, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        //player.GetComponent<>()?.SetPlayerName(playerName);
        IncreaseIndex();
    }

    private void IncreaseIndex()
    {
        photonView.RPC("IncreaseIndexRPC", RpcTarget.AllBuffered);
    }

    [PunRPC]
    private void IncreaseIndexRPC()
    {
        index++;
    }
}
