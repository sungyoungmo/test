using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputKey : MonoBehaviour
{
    private PlayerDash playerDash;
    private PlayerAttack playerAttack;
    private PlayerMove playerMove;
    private PlayerJump playerJump;
    private PlayerSkullSwitch playerSkullSwitch;


    //private Skull_Samurai skulSamurai;

    public RuntimeAnimatorController[] animator;




    void Awake()
    {
        playerDash = PlayerDash.instance;
        playerAttack = PlayerAttack.instance;
        playerMove = PlayerMove.instance;
        playerJump = PlayerJump.instance;
        playerSkullSwitch = PlayerSkullSwitch.instance;

    }

    void Update()
    {
        #region 방향키

        playerMove.MoveOn();

        #endregion


        #region 공격 관련
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(playerAttack.CanAttackTime());
            StartCoroutine(playerAttack.Attack());
        }
        #endregion

        
        #region 점프
        if (Input.GetKeyDown(KeyCode.C))
        {
            playerJump.Jump();
        }
        #endregion


        #region 대쉬 관련

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (playerDash.CanDash())
            {
                StartCoroutine(playerDash.Dash());
                playerDash.UseDash();
            }
        }
        #endregion


        #region 스킬 관련
        if (Input.GetKeyDown(KeyCode.A))
        {
            //skillSamurai.ExecuteSkill1();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //skillSamurai.ExecuteSkill2();
        }

        #endregion


        #region 스컬 스위칭
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerSkullSwitch.Switch();
        }

        #endregion

    }
}