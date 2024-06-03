using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack instance;

    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    readonly int stateIsMoving = Animator.StringToHash("stateIsMoving");
    readonly int trAttack = Animator.StringToHash("trAttack");
    readonly int stateIsAttack = Animator.StringToHash("stateIsAttack");
    readonly int stateOnGround = Animator.StringToHash("stateOnGround");


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (animator.GetBool(stateIsAttack))
        {
            AttackDash();
        }
    }

    public void AttackDash()
    {
        if (animator.GetBool(stateIsMoving) && animator.GetBool(stateOnGround))
        {
            rb.velocity = Vector2.zero;

            if (!spriteRenderer.flipX)
            {
                rb.AddForce(Vector2.right * 300.0f);
            }
            else
            {
                rb.AddForce(Vector2.left * 300.0f);
            }

            rb.velocity = Vector2.zero;
        }

    }

    public IEnumerator Attack()
    {
        animator.SetTrigger(trAttack);
        yield return null;
    }

    public IEnumerator CanAttackTime()
    {
        animator.SetBool(stateIsAttack, true);
        yield return new WaitForSeconds(0.2f);
        animator.SetBool(stateIsAttack, false);
    }
}
