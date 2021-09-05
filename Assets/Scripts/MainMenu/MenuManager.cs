using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public NakamaConnection nakamaConnection;
    public InputField NameField;
    public Dropdown PlayersDropdown;

    private IDictionary<string, GameObject> players = new Dictionary<string, GameObject>();

    async void Start()
    {
        // Connect to the Nakama server.
        await nakamaConnection.Connect();
    }

    public async void FindMatch()
    {
        await nakamaConnection.FindMatch();
    }
}
