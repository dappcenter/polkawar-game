using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public NakamaConnection nakamaConnection;
    public GameObject findMatch, makingMatch;
    public Button findMatchButton;
    public InputField nameField;
    public InputField numberOfPlayersField;

    private IDictionary<string, GameObject> players = new Dictionary<string, GameObject>();

    async void Start()
    {
        // Connect to the Nakama server.
        await nakamaConnection.Connect();

        // Enables the Find Match button.
        findMatchButton.interactable = true;

    }
    public async void FindMatch()
    {
        findMatch.SetActive(false);
        makingMatch.SetActive(true);
        
        //store the name set in the input field
        PlayerPrefs.SetString("Name", nameField.text);

        //Find  a match
        await nakamaConnection.FindMatch();

        nakamaConnection.Socket.ReceivedMatchmakerMatched += Socket_ReceivedMatchmakerMatched;
    }

    private void Socket_ReceivedMatchmakerMatched(Nakama.IMatchmakerMatched obj)
    {
        //GameManager.Instance.
        //// For each new user that joins, spawn a player for them.
        //foreach (var user in matchPresenceEvent.Joins)
        //{
        //    SpawnPlayer(matchPresenceEvent.MatchId, user);
        //}
    }

    public async void CancelMatch() => await nakamaConnection.CancelMatchmaking();
}
