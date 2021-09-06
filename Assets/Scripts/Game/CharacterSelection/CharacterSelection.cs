using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public static CharacterSelection Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectCharacter(CharacterData characterData)
    {

    }
}
