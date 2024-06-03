using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeMob : Enemy
{

    void Start()
    {
        hp = 30;
        attackPower = 15;
        moveSpeed = 2;
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }
}
