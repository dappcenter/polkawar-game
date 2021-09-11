using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class DicesController : SingletonMB<DicesController>
{
    public Transform fourDice, twentyDice;

    public SerializableDictionary<int, Vector3> twentySidedDice = new SerializableDictionary<int, Vector3>();
    public SerializableDictionary<int, Vector3> fourSidedDice = new SerializableDictionary<int, Vector3>();


    [Button]
    public void GiveItARoll(System.Action onComplete = null)
    {
        StartCoroutine(RollTheDices(onComplete));
    }

    IEnumerator RollTheDices(System.Action onComplete)
    {
        yield return null;

        List<Vector3> twentySideRotations = new List<Vector3>();

        foreach (var item in twentySidedDice)
        {
            twentySideRotations.Add(item.Value);
        }

        List<Vector3> allPosRotFourDice = new List<Vector3>();

        foreach (var item in fourSidedDice)
        {
            allPosRotFourDice.Add(item.Value);
        }

        for (int i = 0; i < Random.Range(7, 12); i++)
        {
            int twentyRand = Random.Range(0, twentySideRotations.Count);
            int fourRand = Random.Range(0, allPosRotFourDice.Count);

            twentyDice.rotation = Quaternion.Euler(twentySideRotations[twentyRand]);
            fourDice.rotation = Quaternion.Euler(allPosRotFourDice[fourRand]);

            yield return new WaitForSeconds(0.075f);
        }

        yield return null;

        onComplete?.Invoke();
    }
}
