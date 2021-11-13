using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

// use web3.jslib
//using System.Runtime.InteropServices;

#if UNITY_WEBGL
public class GetWalletAddress : MonoBehaviour
{
    // text in the button
    public TextMeshProUGUI ButtonText;
    // use WalletAddress function from web3.jslib
    [DllImport("__Internal")] private static extern string WalletAddress();

    IEnumerator Start()
    {
        while (string.IsNullOrEmpty(WalletAddress()))
        {
            yield return new WaitForSeconds(2f);
        }

        PlayerPrefs.SetString("Account", WalletAddress());
    }
    

    public void OnClick()
    {
        // get wallet address and display it on the button
        ButtonText.text = WalletAddress();
    }

}
#endif