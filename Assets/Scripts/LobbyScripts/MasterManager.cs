using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Singletons/MasterManager")]
public class MasterManager : SingeltonScriptableObject<MasterManager>
{
    [SerializeField]
    private GameSetings _gameSettings;

    public static GameSetings GameSetings { get { return Instance._gameSettings; } }

}
