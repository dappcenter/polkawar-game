using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : SingletonMB<MenuController>
{
    public GameObject userNamePanel, mainMenuPanel, characterSelectionPanel, loadingPanel;

    public void EnableCharacterSelectionPanel()
    {

    }

    public void EnableMainmenuPanel()
    {
        mainMenuPanel.SetActive(true);
    }

    public void EnableLoadingPanel()
    {
        loadingPanel.SetActive(true);
    }
}
