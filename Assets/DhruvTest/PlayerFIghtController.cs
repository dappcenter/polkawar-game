using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFIghtController : MonoBehaviour
{
    // Start is called before the first frame update

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

<<<<<<< Updated upstream
    public IEnumerator PlayerOneMeleeAttack()
    {
       
        LeanTween.move(PlayerOne, new Vector3(PlayerTwo.transform.position.x, PlayerTwo.transform.position.y, PlayerTwo.transform.position.z - PlayerOneJumpOffset), 0.50f).setDelay(0.65f);
        PlayerOneModle.GetComponent<Animator>().Play(PlayerOneStartMoveAnimation);
        yield return new WaitForSeconds(2f);
      //  PlayerOneModle.GetComponent<Animator>().Play(PlayereOneEndMoveAnimation);
        yield return new WaitForSeconds(0.2f);
        PlayerOneModle.GetComponent<Animator>().Play(PlayerOneAttackAnimation);
        yield return new WaitForSeconds(1.2f);
        PlayerTwoModle.GetComponent<Animator>().Play(PlayerTwoDeffendAnimation);
=======
    public void AttackTwo()
    {
        StartCoroutine(MagicAttackToSwardMan2());
    }
    public IEnumerator MagicAttackToSwardMan()
    {

        //LeanTween.move(Magician, new Vector3(SwordMan.transform.position.x, SwordMan.transform.position.y, SwordMan.transform.position.z - MagicianJumpOffset), 0.50f).setDelay(0.65f);
        if (MagicianStartMoveAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianStartMoveAnimation);
        }

        // yield return new WaitForSeconds(2f);
        //  PlayerOneModle.GetComponent<Animator>().Play(PlayereOneEndMoveAnimation);
        yield return new WaitForSeconds(0.2f);
        if (MagicianAttackAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianAttackAnimation);
        }
        yield return new WaitForSeconds(0.4f);
        //PlayerTwoModle.GetComponent<Animator>().Play(PlayerTwoRunAnimation);

        yield return new WaitForSeconds(1f);
        if (AttackAnimeFireOnSwardMan != null)
        {
            AttackAnimeFireOnSwardMan.SetActive(true);
        }

        yield return new WaitForSeconds(0.1f);
        if (SwordManDeffendAnimation != "")
        {
            SwordManModle.GetComponent<Animator>().Play(SwordManDeffendAnimation);
        }
        if (SwordManTakeDammageAnimation != "")
        {
            SwordManModle.GetComponent<Animator>().Play(SwordManTakeDammageAnimation);
        }
        if (SwordManDieAnimation != "")
        {
            SwordManModle.GetComponent<Animator>().Play(SwordManDieAnimation);
        }
        yield return new WaitForSeconds(1.2f);
        if (MagicianDeffendAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianDeffendAnimation);
        }
        if (MagicianTakeDammageAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianTakeDammageAnimation);
        }
        if (MagicianDieAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianDieAnimation);
        }
        yield return new WaitForSeconds(3f);
        if (AttackAnimeFireOnSwardMan != null)
        {
            AttackAnimeFireOnSwardMan.SetActive(false);
        }
        if (MagicianReturnAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianReturnAnimation);
        }
        LeanTween.move(Magician, MagicianInitialPosition, 0.50f).setDelay(0.65f);
        yield return new WaitForSeconds(2f);

        // MagicianModle.GetComponent<Animator>().Play("Idle");

    }

    public IEnumerator MagicAttackToSwardMan2()
    {

        //LeanTween.move(Magician, new Vector3(SwordMan.transform.position.x, SwordMan.transform.position.y, SwordMan.transform.position.z - MagicianJumpOffset), 0.50f).setDelay(0.65f);
        if (SwordManAttackAnimation != "")
        {
            SwordManModle.GetComponent<Animator>().Play(SwordManAttackAnimation);
        }

        // yield return new WaitForSeconds(2f);
        //  PlayerOneModle.GetComponent<Animator>().Play(PlayereOneEndMoveAnimation);
        yield return new WaitForSeconds(0.6f);
        if (MagicianAttackAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianAttackAnimation);
        }
        //yield return new WaitForSeconds(0.4f);
        //PlayerTwoModle.GetComponent<Animator>().Play(PlayerTwoRunAnimation);

        yield return new WaitForSeconds(0.5f);
        if (AttackAnimeFireOnSwardMan != null)
        {
            AttackAnimeFireOnSwardMan.SetActive(true);
        }

        yield return new WaitForSeconds(0.1f);
        if (SwordManDeffendAnimation != "")
        {
            SwordManModle.GetComponent<Animator>().Play(SwordManDeffendAnimation);
        }
        if (SwordManTakeDammageAnimation != "")
        {
            SwordManModle.GetComponent<Animator>().Play(SwordManTakeDammageAnimation);
        }
        if (SwordManDieAnimation != "")
        {
            SwordManModle.GetComponent<Animator>().Play(SwordManDieAnimation);
        }
        yield return new WaitForSeconds(1.2f);
        if (MagicianDeffendAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianDeffendAnimation);
        }
        if (MagicianTakeDammageAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianTakeDammageAnimation);
        }
        if (MagicianDieAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianDieAnimation);
        }
