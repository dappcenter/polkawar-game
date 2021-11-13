using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPlayerStats : MonoBehaviour
{
    public TextMeshProUGUI playerTypeName;

    public void UpdateStats()
    {
        playerTypeName.text = PlayerData.playerData.character.name;
    }
}
