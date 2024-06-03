using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Samurai : MonoBehaviour
{
    private bool isSkill1 = false;

    public void ExecuteSkill1()
    {
        isSkill1 = true;
        StartCoroutine(Skill1Coroutine());
    }

    // ��ų 2 ����
    public void ExecuteSkill2()
    {
        StartCoroutine(Skill2Coroutine());
    }

    IEnumerator Skill1Coroutine()
    {
        Debug.Log("��ų 1 ����");
        yield return new WaitForSeconds(2);
        isSkill1 = false;
    }

    IEnumerator Skill2Coroutine()
    {
        Debug.Log("��ų 2 ����");
        yield return new WaitForSeconds(1);
    }
}
