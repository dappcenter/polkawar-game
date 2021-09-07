using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerData : MonoBehaviour
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public Root playerData = new Root();

    IEnumerator Start()
    {
        string url = "https://api.polkawar.com/usercharacter/profile/0x9D7117a07fca9F22911d379A9fd5118A5FA4F448";
        WWW www = new WWW(url);
        yield return www;
        if (www.error == null)
        {
            // Processjson(www.data);
            playerData = JsonUtility.FromJson<Root>(www.text);
        }
        else
        {
            Debug.Log("ERROR: " + www.error);
        }
    }


}

[Serializable]
public class Root
{
    [ShowInInspector] public Character character ;
    [ShowInInspector] public List<Item> items ;
}
[Serializable]
public class Properties
{
    [ShowInInspector] public int xp ;
    [ShowInInspector] public int hp ;
    [ShowInInspector] public int mp ;
    [ShowInInspector] public int Patk ;
    [ShowInInspector] public int Pdef ;
    [ShowInInspector] public double speed ;
    [ShowInInspector] public int accuracy ;
    [ShowInInspector] public int bDam ;
    [ShowInInspector] public int bonus ;
}
[Serializable]
public class Character
{
    [ShowInInspector] public DateTime createdDate ;
    [ShowInInspector] public string _id ;
    [ShowInInspector] public string tokenId ;
    [ShowInInspector] public Properties properties ;
    [ShowInInspector] public string name ;
    [ShowInInspector] public string username ;
    [ShowInInspector] public string owner ;
    [ShowInInspector] public string hashImage ;
    [ShowInInspector] public string level ;
    [ShowInInspector] public string description ;
    [ShowInInspector] public int __v ;
}
[Serializable]
public class Item
{
    [ShowInInspector] public string category ;
    [ShowInInspector] public int level ;
    [ShowInInspector] public int price ;
    [ShowInInspector] public string currency ;
    [ShowInInspector] public List<string> gallery ;
    [ShowInInspector] public List<object> owner ;
    [ShowInInspector] public DateTime createdDate ;
    [ShowInInspector] public string _id ;
    [ShowInInspector] public int id ;
    [ShowInInspector] public string name ;
    [ShowInInspector] public string description ;
    [ShowInInspector] public Properties properties ;
    [ShowInInspector] public string hashItem ;
    [ShowInInspector] public string hashImage ;
    [ShowInInspector] public string forCharacter ;
    [ShowInInspector] public int __v ;
}
