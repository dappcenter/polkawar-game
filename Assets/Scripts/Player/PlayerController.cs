﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using Photon.Pun;
using System;

public class PlayerController : MonoBehaviourPun
{
    //Player ID
    private int playerID;

    [Header("Sub Behaviours")]
    public PlayerMovementBehaviour playerMovementBehaviour;
    public PlayerAnimationBehaviour playerAnimationBehaviour;
    //public PlayerVisualsBehaviour playerVisualsBehaviour;

    [Header("Input Settings")]
    public PlayerInput playerInput;
    public float movementSmoothingSpeed = 1f; // How fast Player movement is smoothen out
    public float maxForwardSpeed = 8f;        // How fast Player can run.
    public float gravity = 9.81f;               // How fast Player accelerates downwards when airborne.
    public float jumpSpeed = 10f;             // How fast Player takes off when jumping.
    public float minTurnSpeed = 400f;         // How fast Player turns when moving at maximum speed.
    public float maxTurnSpeed = 1200f;        // How fast Player turns when stationary.

    [SerializeField] private float attackSpeed = 1f;         //How fast Player can attack
    [SerializeField] private float attackCooldown = 0f;      //How much time it should wait to cool down and re-attack and avoid attack button spamming 

    public PlayerNameDisplayer playerNameDisplayer;
    public Health playerHealth;

    private Vector3 rawInputMovement;
    private Vector3 smoothInputMovement;

    [Header("Action Maps")]
    private string actionMapPlayerControls = "Player Controls";
    private string actionMapMenuControls = "Menu Controls";

    //Current Control Scheme
    private string currentControlScheme;

    //This is called from the GameManager; when the game is being setup.
    public void SetupPlayer(int newPlayerID)
    {
        playerID = newPlayerID;

        currentControlScheme = playerInput.currentControlScheme;

        //playerMovementBehaviour.SetupBehaviour();
        // playerAnimationBehaviour.SetupBehaviour();
        //  playerVisualsBehaviour.SetupBehaviour(playerID, playerInput);
    }

    public void SetPlayerName(string newName)
    {
        if (photonView.IsMine)
        {
            photonView.RPC("SetPlayerNameRPC", RpcTarget.AllBuffered, newName);
        }
    }

    [PunRPC]
    public void SetPlayerNameRPC(string newName)
    {
        playerNameDisplayer.SetName(newName);
    }

    public void TakeDamage(int damage)
    {
        photonView.RPC("TakeDamageRPC", RpcTarget.AllBuffered, damage);
    }

    [PunRPC]
    public void TakeDamageRPC(int damage)
    {
        playerHealth.TakeDamage(damage);
    }


    //INPUT SYSTEM ACTION METHODS --------------

    //This is called from PlayerInput; when a joystick or arrow keys has been pushed.
    //It stores the input Vector as a Vector3 to then be used by the smoothing function.


    public void OnMovement(InputAction.CallbackContext value)
    {
        if (!photonView.IsMine) return;

        Vector2 inputMovement = value.ReadValue<Vector2>();
        rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
    }

    //This is called from PlayerInput, when a button has been pushed, that corresponds with the 'Attack' action
    public void OnAttack(InputAction.CallbackContext value)
    {
        if (!photonView.IsMine) return;

        if (value.started)
        {
            if (attackCooldown <= 0)
            {
                AttackOnOpponent();
                playerAnimationBehaviour.PlayAttackAnimation();
                attackCooldown = 1f / attackSpeed;
            }
        }
    }

    private void AttackOnOpponent()
    {
        var raycastHit = Physics.SphereCastAll(transform.position, 1f, transform.forward, 1f);

        for (int i = 0; i < raycastHit.Length; i++)
        {
            if (raycastHit[i].collider.gameObject != gameObject)
            {
                PlayerController tempController = raycastHit[i].collider.gameObject.GetComponent<PlayerController>();

                if (tempController != null)
                {
                    Debug.Log(" Attacked the opponent");
                    tempController.TakeDamage(10);
                    break;
                }
            }
        }
    }

    //This is called from Player Input, when a button has been pushed, that correspons with the 'TogglePause' action
    public void OnTogglePause(InputAction.CallbackContext value)
    {
        if (!photonView.IsMine) return;

        if (value.started)
        {
            // GameManager.Instance.TogglePauseState(this);
        }
    }

    //INPUT SYSTEM AUTOMATIC CALLBACKS --------------
    #region Input Systenm Callbacks

    //This is automatically called from PlayerInput, when the input device has changed
    //(IE: Keyboard -> Xbox Controller)
    public void OnControlsChanged()
    {
        if (!photonView.IsMine) return;

        if (playerInput.currentControlScheme != currentControlScheme)
        {
            currentControlScheme = playerInput.currentControlScheme;

            // playerVisualsBehaviour.UpdatePlayerVisuals();
            RemoveAllBindingOverrides();
        }
    }

    //This is automatically called from PlayerInput, when the input device has been disconnected and can not be identified
    //IE: Device unplugged or has run out of batteries

    public void OnDeviceLost()
    {
        // playerVisualsBehaviour.SetDisconnectedDeviceVisuals();
    }

    public void OnDeviceRegained()
    {
        StartCoroutine(WaitForDeviceToBeRegained());
    }

    IEnumerator WaitForDeviceToBeRegained()
    {
        yield return new WaitForSeconds(0.1f);
        // playerVisualsBehaviour.UpdatePlayerVisuals();
    }

    #endregion
    void Update()
    {
        if (!photonView.IsMine) return;

        attackCooldown -= Time.deltaTime;

        if (!IsAnimationPlaying("Attack"))
        {
            CalculateMovementInputSmoothing();
            UpdatePlayerMovement();
        }
            UpdatePlayerAnimationMovement();
    }

    //Input's Axes values are raw
    void CalculateMovementInputSmoothing() => smoothInputMovement = Vector3.Lerp(smoothInputMovement, rawInputMovement, Time.deltaTime * movementSmoothingSpeed);

    void UpdatePlayerMovement()
    {
            

        playerMovementBehaviour.UpdateMovementData(smoothInputMovement);
    }

    bool IsAnimationPlaying()
    {
        return playerAnimationBehaviour.playerAnimator.GetCurrentAnimatorStateInfo(0).length >
            playerAnimationBehaviour.playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
    bool IsAnimationPlaying(string name)
    {
        return IsAnimationPlaying() && playerAnimationBehaviour.playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(name);
    }
    void UpdatePlayerAnimationMovement() => playerAnimationBehaviour.UpdateMovementAnimation(smoothInputMovement.magnitude);

    void CalculateVerticalMovement()
    { }

    public void SetInputActiveState(bool gameIsPaused)
    {
        if (!photonView.IsMine) return;

        switch (gameIsPaused)
        {
            case true:
                playerInput.DeactivateInput();
                break;

            case false:
                playerInput.ActivateInput();
                break;
        }
    }

    void RemoveAllBindingOverrides() => InputActionRebindingExtensions.RemoveAllBindingOverrides(playerInput.currentActionMap);

    //Switching Action Maps ----
    public void EnableGameplayControls() => playerInput.SwitchCurrentActionMap(actionMapPlayerControls);

    public void EnablePauseMenuControls() => playerInput.SwitchCurrentActionMap(actionMapMenuControls);


    //Get Data ----
    public int GetPlayerID() => playerID;

    public InputActionAsset GetActionAsset() => playerInput.actions;

    public PlayerInput GetPlayerInput() => playerInput;

}
