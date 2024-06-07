using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public float attackDamage;
    public float playerMaxHp;
    public float playerHP;
    Animator animator;

    readonly int stateIsDash = Animator.StringToHash("stateIsDash");

    void Awake()
    {
        attackDamage = 3;
        playerMaxHp = 100;
        playerHP = playerMaxHp;
        animator = GetComponentInChildren<Animator>();
    }


    public void GetDamage(float attackDamage)
    {
        if (!animator.GetBool(stateIsDash))
        {
            playerHP = playerHP - attackDamage;
        }
    }

    public void GetHeal(float healAmount)
    {
        if (playerHP + healAmount <= playerMaxHp)
        {
            playerHP = playerHP + healAmount;
        }
        else
        {
            playerHP = playerMaxHp;
        }
    }
}
