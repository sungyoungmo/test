using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongDistanceMob : Enemy
{
    float attackDistance;

    void Start()
    {
        hp = 10;
        attackPower = 10;
        moveSpeed = 4;
        attackDistance = 5;
    }


    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }


    protected override void EnemyMove()
    {
        base.EnemyMove();
    }
}
