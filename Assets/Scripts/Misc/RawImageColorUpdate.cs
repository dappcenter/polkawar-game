using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class RawImageColorUpdate : MonoBehaviour
{
    private RawImage rawImage;
    private Color color;

    private void Awake()
    {
        rawImage = GetComponent<RawImage>();
    }

    public void UpdateColorAlpha(float alpha)
    {
        if (!rawImage) return;

        color = rawImage.color;
        color.a = alpha;
        rawImage.color = color;
    }
}
