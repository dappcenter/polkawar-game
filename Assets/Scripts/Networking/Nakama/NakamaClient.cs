using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using Nakama;
//using Nakama.TinyJson;
using System;
using Sirenix.OdinInspector;

public class NakamaClient : SingletonMB<NakamaClient>
{
    /*
    //private readonly IClient client = new Client("http", "108.160.141.74", 7351, "defaultkey");

    //public string email = "imran@gmail.com";
    //public string password = "myPassword";

    [HideInInspector]
    public ISocket socket;
    [HideInInspector]
    public ISession session;
    [HideInInspector]
    public IClient client;
    [HideInInspector]
    public IApiAccount account;
    [HideInInspector]
    public IMatchmakerTicket matchmakerTicket;
    [HideInInspector]
    public IMatchmakerMatched matchmakerMatched;
    [HideInInspector]
    public IMatchPresenceEvent matchPresenceEvent;

    public UnityEvent OnConnected;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(5f);

        Login();
    }

    // Start is called before the first frame update
    async void Login()
    {
        client = new Client("http", "108.160.141.74", 7350, "polkawar", UnityWebRequestAdapter.Instance);

        session = await client.AuthenticateDeviceAsync(PlayerPrefs.GetString("Account", "imran@gmail.com"));

        socket = client.NewSocket();
        await socket.ConnectAsync(session, true);
        Debug.Log(session);
        Debug.Log(socket);

        socket.ReceivedMatchmakerMatched += Socket_ReceivedMatchmakerMatched;
        socket.ReceivedMatchPresence += Socket_ReceivedMatchPresence;

        matchmakerTicket = await socket.AddMatchmakerAsync("*", 2, 2);
        
        var matches = await client.ListMatchesAsync(session, 2, 2, 2, false, null, null);

        List<IApiMatch> allAvailableMatches = new List<IApiMatch>();

        foreach (var item in matches.Matches)
        {
            allAvailableMatches.Add(item);
        }

        UILobbyManager.Instance.Initialize(allAvailableMatches);

        OnConnected.Invoke();
    }

    private void Socket_ReceivedMatchPresence(IMatchPresenceEvent obj)
    {
        Debug.Log("Socket_ReceivedMatchPresence");
        matchPresenceEvent = obj;
    }

    public void StartMatch()
    {
        socket.JoinMatchAsync(null);
    }

    public void JoinMatch(IApiMatch apiMatch)
    {
        socket.JoinMatchAsync(apiMatch.MatchId);
    }

    private void Socket_ReceivedMatchmakerMatched(IMatchmakerMatched obj)
    {
        Debug.Log("Socket_ReceivedMatchmakerMatched");
        matchmakerMatched = obj;
    }

    */
}