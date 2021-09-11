using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CombatVfxCollider : MonoBehaviour
{
    public UnityEvent OnCollisionComplete;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider)
        OnCollisionComplete.Invoke();
    }
}
