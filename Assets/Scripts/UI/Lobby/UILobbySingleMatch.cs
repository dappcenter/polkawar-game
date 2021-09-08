using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Nakama;
using TMPro;

public class UILobbySingleMatch : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI nameText;

    private IApiMatch myMatch;

    public void Initialize(IApiMatch apiMatch)
    {
        myMatch = apiMatch;
        nameText.text = myMatch.Label;
    }

    public void Fight()
    {
        UILobbyManager.Instance.Fight(this);
    }
}
