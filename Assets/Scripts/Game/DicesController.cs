using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicesController : MonoBehaviour
{
    [System.Serializable]
    public class PosRot
    {
        public Vector3 position;
        public Vector3 rotation;
    }

    public SerializableDictionary<int, Vector3> twentySidedDice = new SerializableDictionary<int, Vector3>();

    public SerializableDictionary<int, List<PosRot>> tenSidedDice = new SerializableDictionary<int, List<PosRot>>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
