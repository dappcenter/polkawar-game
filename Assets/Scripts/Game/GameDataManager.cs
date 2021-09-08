using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : SingletonMB<GameDataManager>
{
    public CharacterDataContainer characterDataContainer;

    public CharacterData GetMyCharacterData()
    {
        return characterDataContainer.GetDataByName(PlayerData.Instance.playerData.character.name);
    }
}
