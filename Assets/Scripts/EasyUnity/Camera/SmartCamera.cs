using System;
using UnityEngine;

[Obsolete]
[RequireComponent(typeof(Camera))]
public partial class SmartCamera : MonoBehaviour
{
    public Camera myCamera;

    protected static SmartCamera main;
    public static SmartCamera Main => main ? main : main = Camera.main.GetComponent<SmartCamera>();

    public bool IsMain => Main.Equals(this);

    private void Awake()
    {
        myCamera = GetComponent<Camera>();
        OnWindowAspectChanged();
        
    }

    private void LateUpdate()
    {
        if (windowAspect != ScreenWidth / ScreenHeight)
            OnWindowAspectChanged();

        // GetInput();
        UpdateOrtoTransition();
        DoFollow();
        Shake();
    }
}
