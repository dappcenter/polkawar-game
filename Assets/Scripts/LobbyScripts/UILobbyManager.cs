using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILobbyManager : MonoBehaviour
{
    public Image portraitImages;
    public Sprite warrior, archer, magician;

    private void OnEnable()
    {
        switch (PlayerData.playerData.character.name)
        {
            case "Warrior":
                portraitImages.sprite = warrior;
                break;
            case "Archer":
                portraitImages.sprite = archer;
                break;
            case "Magician":
                portraitImages.sprite = magician;
                break;
            default:
                break;
        }
    }
}
