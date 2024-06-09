using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeMob : Enemy
{
    public GameObject tackleEffect;
    readonly int IsTackle = Animator.StringToHash("IsTackle");

    Rigidbody2D mAARb;

    protected override void Start()
    {
        base.Start();

        hp = 30;
        attackPower = 15;
        moveSpeed = 2;
        canMove = false;
        canAttack = false;
        mAARb = this.GetComponent<Rigidbody2D>();
    }

    protected override void Update()
    {

        if (!animator.GetBool(IsWalk) && !canMove)
        {
            StartCoroutine(EnemyMoveOn());
        }
        else
        {
            canMove = true;
        }

        EnenmyDetectPlayer();

        if (!animator.GetBool(IsAttack) && !canAttack)
        {
            EnemyAttackPlayer();
        }
        else
        {
            canAttack = true;
        }

        if (!animator.GetBool(IsTackle))
        {
            GroundCheck();
        }
        
    }





    protected override void FixedUpdate()
    {
        if (animator.GetBool(IsWalk) && isOnGround && !animator.GetBool(IsAttack) && !animator.GetBool(IsTackle))
        {
            Vector2 getVel;

            if (!spriteRenderer.flipX)
            {
                getVel = new Vector2(1, 0) * moveSpeed;
            }
            else
            {
                getVel = new Vector2(-1, 0) * moveSpeed;
            }

            getVel.y = rb.velocity.y;
            rb.velocity = getVel;
        }

        if (animator.GetBool(IsTackle))
        {
            
        }
    }

    protected override void EnenmyDetectPlayer()
    {
        Collider2D[] Detectcollider = Physics2D.OverlapBoxAll(enemyDetectRangePos.position, enemyDetectRangeBoxSize, 0);

        foreach (Collider2D collider in Detectcollider)
        {
            if (collider.tag == "Untagged" && !animator.GetBool(IsAttack) && !animator.GetBool(IsTackle))
            {

                if (Mathf.Abs(collider.transform.position.x - enemyDetectRangePos.position.x) > 0.5)
                {
                    if (collider.transform.position.x < enemyDetectRangePos.position.x)
                    {
                        spriteRenderer.flipX = true;
                    }
                    else
                    {
                        spriteRenderer.flipX = false;
                    }
                }



            }
        }
    }

    protected override void EnemyAttackPlayer()
    {
        Collider2D[] Attackcollider = Physics2D.OverlapBoxAll(enemyAttackRangePos.position, enemyAttackRangeBoxSize, 0);

        foreach (Collider2D collider in Attackcollider)
        {
            if (collider.tag == "Untagged" && !animator.GetBool(IsAttack) && !animator.GetBool(IsTackle))
            {
                StartCoroutine(setAttack());
            }
        }
    }

    protected override IEnumerator setAttack()
    {
        int rValue = Random.Range(1, 5);

        if(rValue == 1)
        {
            animator.SetBool(IsTackle, true);
            yield return new WaitForSeconds(0.8f);
            tackleEffect.SetActive(true);

            Vector2 getVal;
            
            if (spriteRenderer.flipX)
            {
                getVal = new Vector2(-5,0);
            }
            else
            {
                getVal = new Vector2(5, 0);
            }
            
            mAARb.velocity = getVal;

            yield return new WaitForSeconds(1.8f);
            tackleEffect.SetActive(false);
            yield return new WaitForSeconds(0.4f);

            mAARb.velocity = Vector2.zero;

            animator.SetBool(IsTackle, false);

            yield return new WaitForSeconds(3.0f);
            canAttack = false;
        }
        else
        {
            StartCoroutine(base.setAttack());
        }
    }


}
