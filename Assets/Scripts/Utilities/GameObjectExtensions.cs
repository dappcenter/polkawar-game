using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectExtensions : MonoBehaviour
{
    public GameObject targetGO;

    public void DisableGameObjectWithDelay(float delay)
    {
        StartCoroutine(DisableGameObjectWithDelayRoutine(delay));
    }

    IEnumerator DisableGameObjectWithDelayRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (targetGO) targetGO.SetActive(false);
        else gameObject.SetActive(false);
    }
}
