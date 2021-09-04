using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

// use web3.jslib
//using System.Runtime.InteropServices;

#if UNITY_WEBGL
public class GetWalletAddress : MonoBehaviour
{
    // text in the button
    public TextMeshProUGUI ButtonText;
    // use WalletAddress function from web3.jslib
    [DllImport("__Internal")] private static extern string WalletAddress();

    public void OnClick()
    {
        // get wallet address and display it on the button
        ButtonText.text = WalletAddress();
    }



    [DllImport("__Internal")]
    private static extern void Web3Connect();

    [DllImport("__Internal")]
    private static extern string ConnectAccount();

    [DllImport("__Internal")]
    private static extern void SetConnectAccount(string value);

    private int expirationTime;
    private string account;

    public void OnLogin()
    {
        Web3Connect();
        OnConnected();
    }

    async private void OnConnected()
    {
        account = ConnectAccount();
        while (account == "")
        {
            await new WaitForSeconds(1f);
            account = ConnectAccount();
        };
        SignLoginMessage(account);
    }

    async private void SignLoginMessage(string account)
    {
        try
        {
            // create expiration time
            DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            int currentTime = (int)(DateTime.UtcNow - epochStart).TotalSeconds;
            expirationTime = (currentTime + 30);
            // create message to sign
            string message = account + "-" + expirationTime.ToString();
            Debug.Log(message);
            string signature = await Web3GL.Sign(message);
            VerifySignature(signature);
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
    }

    private async void VerifySignature(string signature)
    {
        try
        {
            // get current time
            DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            int currentTime = (int)(DateTime.UtcNow - epochStart).TotalSeconds;

            // return if date expired
            if (currentTime > expirationTime) return;

            // get owner of signature
            string message = account + '-' + expirationTime.ToString();
            string owner = await EVM.Verify(message, signature);

            // return if not owner
            if (owner != account) return;

            // save account for next scene
            PlayerPrefs.SetString("Account", account);
            Debug.Log(account);
            // reset login message
            SetConnectAccount("");

            // load next scene
            SceneManager.LoadScene("Gameplay");
        }
        catch
        {
            print("invalid code");
        }
    }

    public void OnSkip()
    {
        // move to next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
#endif