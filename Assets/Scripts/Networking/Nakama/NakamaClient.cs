using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Nakama;
//using Nakama.TinyJson;
using System;
using Sirenix.OdinInspector;

public class NakamaClient : SingletonMB<NakamaClient>
{
    //private readonly IClient client = new Client("http", "108.160.141.74", 7351, "defaultkey");

    //public string email = "imran@gmail.com";
    //public string password = "myPassword";

    [HideInInspector]
    public ISocket socket;
    [HideInInspector]
    public ISession session;
    [HideInInspector]
    public IClient client;
    [HideInInspector]
    public IApiAccount account;

    public UnityEvent OnConnected, characterInfoAvailable, characterInfoNotAvailable;

    public CharacterServerInfo characterServerInfo = null;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);

        Login();
    }

    // Start is called before the first frame update
    async void Login()
    {
        client = new Client("http", "108.160.141.74", 7350, "polkawar", UnityWebRequestAdapter.Instance);

        session = await client.AuthenticateDeviceAsync(PlayerPrefs.GetString("Account", "imran@gmail.com"));

        //session = await client.AuthenticateEmailAsync(email, password);
        socket = client.NewSocket();
        await socket.ConnectAsync(session, true);
        Debug.Log(session);
        Debug.Log(socket);

        //client.UpdateAccountAsync()
        //client.GetUsersAsync()
        //client.GetAccountAsync()


        //const string groupName = "Fighters";
        //const string nameFilter = "Fighters";

        //Debug.Log("1");
        ////var group = await client.CreateGroupAsync(session, name);
        //var result2 = await client.ListUserGroupsAsync(session, session.UserId);
        //bool isInGroup = false;
        //foreach (var ug in result2.UserGroups)
        //{
        //    Debug.Log(ug.Group.Name);
        //    if (ug.Group.Name == groupName)
        //    {
        //        isInGroup = true;
        //    }
        //}


        var matches = await client.ListMatchesAsync(session, 2, 2, 2, false, null, null);

        foreach (var item in matches.Matches)
        {

        }



        account = await client.GetAccountAsync(session);
        var user = account.User;
        Debug.LogFormat("User id '{0}' username '{1}'", user.Id, user.Username);
        Debug.LogFormat("User wallet: '{0}'", account.Wallet);

        OnConnected.Invoke();

        var result = await client.ReadStorageObjectsAsync(session, new StorageObjectId[]
        {
            new StorageObjectId(){
                Collection = "Saves",
                Key = "CharacterSelection",
                UserId = session.UserId
            },
        });

        Debug.LogFormat("Read objects: [{0}]", string.Join(",\n  ", result.Objects));

        characterServerInfo = null;

        foreach (var item in result.Objects)
        {
            switch (item.Key)
            {
                case "CharacterSelection":
                    characterServerInfo = JsonUtility.FromJson<CharacterServerInfo>(item.Value);
                    break;
                default:
                    break;
            }
        }
    }

    public void SaveCharacterInfo()
    {
        SaveCharacterInfoAsync();
    }

    async void SaveCharacterInfoAsync()
    {
        var characterServInfo = JsonUtility.ToJson(characterServerInfo);
        // "2" refers to Public Read permission
        // "1" refers to Owner Write permission

        var result = await client.WriteStorageObjectsAsync(session, new WriteStorageObject[]
        {
            new WriteStorageObject()
            {
                Collection = "Saves",
                Key = "CharacterSelection",
                Value = characterServInfo,
                PermissionRead = 2,
                PermissionWrite = 1
            }
        });
    }

    public void ShowCharacterSelection()
    {
        if (characterServerInfo == null)
        {
            characterServerInfo = new CharacterServerInfo();
            characterInfoNotAvailable.Invoke();
        }
        else
        {
            if (!characterServerInfo.hasSelectedCharacter)
            {
                characterInfoNotAvailable.Invoke();
            }
            else
            {
                characterInfoAvailable.Invoke();
            }
        }
    }

    //async void SaveData()
    //{
    //    var armySetup = "{ \"soldiers\": 50 }";
    //    // "2" refers to Public Read permission
    //    // "1" refers to Owner Write permission
        
    //    var result = await client.WriteStorageObjectsAsync(session, new WriteStorageObject[]
    //    {
    //        new WriteStorageObject()
    //        {
    //            Collection = "Saves",
    //            Key = "CharacterSelection",
    //            Value = armySetup,
    //            PermissionRead = 2,
    //            PermissionWrite = 1
    //        }
    //    });

    //    Debug.LogFormat("Stored objects: [{0}]", string.Join(",\n  ", result.Acks));
    //}

    //async void LoadData()
    //{
    //    var result = await client.ReadStorageObjectsAsync(session, new StorageObjectId[]
    //    {
    //        new StorageObjectId(){
    //            Collection = "Saves",
    //            Key = "CharacterSelection",
    //            UserId = session.UserId
    //        },
    //    });

    //    Debug.LogFormat("Read objects: [{0}]", string.Join(",\n  ", result.Objects));
    //    int count = 0;
    //    foreach (var item in result.Objects)
    //    {
    //        count++;
    //    }
    //    if(count == 0) { Debug.Log("The objects are empty"); }

    //}

    public void UpdateDisplayName(string newDisplayName)
    {
        UpdateDN(newDisplayName);
    }

    async void UpdateDN(string newDN)
    {
        await client.UpdateAccountAsync(session, session.Username, newDN);
        MenuController.Instance.DisableLoadingPanel();
        MenuController.Instance.EnableCharacterSelectionPanel();
    }
}

[Serializable]
public class CharacterServerInfo
{
    public bool hasSelectedCharacter = false;
    public string selectedCharacterName = "";
}