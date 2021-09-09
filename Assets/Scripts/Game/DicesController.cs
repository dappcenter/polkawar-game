using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicesController : SingletonMB<DicesController>
{
    [System.Serializable]
    public class PosRot
    {
        public Vector3 position;
        public Vector3 rotation;
    }

    public Transform fourDice, twentyDice;

    public SerializableDictionary<int, Vector3> twentySidedDice = new SerializableDictionary<int, Vector3>();

    public SerializableDictionary<int, List<PosRot>> tenSidedDice = new SerializableDictionary<int, List<PosRot>>();

    public void GiveItARoll(System.Action onComplete)
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

        List<PosRot> allPosRotFourDice = new List<PosRot>();

        foreach (var item in tenSidedDice)
        {
            allPosRotFourDice.AddRange(item.Value);
        }

        for (int i = 0; i < Random.Range(7, 12); i++)
        {
            int fourRand = Random.Range(0, allPosRotFourDice.Count);
            int twentyRand = Random.Range(0, twentySideRotations.Count);

            fourDice.position = allPosRotFourDice[fourRand].position;
            fourDice.rotation = Quaternion.Euler(allPosRotFourDice[fourRand].rotation);

            twentyDice.rotation = Quaternion.Euler(twentySideRotations[twentyRand]);

            yield return new WaitForSeconds(0.075f);
        }

        yield return null;

        onComplete?.Invoke();
    }
}
