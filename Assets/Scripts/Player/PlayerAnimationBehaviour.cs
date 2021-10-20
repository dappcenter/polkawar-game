using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerAnimationBehaviour : MonoBehaviourPun
{
    [Header("Component References")]
    public Animator playerAnimator;

    //Animation String IDs
    private int playerMovementAnimationID;
    private int playerAttackAnimationID;

    public void SetupBehaviour()
    {
        SetupAnimationIDs();
    }

    void SetupAnimationIDs()
    {
        playerMovementAnimationID = Animator.StringToHash("Movement");
        playerAttackAnimationID = Animator.StringToHash("Attack");
    }

    public void UpdateMovementAnimation(float movementBlendValue)
    {
        if (!photonView.IsMine) return;

        playerAnimator.SetFloat("Movement", movementBlendValue);
    }
    public void PlayAttackAnimation() => playerAnimator.SetTrigger("Attack");


}
