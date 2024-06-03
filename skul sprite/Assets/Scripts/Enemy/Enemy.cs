using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    protected float hp;
    protected float attackPower;
    protected float moveSpeed;


    public virtual void TakeDamage(float damage)
    {
        hp = hp - damage;

        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
