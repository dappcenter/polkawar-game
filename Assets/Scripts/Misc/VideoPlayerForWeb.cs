using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoPlayerForWeb : MonoBehaviour
{
    public string videoPathInStramingAsset;
    public float delay = 0f;
    public bool playOnAwake = false;
    private VideoPlayer myVP;

    private void Awake()
    {
        myVP = GetComponent<VideoPlayer>();
        ///Users/imranbinazhar/Documents/Development/Job/Polkabridge/polkawar-game/Assets/StreamingAssets/Intro/IntroVideo.mp4
    }

    private void Start()
    {
        if (playOnAwake) PlayVideo();
    }

    public void PlayVideo()
    {
        StartCoroutine(PlayVideoRoutine());
    }

    // Start is called before the first frame update
    IEnumerator PlayVideoRoutine()
    {
        yield return new WaitForSeconds(delay);

        myVP.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoPathInStramingAsset);
        myVP.Play();
    }
}
