using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nakama;
using System;

public class NakamaClient : MonoBehaviour
{
    //private readonly IClient client = new Client("http", "108.160.141.74", 7351, "defaultkey");

    public string email = "imran@gmail.com";
    public string password = "myPassword";

    private ISocket socket;

    // Start is called before the first frame update
    async void Start()
    {

        IClient client = new Client("http", "108.160.141.74", 7350, "polkawar", UnityWebRequestAdapter.Instance);
        var session = await client.AuthenticateEmailAsync(email, password);

        socket = client.NewSocket();

        await socket.ConnectAsync(session, true);

        Debug.Log(session);
        Debug.Log(socket);

        //CheckPing("http://108.160.141.74:7351/#/status");
        //CheckPing("www.google.com");
    }
    public void CheckPing(string ip)
    {
        StartCoroutine(StartPing(ip));
    }

    IEnumerator StartPing(string ip)
    {
        WaitForSeconds f = new WaitForSeconds(0.05f);
        Ping p = new Ping(ip);
        while (p.isDone == false)
        {
            yield return f;
        }
        PingFinished(p);
    }


    public void PingFinished(Ping p)
    {
        Debug.Log(p);
        // stuff when the Ping p has finshed....
    }

}
