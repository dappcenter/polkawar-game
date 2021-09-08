using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Character/Data/CreateSingleCharacter")]
public class CharacterData : BaseCharacterData
{
    [PreviewField]
    public Sprite uiSprite, uiLobbyPortrait;

    [ShowInInspector]public string Name => name;

    public GameObject localPlayerPrefab, remotePlayerPrefab;
}
