using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoPlayerForWeb : MonoBehaviour
{
    public float delay = 0f;
    private VideoPlayer myVP;

    private void Awake()
    {
        myVP = GetComponent<VideoPlayer>();
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(delay);

        //myVP.
    }
}
