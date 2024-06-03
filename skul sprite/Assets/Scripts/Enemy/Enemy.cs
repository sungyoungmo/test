using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected float hp;
    protected float attackPower;
    protected float moveSpeed;
    protected int groundLayer;


    protected Rigidbody2D rb;
    protected SpriteRenderer spriteRenderer;
    protected Animator animator;

    readonly int IsWalk = Animator.StringToHash("IsWalk");

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    public virtual void TakeDamage(float damage)
    {
        hp = hp - damage;

        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    protected virtual void EnemyMove()
    {
        if (animator.GetBool(IsWalk))
        {
            //Vector2 getVel = new Vector2(xmove, 0) * moveSpeed;
            //getVel.y = rb.velocity.y;
            //rb.velocity = getVel;
        }
        else
        {
           
        }
    }

    protected virtual IEnumerator EnemyMoveOn()
    {
        animator.SetBool(IsWalk, true);
        yield return new WaitForSeconds(2.0f);
        animator.SetBool(IsWalk, false);

    }
}
