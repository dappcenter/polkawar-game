using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using TMPro;

public class PlayerNameDisplayer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameText;

    public void SetName(string newName)
    {
        nameText.text = newName;
    }
}
