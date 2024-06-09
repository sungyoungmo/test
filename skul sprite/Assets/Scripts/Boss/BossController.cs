using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject Head;
    public GameObject Chin;
    public GameObject Body;
    public GameObject Left_Hand;
    public GameObject Right_Hand;

    Animator Head_animator;
    Animator Left_Hand_animator;
    Animator Right_Hand_animator;

    Boss_Hand bossHand;

    /*
        손의 애니메이션을 처리하기 위해 두 손을 관리하는 스크립트 작성하기
        boss hand는 지워야 할 듯

    */



    void Awake()
    {
        Head_animator = Head.GetComponent<Animator>();
        Left_Hand_animator = Left_Hand.GetComponent<Animator>();
        Right_Hand_animator = Right_Hand.GetComponent<Animator>();

        StartCoroutine(BossPattern());
    }


    IEnumerator BossPattern()
    {
        while (true)
        {
            yield return pattern();
            yield return new WaitForSeconds(5.0f);

        }
    }

    IEnumerator pattern()
    {
        int rValue = Random.Range(1, 4);

        switch (rValue)
        {
            case 1:
                yield return BossSlide();
                break;
            case 2:
                yield return BossStamp();
                break;
            case 3:
                yield return BossMagic();
                break;
            default:
                break;
        }
    }

    IEnumerator BossSlide()
    {
        GameObject useLHand = null;

        int radValue = Random.Range(0, 2);

        if (radValue == 0)
        {
            useLHand = Left_Hand;
        }
        else
        {
            useLHand = Right_Hand;
        }

        useLHand.GetComponent<Boss_Hand>().Hand_Slide();

        yield return new WaitForSeconds(10.0f);

        useLHand.GetComponent<Boss_Hand>().Hand_Slide();
    }
    IEnumerator BossStamp()
    {
        GameObject useLHand = null;

        int radValue = Random.Range(0, 2);

        if (radValue == 0)
        {
            useLHand = Left_Hand;
        }
        else
        {
            useLHand = Right_Hand;
        }

        useLHand.GetComponent<Boss_Hand>().Hand_Stamp();

        yield return new WaitForSeconds(10.0f);

        useLHand.GetComponent<Boss_Hand>().Hand_Stamp();

    }
    IEnumerator BossMagic()
    {
        GameObject useLHand = null;

        int radValue = Random.Range(0, 2);

        if (radValue == 0)
        {
            useLHand = Left_Hand;
        }
        else
        {
            useLHand = Right_Hand;
        }

        useLHand.GetComponent<Boss_Hand>().Hand_Magic();

        yield return new WaitForSeconds(15.0f);

        useLHand.GetComponent<Boss_Hand>().Hand_Magic();

    }

}
