using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Sirenix.OdinInspector;

public class GameManager : MonoBehaviour
{
    public List<GameObject> spawnPositions = new List<GameObject>();
    [SerializeField, ReadOnly]
    private int index = 0;

    public GameObject player = null;

    private void Start()
    {
        NetworkManager.Instance.OnRoomJoinedEvent.AddListener(OnRoomJoined);
    }

    public void OnRoomJoined()
    {
        player = PhotonNetwork.Instantiate("Warrior0", spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        index++;
    }
}
