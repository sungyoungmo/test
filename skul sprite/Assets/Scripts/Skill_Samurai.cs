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

    // 스킬 2 실행
    public void ExecuteSkill2()
    {
        StartCoroutine(Skill2Coroutine());
    }

    IEnumerator Skill1Coroutine()
    {
        Debug.Log("스킬 1 실행");
        yield return new WaitForSeconds(2);
        isSkill1 = false;
    }

    IEnumerator Skill2Coroutine()
    {
        Debug.Log("스킬 2 실행");
        yield return new WaitForSeconds(1);
    }
}
