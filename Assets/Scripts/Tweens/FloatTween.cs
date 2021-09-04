using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatTween : MonoBehaviour
{
    public float from = 0f, to = 1f, time = 1f, delay = 0f;
    public bool playOnAwake = false;

    public UnityEvent<float> OnUpdate;

    // Start is called before the first frame update
    void  Start()
    {
        if (playOnAwake) Play();
    }

    public void Play()
    {
        LeanTween.value(from, to, time).setDelay(delay).setOnUpdate((float value) => {

            OnUpdate.Invoke(value);

        });
    }
}
