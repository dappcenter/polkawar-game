using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameObjectEvents : MonoBehaviour
{
    public UnityEvent onAwake, onEnable, onStart, onDisable;

    private void Awake()
    {
        onAwake.Invoke();
    }

    private void OnEnable()
    {
        onEnable.Invoke();
    }

    void Start()
    {
        onStart.Invoke();
    }

    private void OnDisable()
    {
        onDisable.Invoke();
    }
}
