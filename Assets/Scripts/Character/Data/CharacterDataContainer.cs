using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Character/Data/CharacterDataContainer")]
public class CharacterDataContainer : SingletonSO<CharacterDataContainer>
{
    public SerializableDictionary<string, CharacterData> allCharactersData = new SerializableDictionary<string, CharacterData>();

    [Button]
    public void LoadAllCharacters()
    {
        allCharactersData.Clear();
        CharacterData[] characterDatas = Resources.LoadAll<CharacterData>("");

        for (int i = 0; i < characterDatas.Length; i++)
        {
            allCharactersData.Add(characterDatas[i].Name, characterDatas[i]);
        }
    }

    public CharacterData GetDataByName(string characterName)
    {
        if(allCharactersData.TryGetValue(characterName, out CharacterData characterData))
        {
            return characterData;
        }

        return null;
    }
}
