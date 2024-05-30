using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKey : MonoBehaviour
{

    Animator animator;
    readonly int aAttack = Animator.StringToHash("aAttack");
    readonly int isMoving = Animator.StringToHash("isMoving");

    float attackCoolDown = 0;

    public float speed = 4.0f;
    SpriteRenderer spriteRenderer;


    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        //animator = GetComponent<Animator>();
        speed = 4.0f;
    }


    void Update()
    {

        float xmove = Input.GetAxisRaw("Horizontal");

        if (xmove != 0)
        {
            if (xmove == 1)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }


            animator.SetBool(isMoving, true);

            float fallSpeed = this.GetComponent<Rigidbody2D>().velocity.y;

            Vector2 getVel = new Vector2(xmove, 0) * speed;

            getVel.y = fallSpeed;

            this.GetComponent<Rigidbody2D>().velocity = getVel;

        }
        else
        {
            float fallSpeed = this.GetComponent<Rigidbody2D>().velocity.y;

            Vector2 getVel = new Vector2(xmove, 0) * 0;

            getVel.y = fallSpeed;

            this.GetComponent<Rigidbody2D>().velocity = getVel;

            animator.SetBool(isMoving, false);
        }


       


        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    this.GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;

        //    animator.SetBool(isMoving, true);

        //}
        //else if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    //this.GetComponent<Rigidbody2D>().AddForce(Vector2.right);
        //    this.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        //    animator.SetBool(isMoving, true);
        //}
        //else
        //{
        //    animator.SetBool(isMoving, false);
        //}





        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger(aAttack);
        }
    }

}
