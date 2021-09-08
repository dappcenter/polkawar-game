using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetworkLocalSync : MonoBehaviour
{
    private Transform playerTransform;
    
    void Start()
    {
        playerTransform = GetComponent<Transform>();
    }

}
