using Nakama;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nakama;
using System.Threading.Tasks;
using System.Linq;
using Nakama.TinyJson;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public NakamaConnection nakamaConnection;
    public GameObject NetworkLocalPlayerPrefab;
    public GameObject NetworkRemotePlayerPrefab;
    public Transform[] spawnPoints;

    private Dictionary<string, GameObject> players = new Dictionary<string, GameObject>();
    private IUserPresence localUser;
    private IMatch currentMatch;
    private GameObject localPlayer;
    private string localDisplayName;
    private int spawnIndex = 0;


    private void Awake() => Instance = this;

    async void Start()
    {
        //Connect to Nakama server
        await nakamaConnection.Connect();

        // Get a reference to the UnityMainThreadDispatcher.
        // We use this to queue event handler callbacks on the main thread.
        // If we did not do this, we would not be able to instantiate objects or manipulate things like UI.
        var mainThread = UnityMainThreadDispatcher.Instance();

        // Setup network event handlers.
        nakamaConnection.Socket.ReceivedMatchmakerMatched += m => mainThread.Enqueue(() => OnReceivedMatchmakerMatched(m));
        nakamaConnection.Socket.ReceivedMatchPresence += m => mainThread.Enqueue(() => OnReceivedMatchPresence(m));
        nakamaConnection.Socket.ReceivedMatchState += m => mainThread.Enqueue(async () => await OnReceivedMatchState(m));

    }

    /// <summary>
    /// Called when a MatchmakerMatched event is received from the Nakama server.
    /// </summary>
    /// <param name="matched">The MatchmakerMatched data.</param>
    private async void OnReceivedMatchmakerMatched(IMatchmakerMatched matched)
    {
        //Debug.LogFormat("Received: {0}", matched.Self.Presence);
        //var opponents = string.Join(",\n  ", matched.Users); // printable list.
        //Debug.LogFormat("Matched opponents: [{0}]", opponents);

        Debug.Log(matched.Ticket + "  = match ticket \n" +
                matched.Users + "  = match users  \n" +
                matched.Self + "  = match self \n" +
                matched.MatchId + " = match ID  \n" +
                matched.Token + " = match token");

        // Cache a reference to the local user.
        localUser = matched.Self.Presence;
        Debug.Log(localUser + "  = local user");

        // Join the match.
        var match = await nakamaConnection.Socket.JoinMatchAsync(matched);

        // Spawn a player instance for each connected user.
        foreach (var user in match.Presences)
        {
            SpawnPlayer(match.Id, user, spawnPoints[spawnIndex]);
        }

        // Cache a reference to the current match.
        currentMatch = match;
    }

    /// <summary>
    /// Called when a player/s joins or leaves the match.
    /// </summary>
    /// <param name="matchPresenceEvent">The MatchPresenceEvent data.</param>
    private void OnReceivedMatchPresence(IMatchPresenceEvent matchPresenceEvent)
    {
        // For each new user that joins, spawn a player for them.
        foreach (var user in matchPresenceEvent.Joins)
        {
            SpawnPlayer(matchPresenceEvent.MatchId, user, spawnPoints[spawnIndex]);
        }

        // For each player that leaves, despawn their player.
        foreach (var user in matchPresenceEvent.Leaves)
        {
            if (players.ContainsKey(user.SessionId))
            {
                Destroy(players[user.SessionId]);
                players.Remove(user.SessionId);
            }
        }
    }

    /// <summary>
    /// Called when new match state is received.
    /// </summary>
    /// <param name="matchState">The MatchState data.</param>
    private async Task OnReceivedMatchState(IMatchState matchState)
    {
        // Get the local user's session ID.
        var userSessionId = matchState.UserPresence.SessionId;

        // If the matchState object has any state length, decode it as a Dictionary.
        // var state = matchState.State.Length > 0 ? System.Text.Encoding.UTF8.GetString(matchState.State).FromJson<Dictionary<string, string>>() : null;

        // Decide what to do based on the Operation Code as defined in OpCodes.
        switch (matchState.OpCode)
        {
            case OpCodes.Died:
                // Get a reference to the player who died and destroy their GameObject after 0.5 seconds and remove them from our players array.
                var playerToDestroy = players[userSessionId];
                Destroy(playerToDestroy, 0.5f);
                players.Remove(userSessionId);

                // If there is only one player left and that us, announce the winner and start a new round.
                if (players.Count == 1 && players.First().Key == localUser.SessionId)
                {
                    // AnnounceWinnerAndStartNewRound();
                }
                break;
            case OpCodes.Respawned:
                // Spawn the player at the chosen spawn index.
                //SpawnPlayer(currentMatch.Id, matchState.UserPresence, spawnPoints[spawnIndex] /*(state["spawnIndex"])*/);
                break;
            case OpCodes.NewRound:
                // Display the winning player's name and begin a new round.
                //await AnnounceWinnerAndRespawn(state["winningPlayerName"]);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Spawns a player.
    /// </summary>
    /// <param name="matchId">The match the player is connected to.</param>
    /// <param name="user">The player's network presence data.</param>
    /// <param name="spawnPosition">The spawn location index they should be spawned at.</param>
    private void SpawnPlayer(string matchId, IUserPresence user, Transform spawnPosition)
    {
        // If the player has already been spawned, return early.
        if (players.ContainsKey(user.SessionId))
            return;

        // Set a variable to check if the player is the local player or not based on session ID.
        var isLocal = user.SessionId == localUser.SessionId;

        // Choose the appropriate player prefab based on if it's the local player or not.
        var playerPrefab = isLocal ? NetworkLocalPlayerPrefab : NetworkRemotePlayerPrefab;

        // Spawn the new player.
        var player = Instantiate(playerPrefab, spawnPosition.position, Quaternion.LookRotation(Vector3.zero));

        // Setup the appropriate network data values if this is a remote player.
        if (!isLocal)
        {
            if (player.GetComponent<PlayerNetworkRemoteSync>())
            {
                player.GetComponent<PlayerNetworkRemoteSync>().networkData = new RemotePlayerNetworkData
                {
                    MatchId = matchId,
                    User = user
                };
            }
        }

        // Add the player to the players array.
        players.Add(user.SessionId, player);

        // If this is our local player, add a listener for the PlayerDied event.
        if (isLocal)
            localPlayer = player;
    }

    /// <summary>
    /// Sets the local user's display name.
    /// </summary>
    /// <param name="displayName">The new display name for the local user</param>
    public void SetDisplayName(string displayName)
    {
        // We could set this on our Nakama Client using the below code:
        // await NakamaConnection.Client.UpdateAccountAsync(NakamaConnection.Session, null, displayName);
        // However, since we're using Device Id authentication, when running 2 or more clients locally they would both display the same name when testing/debugging.
        // So in this instance we will just set a local variable instead.
        localDisplayName = displayName;
    }
}
