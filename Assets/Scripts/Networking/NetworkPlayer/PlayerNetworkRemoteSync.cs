//using Nakama;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetworkRemoteSync : MonoBehaviour
{
    //Reference relevent network data about a player who is remotelty connected.
    //stores MatchId and user attributes of the remote 
    public RemotePlayerNetworkData networkData;

    private Transform playerTransform;


    private void Start()
    {
        playerTransform = GetComponent<Transform>();
       
        // Add an event listener to handle incoming match state data.
        //GameManager.Instance.nakamaConnection.Socket.ReceivedMatchState += EnqueueOnReceivedMatchState;
    }

    private void OnDestroy()
    {
        // Renove an event listener to handle incoming match state data.
        //if (GameManager.Instance != null)
            //GameManager.Instance.nakamaConnection.Socket.ReceivedMatchState -= EnqueueOnReceivedMatchState;
    }

    /// <summary>
    /// Passes execution of the event handler to the main unity thread so that we can interact with GameObjects.
    /// </summary>
    /// <param name="matchState">The incoming match state data.</param>
    //private void EnqueueOnReceivedMatchState(IMatchState matchState)
    //{
    //    //var mainThread = UnityMainThreadDispatcher.Instance();
    //    //mainThread.Enqueue(() => OnReceivedMatchState(matchState));
    //}
}
