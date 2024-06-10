using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public static PlayerSkill instance;

    Animator animator;
    GameObject skullPrefab;
    SpriteRenderer spriteRenderer;


    RuntimeAnimatorController samuraiAnimatorController;
    RuntimeAnimatorController LittleBoneAnimatorController;
    RuntimeAnimatorController HeadLessAnimatorController;

    float LittleBone_Skill_One_CoolTime = 5.0f;
    public bool can_LittleBone_Skill_One = true;


    float LittleBone_Skill_Two_CoolTime = 3.0f;
    float LittleBone_Skill_Two_CoolTime_Max = 3.0f;

    float Samurai_Skill_One_CoolTime = 15.0f;
    float Samurai_Skill_One_CoolTime_Max = 15.0f;

    float Samurai_Skill_Two_CoolTime;
    float Samurai_Skill_Two_CoolTime_Max;


    readonly int stateSkillOne = Animator.StringToHash("stateSkillOne");
    readonly int stateIsDash = Animator.StringToHash("stateIsDash");


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        skullPrefab = Resources.Load<GameObject>("Prefab/Skul");
    }


    void Start()
    {

        samuraiAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimController/Samurai_Controller");
        LittleBoneAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimController/LittleBone_Controller");
        HeadLessAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimController/HeadLess_Controller");
    }


    public void Skill_One()
    {
        if (!animator.GetBool(stateIsDash))
        {
            if (animator.runtimeAnimatorController == samuraiAnimatorController)
            {
                Samurai_skill_one();
            }
            else if (animator.runtimeAnimatorController == LittleBoneAnimatorController)
            {
                LittleBone_skill_one();
            }
        }
    }

    public void Skill_Two()
    {
        if (animator.runtimeAnimatorController == samuraiAnimatorController)
        {
            Samurai_skill_Two();
        }
        else
        {
            LittleNoe_skill_Two();
        }
    }



    void LittleBone_skill_one()
    {
        if (can_LittleBone_Skill_One)
        {
            Debug.Log(10);
            animator.SetBool(stateSkillOne, true);
            StartCoroutine(LittleBone_Skill_One_Change());
        }
    }

    void Samurai_skill_one()
    {
        Debug.Log(2);
    }


    // skull의 위치 받아와서 그쪽으로 이동 얘는 이동만(쿨타임 초기화는 ThrowSkull에서 처리)
    void LittleNoe_skill_Two()
    {
        GameObject skullObject = GameObject.Find("Skul(Clone)");

        if (skullObject != null)
        {
            this.transform.position = skullObject.GetComponent<Transform>().position;
        }


    }

    void Samurai_skill_Two()
    {
        Debug.Log(2);
    }



    IEnumerator LittleBone_Skill_One_Change()
    {
        Debug.Log(1);

        can_LittleBone_Skill_One = false;

        GameObject skullInstance;

        

        yield return new WaitForSeconds(0.4f);

        if (spriteRenderer.flipX)
        {
            skullInstance = Instantiate(skullPrefab, this.transform.position + new Vector3(-1, 0.5f, 0), Quaternion.identity);
            Rigidbody2D rbSkull = skullInstance.GetComponent<Rigidbody2D>();

            skullInstance.GetComponent<SpriteRenderer>().flipX = false;


            skullInstance.GetComponent<Rigidbody2D>().velocity = Vector2.left * 10.0f;
        }
        else
        {
            skullInstance = Instantiate(skullPrefab, this.transform.position + new Vector3(1, 0.5f, 0), Quaternion.identity);

            skullInstance.GetComponent<SpriteRenderer>().flipX = true;

            skullInstance.GetComponent<Rigidbody2D>().velocity = Vector2.right * 10.0f;
        }

        animator.runtimeAnimatorController = HeadLessAnimatorController;

        yield return new WaitForSeconds(LittleBone_Skill_One_CoolTime);

        if (animator.runtimeAnimatorController == HeadLessAnimatorController)
        {
            animator.runtimeAnimatorController = LittleBoneAnimatorController;
        }

        if (skullInstance != null)
        {
            Destroy(skullInstance);
        }

        can_LittleBone_Skill_One = true;


    }
}
