using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Nakama;
using System;

public class NakamaClient : MonoBehaviour
{
    public static NakamaClient Instance;
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

    public UnityEvent OnConnected;

    private void Awake()
    {
        Instance = this;
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);

        Login();
    }

    // Start is called before the first frame update
    async void Login()
    {
        client = new Client("http", "108.160.141.74", 7350, "polkawar", UnityWebRequestAdapter.Instance);

        session = await client.AuthenticateDeviceAsync(PlayerPrefs.GetString("Account"));

        //session = await client.AuthenticateEmailAsync(email, password);
        socket = client.NewSocket();
        await socket.ConnectAsync(session, true);
        Debug.Log(session);
        Debug.Log(socket);

        //client.UpdateAccountAsync()
        //client.GetUsersAsync()
        //client.GetAccountAsync()

        account = await client.GetAccountAsync(session);
        var user = account.User;
        Debug.LogFormat("User id '{0}' username '{1}'", user.Id, user.Username);
        Debug.LogFormat("User wallet: '{0}'", account.Wallet);

        OnConnected.Invoke();
    }
}
