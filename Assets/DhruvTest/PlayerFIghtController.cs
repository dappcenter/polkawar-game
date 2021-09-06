using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFIghtController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject AttackAnime;
  

    public GameObject PlayerOne;
    public GameObject PlayerTwo;

    public GameObject PlayerOneModle;
    public GameObject PlayerTwoModle;

    Vector3 PlayerOneInitialPosition;
    Vector3 PlayerTwoInitialPosition;
    public string PlayerOneStartMoveAnimation;
    public string PlayereOneEndMoveAnimation;
    public string PlayerOneAttackAnimation;
    public string PlayerOneReturnAnimation;
    public string PlayerTwoRunAnimation;
    public string PlayerTwoDeffendAnimation;


    public float PlayerOneJumpOffset;
    void Start()
    {

        PlayerOneInitialPosition = PlayerOne.transform.position;
        PlayerTwoInitialPosition = PlayerTwo.transform.position;
    
   
    }

    public void AttackOne()
    {
        StartCoroutine(PlayerOneMeleeAttack());
    }

    public IEnumerator PlayerOneMeleeAttack()
    {
       
        LeanTween.move(PlayerOne, new Vector3(PlayerTwo.transform.position.x, PlayerTwo.transform.position.y, PlayerTwo.transform.position.z - PlayerOneJumpOffset), 0.50f).setDelay(0.65f);
        PlayerOneModle.GetComponent<Animator>().Play(PlayerOneStartMoveAnimation);
        yield return new WaitForSeconds(2f);
      //  PlayerOneModle.GetComponent<Animator>().Play(PlayereOneEndMoveAnimation);
        yield return new WaitForSeconds(0.2f);
        PlayerOneModle.GetComponent<Animator>().Play(PlayerOneAttackAnimation);
        
        yield return new WaitForSeconds(0.4f);
        //PlayerTwoModle.GetComponent<Animator>().Play(PlayerTwoRunAnimation);
        
        yield return new WaitForSeconds(0.5f);
        AttackAnime.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        PlayerTwoModle.GetComponent<Animator>().Play(PlayerTwoDeffendAnimation);
        yield return new WaitForSeconds(1.5f);
        
        yield return new WaitForSeconds(3f);
        AttackAnime.SetActive(false);
        PlayerOneModle.GetComponent<Animator>().Play(PlayerOneReturnAnimation);
        LeanTween.move(PlayerOne, PlayerOneInitialPosition, 0.50f).setDelay(0.65f);
        yield return new WaitForSeconds(2f);
        PlayerOneModle.GetComponent<Animator>().Play("Idle");

    }

    public void PlayerTwomeleeAttack()
    {
        LeanTween.move(PlayerTwo, new Vector3(PlayerOne.transform.position.x, PlayerOne.transform.position.y, PlayerOne.transform.position.z + 0.98f), 1f).setDelay(0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
