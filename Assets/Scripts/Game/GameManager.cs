using Nakama;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nakama;

public class GameManager : MonoBehaviour
{
    public NakamaConnection nakamaConnection;
    public GameObject NetworkLocalPlayerPrefab;
    public GameObject NetworkRemotePlayerPrefab;
    public Transform[] spawnPoints;

    private Dictionary<string, GameObject> players = new Dictionary<string, GameObject>();
    private IUserPresence localUser;
    private GameObject localPlayer;
    private IMatch currentMatch;


    async void Start()
    {
        await nakamaConnection.Connect();
    }

    /// <summary>
    /// Spawns a player.
    /// </summary>
    /// <param name="matchId">The match the player is connected to.</param>
    /// <param name="user">The player's network presence data.</param>
    /// <param name="spawnIndex">The spawn location index they should be spawned at.</param>
    private void SpawnPlayer(string matchId, IUserPresence user, int spawnIndex = -1)
    {
        // If the player has already been spawned, return early.
        if (players.ContainsKey(user.SessionId))
            return;

        // Set a variable to check if the player is the local player or not based on session ID.
        var isLocal = user.SessionId == localUser.SessionId;

        // Choose the appropriate player prefab based on if it's the local player or not.
        var playerPrefab = isLocal ? NetworkLocalPlayerPrefab : NetworkRemotePlayerPrefab;

        // Spawn the new player.
        var player = Instantiate(playerPrefab, spawnPoints[spawnIndex].position, Quaternion.LookRotation(Vector3.zero));

        // Setup the appropriate network data values if this is a remote player.
        if (!isLocal)
        {
            //player.GetComponent<PlayerNetworkRemoteSync>().NetworkData = new RemotePlayerNetworkData
            //{
            //    MatchId = matchId,
            //    User = user
            //};
        }

        // Add the player to the players array.
        players.Add(user.SessionId, player);

        //// If this is our local player, add a listener for the PlayerDied event.
        //if (isLocal)
        //    localPlayer = player;
    }
}
