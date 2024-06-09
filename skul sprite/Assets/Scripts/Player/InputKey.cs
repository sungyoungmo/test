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
    private PlayerSkill playerSkill;
    private PlayerPortalUse playerPortalUse;

    void Start()
    {

        playerDash = PlayerDash.instance;

        playerAttack = PlayerAttack.instance;

        playerMove = PlayerMove.instance;

        playerJump = PlayerJump.instance;

        playerSkullSwitch = PlayerSkullSwitch.instance;

        playerSkill = PlayerSkill.instance;

        playerPortalUse = PlayerPortalUse.instance;


        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        #region ����Ű

        playerMove.MoveOn();

        #endregion


        #region ���� ����

        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(playerAttack.CanAttackTime());
            StartCoroutine(playerAttack.Attack());
        }
        #endregion


        #region ����
        if (Input.GetKeyDown(KeyCode.C))
        {
            playerJump.Jump();
        }
        #endregion


        #region �뽬 ����

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (playerDash.CanDash())
            {
                StartCoroutine(playerDash.Dash());
                playerDash.UseDash();
            }
        }
        #endregion


        #region ��ų ����
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerSkill.Skill_One();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerSkill.Skill_Two();
        }

        #endregion


        #region ���� ����Ī
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerSkullSwitch.Switch();
        }

        #endregion


        #region ��Ż ���
        if (Input.GetKeyDown(KeyCode.F))
        {
            playerPortalUse.portalUse();
        }
        #endregion
    }
}