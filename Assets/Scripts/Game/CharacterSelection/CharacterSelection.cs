using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public static CharacterSelection Instance;
    public CharacterData selectedCharacter;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectCharacter(CharacterData characterData)
    {
        NakamaClient.Instance.characterServerInfo.selectedCharacterName = characterData.Name;

        NakamaClient.Instance.SaveCharacterInfo();


        MenuController.Instance.DisableCharacterSelectionPanel();
        MenuController.Instance.EnableLobbyPanel();
    }
}
