using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatBehaviour : MonoBehaviour
{
    public int damage = 10;
    public Transform attackPoint;
    public GameObject SwordSlashParticle;
    public GameObject BloodParticle;

    public void SwordSlashVfx()
    {
        SwordSlashParticle.SetActive(true);
        SwordSlashParticle.GetComponent<ParticleSystem>().Play();
    }

    public void BloodVfx()
    {
        BloodParticle.SetActive(true);
        BloodParticle.GetComponent<ParticleSystem>().Play();
    }
}
