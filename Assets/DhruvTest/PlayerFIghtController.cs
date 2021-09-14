using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFIghtController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject AttackAnimeFireOnSwardMan;
    public GameObject AttackAnimeFireOnArcher;
    public GameObject DeffendAnimeFire;
    public GameObject AttackAnimeBeem;


    public GameObject Magician;
    public GameObject SwordMan;
    public GameObject Archer;
    public GameObject MagicianModle;
    public GameObject SwordManModle;
    public GameObject ArcherModle;

    Vector3 MagicianInitialPosition;
    Vector3 SwordManInitialPosition;
    Vector3 ArcherInitialPosition;
    public string MagicianStartMoveAnimation;
    
    public string MagicianAttackAnimation;
    public string MagicianReturnAnimation;
    public string MagicianDeffendAnimation;
    public string MagicianTakeDammageAnimation;
    public string MagicianDieAnimation;



    public float MagicianJumpOffset;
    public float SwordManJumpOffset;
    public float ArcherJumpOffset;

    public string SwordManStartMoveAnimation;
 
    public string SwordManAttackAnimation;
    public string SwordManReturnAnimation;


    public string SwordManDeffendAnimation;
    public string SwordManTakeDammageAnimation;
    public string SwordManDieAnimation;



    public string ArcherStartMoveAnimation;

    public string ArcherAttackAnimation;
    public string ArcherReturnAnimation;

    public string ArcherDeffendAnimation;
    public string ArcherTakeDammageAnimation;
    public string ArcherDieAnimation;
    void Start()
    {

        MagicianInitialPosition = Magician.transform.position;
        SwordManInitialPosition = SwordMan.transform.position;
        ArcherInitialPosition = Archer.transform.position;

    }

    public void AttackOne()
    {
        StartCoroutine(MeleeAttackToMagic());
    }

    public void AttackTwo()
    {
        StartCoroutine(MeleeAttackToArcher());
    }


    public IEnumerator MagicAttackToSwardMan()
    {
       
        //LeanTween.move(Magician, new Vector3(SwordMan.transform.position.x, SwordMan.transform.position.y, SwordMan.transform.position.z - MagicianJumpOffset), 0.50f).setDelay(0.65f);
        if (MagicianStartMoveAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianStartMoveAnimation);
        }

        yield return new WaitForSeconds(2f);
        //  PlayerOneModle.GetComponent<Animator>().Play(PlayereOneEndMoveAnimation);
        yield return new WaitForSeconds(0.2f);
        if (MagicianAttackAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianAttackAnimation);
        }
        yield return new WaitForSeconds(0.4f);
        //PlayerTwoModle.GetComponent<Animator>().Play(PlayerTwoRunAnimation);

        yield return new WaitForSeconds(0.5f);
        if (AttackAnimeFireOnSwardMan != null)
        {
            AttackAnimeFireOnSwardMan.SetActive(true);
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

        MagicianModle.GetComponent<Animator>().Play("Idle");

    }


    public IEnumerator MagicAttackToArcher()
    {

       // LeanTween.move(Magician, new Vector3(Archer.transform.position.x, Archer.transform.position.y, Archer.transform.position.z - ArcherJumpOffset), 0.50f).setDelay(0.65f);
        if (MagicianStartMoveAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianStartMoveAnimation);
        }

        yield return new WaitForSeconds(2f);
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

        //LeanTween.move(SwordMan, new Vector3(Magician.transform.position.x, Magician.transform.position.y, Magician.transform.position.z + SwordManJumpOffset), 0.3f).setDelay(0.2f);
        //if(SwordManStartMoveAnimation!= "")
        //{
        //    SwordManModle.GetComponent<Animator>().Play(SwordManStartMoveAnimation);
        //}

        //yield return new WaitForSeconds(2f);
        //  PlayerOneModle.GetComponent<Animator>().Play(PlayereOneEndMoveAnimation);

        if (MagicianReturnAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianReturnAnimation);
        }
        yield return new WaitForSeconds(0.5f);

        if (AttackAnimeBeem != null)
        {
            AttackAnimeBeem.SetActive(true);
        }
        yield return new WaitForSeconds(0.2f);

        if (SwordManDeffendAnimation != "")
        {
            SwordManModle.GetComponent<Animator>().Play(SwordManDeffendAnimation);
        }
        yield return new WaitForSeconds(1f);
        if (SwordManTakeDammageAnimation != "")
        {
            SwordManModle.GetComponent<Animator>().Play(SwordManTakeDammageAnimation);
        }
        

        if (MagicianTakeDammageAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianTakeDammageAnimation);
        }
        yield return new WaitForSeconds(1f);
        if (MagicianDeffendAnimation != "")
        {
            if (DeffendAnimeFire != null)
            {
                DeffendAnimeFire.SetActive(true);
            }
        }
        yield return new WaitForSeconds(1f);
        if (SwordManReturnAnimation != "")
        {
            SwordManModle.GetComponent<Animator>().Play(SwordManReturnAnimation);
        }
        
        //PlayerTwoModle.GetComponent<Animator>().Play(PlayerTwoRunAnimation);

        //  yield return new WaitForSeconds(0.5f);


        yield return new WaitForSeconds(0.5f);
        if (MagicianDeffendAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianDeffendAnimation);
        }
        yield return new WaitForSeconds(3f);
        if (MagicianAttackAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianAttackAnimation);
        }
        yield return new WaitForSeconds(1f);
        if (AttackAnimeFireOnSwardMan != null)
        {
            AttackAnimeFireOnSwardMan.SetActive(true);
        }

        yield return new WaitForSeconds(0.1f);
        if (SwordManAttackAnimation != "")
        {
            SwordManModle.GetComponent<Animator>().Play(SwordManAttackAnimation);
        }
        //if (MagicianTakeDammageAnimation != "")
        //{
        //    MagicianModle.GetComponent<Animator>().Play(MagicianTakeDammageAnimation);
        //}
        yield return new WaitForSeconds(1f);
        if (MagicianDieAnimation != "")
        {
            MagicianModle.GetComponent<Animator>().Play(MagicianDieAnimation);
        }
        yield return new WaitForSeconds(0.5f);

        yield return new WaitForSeconds(3f);
        if (DeffendAnimeFire != null)
        {
            DeffendAnimeFire.SetActive(false);
        }
        //if (SwordManReturnAnimation != "")
        //{
        //    SwordManModle.GetComponent<Animator>().Play(SwordManReturnAnimation);
        //}
       // LeanTween.move(SwordMan, SwordManInitialPosition, 0.3f).setDelay(0f);
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
