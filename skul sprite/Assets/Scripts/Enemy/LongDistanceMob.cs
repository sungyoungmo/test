using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongDistanceMob : Enemy
{
    readonly int IsHit = Animator.StringToHash("IsHit");
    public GameObject attackSign;
    public GameObject arrow;

    private bool onAttack = false;

    protected override void Awake()
    {
        base.Awake();

        
    }

    void Start()
    { 
        hp = 10;
        attackPower = 10;
        moveSpeed = 2;
        isOnGround = false;
        canMove = false;
        canAttack = false;
    }

    

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        this.animator.SetTrigger(IsHit);
        StopCoroutine(EnemyMoveOn());
        animator.SetBool(IsWalk, false);
        canMove = true;

        StopCoroutine(setAttack());
        animator.SetBool(IsAttack,false);
        canAttack = true;
        attackSign.SetActive(false);
        
    }


    protected override void GroundCheck()
    {
        base.GroundCheck();
    }
    protected override IEnumerator setAttack()
    {
        animator.SetBool(IsAttack, true);
        yield return new WaitForSeconds(0.5f);
        attackSign.SetActive(true);

        yield return new WaitForSeconds(1.6f);
        arrow.SetActive(true);

        animator.SetBool(IsAttack, false);
        attackSign.SetActive(false);
        yield return new WaitForSeconds(1.0f);

        arrow.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        canAttack = false;
    }


}
