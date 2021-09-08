using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFIghtController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject AttackAnimeFire;
    public GameObject DeffendAnimeFire;
    public GameObject AttackAnimeBeem;


    public GameObject PlayerOne;
    public GameObject PlayerTwo;

    public GameObject PlayerOneModle;
    public GameObject PlayerTwoModle;

    Vector3 PlayerOneInitialPosition;
    Vector3 PlayerTwoInitialPosition;
    public string PlayerOneStartMoveAnimation;
    
    public string PlayerOneAttackAnimation;
    public string PlayerOneReturnAnimation;
   
    public string PlayerTwoDeffendAnimation;
    public string PlayerTwoTakeDammageAnimation;
    public string PlayerTwoDieAnimation;


    public float PlayerOneJumpOffset;
    public float PlayerTwoJumpOffset;


    public string PlayerTwoStartMoveAnimation;
 
    public string PlayerTwoAttackAnimation;
    public string PlayerTwoReturnAnimation;
  
    public string PlayerOneDeffendAnimation;
    public string PlayerOneTakeDammageAnimation;
    public string PlayerOneDieAnimation;
    void Start()
    {

        PlayerOneInitialPosition = PlayerOne.transform.position;
        PlayerTwoInitialPosition = PlayerTwo.transform.position;
    
   
    }

    public void AttackOne()
    {
        StartCoroutine(PlayerMagicAttack());
    }

    public void AttackTwo()
    {
        StartCoroutine(PlayerMeleeAttack());
    }


    public IEnumerator PlayerMagicAttack()
    {
       
        LeanTween.move(PlayerOne, new Vector3(PlayerTwo.transform.position.x, PlayerTwo.transform.position.y, PlayerTwo.transform.position.z - PlayerOneJumpOffset), 0.50f).setDelay(0.65f);
        if (PlayerOneStartMoveAnimation != "")
        {
            PlayerOneModle.GetComponent<Animator>().Play(PlayerOneStartMoveAnimation);
        }

        yield return new WaitForSeconds(2f);
        //  PlayerOneModle.GetComponent<Animator>().Play(PlayereOneEndMoveAnimation);
        yield return new WaitForSeconds(0.2f);
        if (PlayerOneAttackAnimation != "")
        {
            PlayerOneModle.GetComponent<Animator>().Play(PlayerOneAttackAnimation);
        }
        yield return new WaitForSeconds(0.4f);
        //PlayerTwoModle.GetComponent<Animator>().Play(PlayerTwoRunAnimation);

        yield return new WaitForSeconds(0.5f);
        if (AttackAnimeFire != null)
        {
            AttackAnimeFire.SetActive(true);
        }

        yield return new WaitForSeconds(0.3f);
        if (PlayerTwoDeffendAnimation != "")
        {
            PlayerTwoModle.GetComponent<Animator>().Play(PlayerTwoDeffendAnimation);
        }
        if (PlayerTwoTakeDammageAnimation != "")
        {
            PlayerTwoModle.GetComponent<Animator>().Play(PlayerTwoTakeDammageAnimation);
        }
        if (PlayerTwoDieAnimation != "")
        {
            PlayerTwoModle.GetComponent<Animator>().Play(PlayerTwoDieAnimation);
        }
        yield return new WaitForSeconds(1.5f);

        yield return new WaitForSeconds(3f);
        if (AttackAnimeFire != null)
        {
            AttackAnimeFire.SetActive(false);
        }
        if (PlayerOneReturnAnimation != "")
        {
            PlayerOneModle.GetComponent<Animator>().Play(PlayerOneReturnAnimation);
        }
        LeanTween.move(PlayerOne, PlayerOneInitialPosition, 0.50f).setDelay(0.65f);
        yield return new WaitForSeconds(2f);

        PlayerOneModle.GetComponent<Animator>().Play("Idle");

    }




    public IEnumerator PlayerMeleeAttack()
    {
        
        LeanTween.move(PlayerTwo, new Vector3(PlayerOne.transform.position.x, PlayerOne.transform.position.y, PlayerOne.transform.position.z + PlayerTwoJumpOffset), 0.3f).setDelay(0.2f);
        if(PlayerTwoStartMoveAnimation!= "")
        {
            PlayerTwoModle.GetComponent<Animator>().Play(PlayerTwoStartMoveAnimation);
        }
        
        //yield return new WaitForSeconds(2f);
        //  PlayerOneModle.GetComponent<Animator>().Play(PlayereOneEndMoveAnimation);
        yield return new WaitForSeconds(0.5f);
        if (PlayerTwoAttackAnimation != "")
        {
            PlayerTwoModle.GetComponent<Animator>().Play(PlayerTwoAttackAnimation);
        }
        yield return new WaitForSeconds(0.4f);
        //PlayerTwoModle.GetComponent<Animator>().Play(PlayerTwoRunAnimation);

        //  yield return new WaitForSeconds(0.5f);
        if (PlayerOneDeffendAnimation != "")
        {
            if (DeffendAnimeFire != null)
            {
                DeffendAnimeFire.SetActive(true);
            }
        }
        
        yield return new WaitForSeconds(0.3f);
        if (PlayerOneDeffendAnimation != "")
        {
            PlayerOneModle.GetComponent<Animator>().Play(PlayerOneDeffendAnimation);
        }
        if (PlayerTwoTakeDammageAnimation != "")
        {
            PlayerTwoModle.GetComponent<Animator>().Play(PlayerTwoTakeDammageAnimation);
        }
        if (PlayerTwoDieAnimation != "")
        {
            PlayerTwoModle.GetComponent<Animator>().Play(PlayerTwoDieAnimation);
        }
        yield return new WaitForSeconds(1.5f);

        yield return new WaitForSeconds(3f);
        if (DeffendAnimeFire != null)
        {
            DeffendAnimeFire.SetActive(false);
        }
        if (PlayerTwoReturnAnimation != "")
        {
            PlayerTwoModle.GetComponent<Animator>().Play(PlayerTwoReturnAnimation);
        }
        LeanTween.move(PlayerTwo, PlayerTwoInitialPosition, 0.3f).setDelay(0f);
        yield return new WaitForSeconds(0.5f);
        PlayerOneModle.GetComponent<Animator>().Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
