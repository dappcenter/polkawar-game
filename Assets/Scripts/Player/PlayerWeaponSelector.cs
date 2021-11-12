using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGCharacterAnims;
using System;

[RequireComponent(typeof(RPGCharacterWeaponController))]
public class PlayerWeaponSelector : MonoBehaviour
{
    [SerializeField] private RPGCharacterWeaponController characterWeaponController;

    public Weapon selectedWeapon;

    private void Start()
    {
        if (characterWeaponController == null)
            characterWeaponController = GetComponent<RPGCharacterWeaponController>();
        else
            StartCoroutine(AssignWeaponToPlayer());
    }

    public IEnumerator AssignWeaponToPlayer()
    {
        Debug.Log(" Before assigning weapon");
        yield return new WaitForSeconds(0.5f);
        characterWeaponController.StartCoroutine(characterWeaponController._SwitchWeapon((int)selectedWeapon));
        Debug.Log(" After assigning weapon");
    }
}
