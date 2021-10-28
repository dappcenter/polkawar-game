using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBillboard : MonoBehaviour
{
    private Camera mainCam;

    private void Awake()
    {
        mainCam = Camera.main;

        if (mainCam == null) Debug.LogError("Couldn't find main camera for billboard UI");
    }

    public void FrontFacingHealthBar()
    {
        if (mainCam)
        {
            transform.LookAt(transform.position + mainCam.transform.forward);
            //transform.Rotate(0, 180, 0);
        }
    }

    private void Update()
    {
        FrontFacingHealthBar();
    }
}
