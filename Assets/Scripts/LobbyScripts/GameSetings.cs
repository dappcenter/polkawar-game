using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Manager/GameSettings")]
public class GameSetings : ScriptableObject
{
 
    [SerializeField]
    private string _gameversion = "0.0.0";

    public string GameVersion { get { return _gameversion; } }


    [SerializeField]
    private string nickName = "War";

    public string NickName
    {
        get
        {
            int value = Random.Range(0, 9999);
            return nickName + value.ToString();
        }
    }

}