>>>>>>> Stashed changes
        yield return new WaitForSeconds(3f);
        PlayerOneModle.GetComponent<Animator>().Play(PlayerOneReturnAnimation);
        LeanTween.move(PlayerOne, PlayerOneInitialPosition, 0.50f).setDelay(0.65f);
        yield return new WaitForSeconds(2f);
<<<<<<< Updated upstream
        PlayerOneModle.GetComponent<Animator>().Play("Idle");
=======

       // MagicianModle.GetComponent<Animator>().Play("Idle");
>>>>>>> Stashed changes

    }

    public void PlayerTwomeleeAttack()
    {
<<<<<<< Updated upstream
        LeanTween.move(PlayerTwo, new Vector3(PlayerOne.transform.position.x, PlayerOne.transform.position.y, PlayerOne.transform.position.z + 0.98f), 1f).setDelay(0f);
=======

       // LeanTween.move(Magician, new Vector3(Archer.transform.position.x, Archer.transform.position.y, Archer.transform.position.z - ArcherJumpOffset), 0.50f).setDelay(0.65f);
        if (MagicianStartMoveAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianStartMoveAnimation);
        }

       // yield return new WaitForSeconds(2f);
        //  PlayerOneModle.GetComponent<Animator>().Play(PlayereOneEndMoveAnimation);
        yield return new WaitForSeconds(0.2f);
        if (MagicianAttackAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianAttackAnimation);
        }
        yield return new WaitForSeconds(0.4f);
        //PlayerTwoModle.GetComponent<Animator>().Play(PlayerTwoRunAnimation);

        yield return new WaitForSeconds(0.5f);
        if (AttackAnimeFireOnArcher != null)
        {
            AttackAnimeFireOnArcher.SetActive(true);
        }

        yield return new WaitForSeconds(0.3f);
        if (ArcherDeffendAnimation != "")
        {
            ArcherModle.GetComponent<Animator>().Play(ArcherDeffendAnimation);
        }
        if (ArcherTakeDammageAnimation != "")
        {
            ArcherModle.GetComponent<Animator>().Play(ArcherTakeDammageAnimation);
        }
        if (ArcherDieAnimation != "")
        {
            ArcherModle.GetComponent<Animator>().Play(ArcherDieAnimation);
        }
        yield return new WaitForSeconds(1.5f);

        yield return new WaitForSeconds(3f);
        if (AttackAnimeFireOnArcher != null)
        {
            AttackAnimeFireOnArcher.SetActive(false);
        }
        if (MagicianReturnAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianReturnAnimation);
        }
        LeanTween.move(Magician, MagicianInitialPosition, 0.50f).setDelay(0.65f);
        yield return new WaitForSeconds(2f);

        MagicianModle.GetComponent<Animator>().Play("Idle");

    }


    public IEnumerator ArcherAttackToSwardMan()
    {

        //LeanTween.move(Archer, new Vector3(SwordMan.transform.position.x, SwordMan.transform.position.y, SwordMan.transform.position.z - ArcherJumpOffset), 0.50f).setDelay(0.65f);
        if (ArcherStartMoveAnimation != "")
        {
            ArcherModle.GetComponent<Animator>().Play(ArcherStartMoveAnimation);
        }

        yield return new WaitForSeconds(0f);
        //  PlayerOneModle.GetComponent<Animator>().Play(PlayereOneEndMoveAnimation);
        yield return new WaitForSeconds(0.2f);
        if (ArcherAttackAnimation != "")
        {
            ArcherModle.GetComponent<Animator>().Play(ArcherAttackAnimation);
        }
        yield return new WaitForSeconds(0.4f);
        //PlayerTwoModle.GetComponent<Animator>().Play(PlayerTwoRunAnimation);

        yield return new WaitForSeconds(0.5f);
        if (AttackAnimeBeem != null)
        {
            AttackAnimeBeem.SetActive(true);
        }

        yield return new WaitForSeconds(0.3f);
        if (SwordManDeffendAnimation != "")
        {
            SwordManModle.GetComponent<Animator>().Play(SwordManDeffendAnimation);
        }
        if (SwordManTakeDammageAnimation != "")
        {
            SwordManModle.GetComponent<Animator>().Play(SwordManTakeDammageAnimation);
        }
        if (SwordManDieAnimation != "")
        {
            SwordManModle.GetComponent<Animator>().Play(SwordManDieAnimation);
        }
        yield return new WaitForSeconds(1.5f);

        yield return new WaitForSeconds(3f);
        if (AttackAnimeBeem != null)
        {
            AttackAnimeBeem.SetActive(false);
        }
        if (ArcherReturnAnimation != "")
        {
            ArcherModle.GetComponent<Animator>().Play(ArcherReturnAnimation);
        }
        LeanTween.move(Archer, ArcherInitialPosition, 0.50f).setDelay(0.65f);
        yield return new WaitForSeconds(2f);

        ArcherModle.GetComponent<Animator>().Play("Idle");

    }

    public IEnumerator ArcherAttackToMagician()
    {

       // LeanTween.move(Archer, new Vector3(SwordMan.transform.position.x, SwordMan.transform.position.y, SwordMan.transform.position.z - ArcherJumpOffset), 0.50f).setDelay(0.65f);
        if (ArcherStartMoveAnimation != "")
        {
            ArcherModle.GetComponent<Animator>().Play(ArcherStartMoveAnimation);
        }

        yield return new WaitForSeconds(0f);
        //  PlayerOneModle.GetComponent<Animator>().Play(PlayereOneEndMoveAnimation);
        yield return new WaitForSeconds(0.2f);
        if (ArcherAttackAnimation != "")
        {
            ArcherModle.GetComponent<Animator>().Play(ArcherAttackAnimation);
        }
        yield return new WaitForSeconds(0.4f);
        //PlayerTwoModle.GetComponent<Animator>().Play(PlayerTwoRunAnimation);

        yield return new WaitForSeconds(0.5f);
        if (AttackAnimeBeem != null)
        {
            AttackAnimeBeem.SetActive(true);
        }

        yield return new WaitForSeconds(0.3f);
        if (MagicianDeffendAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianDeffendAnimation);
        }
        if (MagicianTakeDammageAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianTakeDammageAnimation);
        }
        if (MagicianDieAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianDieAnimation);
        }
        yield return new WaitForSeconds(1.5f);

        yield return new WaitForSeconds(3f);
        if (AttackAnimeBeem != null)
        {
            AttackAnimeBeem.SetActive(false);
        }
        if (ArcherReturnAnimation != "")
        {
            ArcherModle.GetComponent<Animator>().Play(ArcherReturnAnimation);
        }
        LeanTween.move(Archer, ArcherInitialPosition, 0.50f).setDelay(0.65f);
        yield return new WaitForSeconds(2f);

        ArcherModle.GetComponent<Animator>().Play("Idle");

    }




    public IEnumerator MeleeAttackToMagic()
    {
        
       // LeanTween.move(SwordMan, new Vector3(Magician.transform.position.x, Magician.transform.position.y, Magician.transform.position.z + SwordManJumpOffset), 0.3f).setDelay(0.2f);
        if(SwordManStartMoveAnimation!= "")
        {
            SwordManModle.GetComponent<Animator>().Play(SwordManStartMoveAnimation);
        }
        
        //yield return new WaitForSeconds(2f);
        //  PlayerOneModle.GetComponent<Animator>().Play(PlayereOneEndMoveAnimation);
     //   yield return new WaitForSeconds(0.5f);
        if (SwordManAttackAnimation != "")
        {
            SwordManModle.GetComponent<Animator>().Play(SwordManAttackAnimation);
        }
        yield return new WaitForSeconds(0.4f);
        //PlayerTwoModle.GetComponent<Animator>().Play(PlayerTwoRunAnimation);

        //  yield return new WaitForSeconds(0.5f);

        
        yield return new WaitForSeconds(0.3f);

        if (MagicianDeffendAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianDeffendAnimation);
        }
        if (MagicianTakeDammageAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianTakeDammageAnimation);
        }
        if (MagicianDieAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianDieAnimation);
        }
        yield return new WaitForSeconds(0.6f);
        if (MagicianDeffendAnimation != "")
        {
            if (DeffendAnimeFire != null)
            {
                DeffendAnimeFire.SetActive(true);
            }
        }
        yield return new WaitForSeconds(3f);
        if (DeffendAnimeFire != null)
        {
            DeffendAnimeFire.SetActive(false);
        }
        if (SwordManReturnAnimation != "")
        {
            SwordManModle.GetComponent<Animator>().Play(SwordManReturnAnimation);
        }
        LeanTween.move(SwordMan, SwordManInitialPosition, 0.3f).setDelay(0f);
        yield return new WaitForSeconds(0.5f);
        SwordManModle.GetComponent<Animator>().Play("Idle");
    }


    public IEnumerator MeleeAttackToArcher()
    {

        LeanTween.move(SwordMan, new Vector3(Archer.transform.position.x, Archer.transform.position.y, Archer.transform.position.z + SwordManJumpOffset), 0.3f).setDelay(0.2f);
        if (SwordManStartMoveAnimation != "")
        {
            SwordManModle.GetComponent<Animator>().Play(SwordManStartMoveAnimation);
        }

        //yield return new WaitForSeconds(2f);
        //  PlayerOneModle.GetComponent<Animator>().Play(PlayereOneEndMoveAnimation);
        yield return new WaitForSeconds(0.5f);
        if (SwordManAttackAnimation != "")
        {
            SwordManModle.GetComponent<Animator>().Play(SwordManAttackAnimation);
        }
        yield return new WaitForSeconds(0.4f);
        //PlayerTwoModle.GetComponent<Animator>().Play(PlayerTwoRunAnimation);

        //  yield return new WaitForSeconds(0.5f);
        //if (MagicianDeffendAnimation != "")
        //{
        //    if (DeffendAnimeFire != null)
        //    {
        //        DeffendAnimeFire.SetActive(true);
        //    }
        //}

        yield return new WaitForSeconds(0.3f);
        if (ArcherDeffendAnimation != "")
        {
            ArcherModle.GetComponent<Animator>().Play(ArcherDeffendAnimation);
        }
        if (ArcherTakeDammageAnimation != "")
        {
            ArcherModle.GetComponent<Animator>().Play(ArcherTakeDammageAnimation);
        }
        if (ArcherDieAnimation != "")
        {
            ArcherModle.GetComponent<Animator>().Play(ArcherDieAnimation);
        }
        yield return new WaitForSeconds(1.5f);

       
        //if (DeffendAnimeFire != null)
        //{
        //    DeffendAnimeFire.SetActive(false);
        //}
        if (SwordManReturnAnimation != "")
        {
            SwordManModle.GetComponent<Animator>().Play(SwordManReturnAnimation);
        }
        LeanTween.move(SwordMan, SwordManInitialPosition, 0.3f).setDelay(0f);
        yield return new WaitForSeconds(0.5f);
        SwordManModle.GetComponent<Animator>().Play("Idle");
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
