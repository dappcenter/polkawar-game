using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : SingletonMB<MenuController>
{
    public GameObject userNamePanel, mainMenuPanel, characterSelectionPanel, loadingPanel, lobbyPanel;

    public void EnableCharacterSelectionPanel()
    {
        characterSelectionPanel.SetActive(true);
    }

    public void DisableCharacterSelectionPanel()
    {
        characterSelectionPanel.SetActive(false);
    }

    public void EnableMainmenuPanel()
    {
        mainMenuPanel.SetActive(true);
    }

    public void EnableLoadingPanel()
    {
        loadingPanel.SetActive(true);
    }

    public void DisableLoadingPanel()
    {
        loadingPanel.SetActive(false);
    }

    public void EnableLobbyPanel()
    {
        lobbyPanel.SetActive(true);
    }
}
