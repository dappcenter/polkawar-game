using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class CombatController : MonoBehaviour
{
    public GameObject player, enemy;
    public GameObject[] playerAttackFx, enemyAttackFx;
    public Button playerAttackButton, enemyAttackButton;

    public Transform frontPos, initialPos;
    private Animator playerAnimator, enemyAnimator;
    private int playerAttackIndex, enemyAttackIndex;

    float damageDelay = 0f;

    private void Start()
    {
        playerAnimator = player.GetComponentInChildren<Animator>();
        enemyAnimator = enemy.GetComponentInChildren<Animator>();

        AttackOnEnemy();
    }

    #region Player Attack
    public void AttackOnEnemy()
    {
        if (playerAttackIndex == 0)
            playerAnimator.Play("Jump");
        else
            playerAnimator.Play("Jump1");

        StartCoroutine(AttackOnEnemyRoutine());
    }
    IEnumerator AttackOnEnemyRoutine()
    {

        //jump /move to attack position
        LeanTween.move(player, frontPos, 1f);
        if (playerAttackIndex == 0)
        {
            yield return new WaitForSeconds(1f);
            playerAnimator.Play("Attack");
            if (playerAttackFx[playerAttackIndex])
            {
                playerAttackFx[playerAttackIndex].SetActive(true);
                //    //yield return new WaitForSeconds(2f);
                //playerAnimator.Play("Attack");
                //if (playerAttackIndex == 0)
                //    damageDelay = 2f;
                //else
                damageDelay = 1f;

                EnemyTakeDamage();
            }

        }
        else
        {
            yield return new WaitForSeconds(1f);
            playerAnimator.Play("Attack1");
            yield return new WaitForSeconds(0.5f);

        if (playerAttackFx[playerAttackIndex])
        {
            playerAttackFx[playerAttackIndex].SetActive(true);
            //    //yield return new WaitForSeconds(2f);
            //playerAnimator.Play("Attack");
            //if (playerAttackIndex == 0)
            //    damageDelay = 2f;
            //else
            damageDelay = 1f;

            EnemyTakeDamage();
        }
        }
    }

    public void EnemyTakeDamage() => StartCoroutine(EnemyTakeDamageRoutine(damageDelay));
    IEnumerator EnemyTakeDamageRoutine(float damageDelay)
    {
        yield return new WaitForSeconds(damageDelay);
        if (playerAttackIndex == 1)
        {
            enemyAnimator.Play("Death");

            yield return new WaitForSeconds(3.5f);
            playerAttackFx[playerAttackIndex].SetActive(false);
            DisbleTurn();
        }
        else
        {
            enemyAnimator.SetTrigger("TakeDamage");

            yield return new WaitForSeconds(1f);
            playerAnimator.Play("JumpBack");

            //move back to initial position
            LeanTween.move(player, initialPos, 0.75f);
            // yield return new WaitForSeconds(1f);
            playerAnimator.Play("Idle");
            //playerAttackFx[playerAttackIndex].SetActive(false);
            playerAttackIndex++;

            AttackOnPlayer();
        }
    }
    #endregion

    #region EnemyAttack
    public void AttackOnPlayer() => StartCoroutine(AttackOnPlayerRoutine(2f));

    IEnumerator AttackOnPlayerRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (enemyAttackFx[enemyAttackIndex])
        {
            //enemyAnimator.Play("Aim");

            yield return new WaitForSeconds(1f);
            //enemy.transform.Rotate(0, enemy.transform.rotation.y - 90, 0);
            // LeanTween.rotateLocal(enemy, new Vector3(0, 0, 0), 0f).setDelay(0.1f);
            LeanTween.rotateLocal(enemy, new Vector3(0, 270f, 0), 0f);//.setDelay(0.5f);

            enemyAnimator.Play("Attack");
            yield return new WaitForSeconds(2f);
            enemyAttackFx[enemyAttackIndex].SetActive(true);
            //if (enemyAttackIndex == 0)
            damageDelay = 3f;
            //else
            //    damageDelay = 2f;

            PlayerTakeDamage(damageDelay);
        }
        else
        {
            damageDelay = 3f;
            PlayerTakeDamage(damageDelay);
        }
    }

    public void PlayerTakeDamage(float damageDelay) => StartCoroutine(PlayerTakeDamageRoutine(damageDelay));

    IEnumerator PlayerTakeDamageRoutine(float damageDelay)
    {
        yield return new WaitForSeconds(0.25f);
        playerAnimator.SetTrigger("TakeDamage");
        // LeanTween.rotateLocal(enemy, new Vector3(0, 0, 0), 0.01f);
        yield return new WaitForSeconds(damageDelay);
        Debug.Log("transform.rotation.y before " + enemy.transform.rotation.eulerAngles.y);
        LeanTween.rotateLocal(enemy, new Vector3(0, 180f, 0), 0.1f);
        Debug.Log("transform.rotation.y after " + enemy.transform.rotation.eulerAngles.y);
        yield return new WaitForSeconds(3f);
        enemyAttackFx[enemyAttackIndex].SetActive(false);
        enemyAttackIndex++;

        AttackOnEnemy();
    }
    public void EnemyTurn()
    {
        playerAttackButton.interactable = false;
        enemyAttackButton.interactable = true;
    }
    #endregion

    public void PlayerTurn()
    {
        playerAttackButton.interactable = true;
        enemyAttackButton.interactable = false;
    }

    public void DisbleTurn()
    {
        playerAttackButton.interactable = false;
        enemyAttackButton.interactable = false;
    }
}
