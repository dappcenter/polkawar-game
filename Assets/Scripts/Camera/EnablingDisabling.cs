using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablingDisabling : MonoBehaviour
{
    public List<GameObject> gos = new List<GameObject>();

    public int index = 0;

    [Sirenix.OdinInspector.Button]
    public void Next()
    {
        for (int i = 0; i < gos.Count; i++)
        {
            gos[i].SetActive(false);
        }

        gos[index % gos.Count].SetActive(true);
    }
}
