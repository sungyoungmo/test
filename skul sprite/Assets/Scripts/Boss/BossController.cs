using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
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
        //Head_animator = Head.GetComponent<Animator>();
        Left_Hand_animator = Left_Hand.GetComponent<Animator>();
        Right_Hand_animator = Right_Hand.GetComponent<Animator>();

    }


    void Start()
    {
        bossHand = Boss_Hand.instance;
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
        int rValue = Random.Range(1, 2);

        switch (rValue)
        {
            case 1:
                yield return BossSlide();
                break;
            case 2:
                //yield return BossStamp();
                break;
            case 3:
                //yield return BossMagic();
                break;
            default:
                break;
        }
    }

    IEnumerator BossSlide()
    {


        // 그냥 양쪽 끝으로 움직이는 모션과 슬라이드 하는 모션 구현하기
        bossHand.Hand_Choose();
        yield return new WaitForSeconds(5.0f);

    }

}
