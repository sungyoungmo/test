using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove instance;

    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;


    readonly int stateIsMoving = Animator.StringToHash("stateIsMoving");
    readonly int stateIsAttack = Animator.StringToHash("stateIsAttack");
    readonly int stateIsDash = Animator.StringToHash("stateIsDash");

    public float speed = 4.0f;
    float xmove;

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
        if (animator.GetBool(stateIsMoving) || animator.GetBool(stateIsAttack))
        {
            Vector2 getVel = new Vector2(xmove, 0) * speed;
            getVel.y = rb.velocity.y;
            rb.velocity = getVel;
        }
        else
        {
            Vector2 getvel = new Vector2(0, rb.velocity.y);
            rb.velocity = getvel;
        }
    }

    public void MoveOn()
    {
        xmove = Input.GetAxisRaw("Horizontal");
        if (!animator.GetBool(stateIsDash))
        {
            if (xmove != 0)
            {
                if (!animator.GetBool(stateIsAttack))
                {
                    animator.SetBool(stateIsMoving, true);

                    if (xmove < 0)
                    {
                        spriteRenderer.flipX = true;
                    }
                    else
                    {
                        spriteRenderer.flipX = false;
                    }
                }
            }
            else
            {
                animator.SetBool(stateIsMoving, false);
            }
        }
    }

}
