using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddDisplayName : MonoBehaviour
{
    public TextMeshProUGUI displayName;

    public void SubmitDisplayName()
    {
        NakamaClient.Instance.UpdateDisplayName(displayName.text);
        gameObject.SetActive(false);
        MenuController.Instance.EnableLoadingPanel();
    }
}
