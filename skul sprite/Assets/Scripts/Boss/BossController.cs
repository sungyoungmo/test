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
        ���� �ִϸ��̼��� ó���ϱ� ���� �� ���� �����ϴ� ��ũ��Ʈ �ۼ��ϱ�
        boss hand�� ������ �� ��

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


        // �׳� ���� ������ �����̴� ��ǰ� �����̵� �ϴ� ��� �����ϱ�
        bossHand.Hand_Choose();
        yield return new WaitForSeconds(5.0f);

    }

}
