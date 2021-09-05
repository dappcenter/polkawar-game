using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Character/Data/CreateSingleCharacter")]
public class CharacterData : BaseCharacterData
{
    public Sprite uiSprite;

    [ShowInInspector]public string Name => name;
}
