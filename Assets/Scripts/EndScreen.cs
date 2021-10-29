using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject WinTab;
    public GameObject LoseTab;


    
    public void OnPlayerWin()
    {

        WinTab.SetActive(true);
        LoseTab.SetActive(false);
    }

    public void OnPlayerLose()
    {
        LoseTab.SetActive(true);
        WinTab.SetActive(false);
    }
}
