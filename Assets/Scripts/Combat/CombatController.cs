using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class CombatController : MonoBehaviour
{
    public GameObject player, enemy;
    public GameObject[] playerAttackFx, enemyAttackFx;
    public Button playerAttackButton, enemyAttackButton;

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
        playerAnimator.Play("Attack");
        StartCoroutine(AttackOnEnemyRoutine(0.1f));
    }
    IEnumerator AttackOnEnemyRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (playerAttackFx[playerAttackIndex])
        {
            playerAttackFx[playerAttackIndex].SetActive(true);

            if (playerAttackIndex == 0)
                damageDelay = 4.25f;
            else
                damageDelay = 2f;

            EnemyTakeDamage();
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
            enemyAnimator.Play("TakeDamage");
            yield return new WaitForSeconds(2.5f);
            playerAttackFx[playerAttackIndex].SetActive(false);
            playerAttackIndex++;

            AttackOnPlayer();
        }

    }
    #endregion

    #region EnemyAttack
    public void AttackOnPlayer()
    {
        StartCoroutine(AttackOnPlayerRoutine(0.1f));
    }

    IEnumerator AttackOnPlayerRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (enemyAttackFx[enemyAttackIndex])
        {
            enemyAttackFx[enemyAttackIndex].SetActive(true);
            enemyAnimator.Play("Aim");

            yield return new WaitForSeconds(4f);
            enemyAnimator.Play("Attack");

            if (enemyAttackIndex == 0)
                damageDelay = 1.5f;
            else
                damageDelay = 2f;

            PlayerTakeDamage(damageDelay);
        }
    }

    public void PlayerTakeDamage(float damageDelay) => StartCoroutine(PlayerTakeDamageRoutine(damageDelay));

    IEnumerator PlayerTakeDamageRoutine(float damageDelay)
    {
        yield return new WaitForSeconds(damageDelay);
        playerAnimator.Play("TakeDamage");
        yield return new WaitForSeconds(1f);
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
