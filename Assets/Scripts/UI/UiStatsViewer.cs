using UnityEngine;
using TMPro;

public class UiStatsViewer : MonoBehaviour
{
    public GameObject[] players;
    [SerializeField] private TMP_Text playerNameText;

    private void OnEnable()
    {
        if (playerNameText == null)
            GetComponentInChildren<TMP_Text>();

        playerNameText.text = "PLAYER";

        if (!PlayerData.Instance)
            return;

        playerNameText.text = PlayerData.Instance.name;

        foreach (var player in players)
        {
            player.SetActive(false);
        }
        if (PlayerData.Instance.name == "Warrior")
        {
            players[0].SetActive(true);
        }
        else if (PlayerData.Instance.name == "Archer")
        {
            players[1].SetActive(true);
        }
        else if (PlayerData.Instance.name == "Magician")
        {
            players[2].SetActive(true);
        }
    }
}
