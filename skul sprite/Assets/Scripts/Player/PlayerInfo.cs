using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public float attackDamage;
    public float playerMaxHp;
    public float playerHP;


    void Awake()
    {
        attackDamage = 3;
        playerMaxHp = 100;
        playerHP = playerMaxHp;
    }


    void Update()
    {
        
    }
}
