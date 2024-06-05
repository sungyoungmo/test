using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform enemyDetectRangePos;
    public Transform enemyAttackRangePos;

    public Vector2 enemyDetectRangeBoxSize;
    public Vector2 enemyAttackRangeBoxSize;


    public float hp;
    public float attackPower;
    public float moveSpeed;
    protected int groundLayer;

    protected bool isOnGround;
    protected bool canMove;
    protected bool canAttack;
    bool isDead = false;

    protected float enemyGroundCheckDistance = 0.1f;

    protected Rigidbody2D rb;
    protected SpriteRenderer spriteRenderer;
    protected Animator animator;

    protected GameObject deadEffectPrefab;


    protected readonly int IsWalk = Animator.StringToHash("IsWalk");
    protected readonly int IsAttack = Animator.StringToHash("IsAttack");


    private DeadEffectManager deadEffectManager;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
    }

    protected virtual void Start()
    {
        deadEffectManager = DeadEffectManager.Instance;
    }


    protected virtual void Update()
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


        GroundCheck();

    }

    protected virtual void FixedUpdate()
    {
        if (animator.GetBool(IsWalk) && isOnGround && !animator.GetBool(IsAttack))
        {
            Vector2 getVel;

            if (!spriteRenderer.flipX)
            {
                getVel = new Vector2(1,0) * moveSpeed;
            }
            else
            {
                getVel = new Vector2(-1, 0) * moveSpeed;
            }

            getVel.y = rb.velocity.y;
            rb.velocity = getVel;
        }
    }

    public virtual void TakeDamage(float damage)
    {
        hp = hp - damage;

        if (hp <= 0)
        {
            //StartCoroutine(startDeadEffect());
            Destroy(this.gameObject);

        }
        else
        {

            spriteRenderer.color = Color.clear;
            StartCoroutine(FadeToOriginalColor());
        }

    }


    float fadeDuration = 0.5f;

    private IEnumerator FadeToOriginalColor()
    {
        Color originalColor = Color.white;
        Color startColor = spriteRenderer.color;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            spriteRenderer.color = Color.Lerp(startColor, originalColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.color = originalColor;
    }

    protected virtual void GroundCheck()
    {
        groundLayer = LayerMask.GetMask("GroundLayer");
        Vector3 enemyDirection;

        if (!spriteRenderer.flipX)
        {
            enemyDirection = new Vector3(1, 0, 0);
        }
        else
        {
            enemyDirection = new Vector3(-1, 0, 0);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position + enemyDirection, Vector2.down, enemyGroundCheckDistance, groundLayer);

        if (hit.collider != null)
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;

            if (!spriteRenderer.flipX)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }

        }
    }

    protected  IEnumerator EnemyMoveOn()
    {
        animator.SetBool(IsWalk, true);

        yield return new WaitForSeconds(4.0f);

        animator.SetBool(IsWalk, false);

        yield return new WaitForSeconds(2.0f);

        canMove = false;
    }

    protected virtual void EnenmyDetectPlayer()
    {
        Collider2D[] Detectcollider = Physics2D.OverlapBoxAll(enemyDetectRangePos.position, enemyDetectRangeBoxSize, 0);
        
        foreach (Collider2D collider in Detectcollider)
        {
            if (collider.tag == "Untagged" && !animator.GetBool(IsAttack))
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

    protected virtual void EnemyAttackPlayer()
    {
        Collider2D[] Attackcollider = Physics2D.OverlapBoxAll(enemyAttackRangePos.position, enemyAttackRangeBoxSize, 0);

        foreach (Collider2D collider in Attackcollider)
        {
            if (collider.tag == "Untagged" && !animator.GetBool(IsAttack))
            {

                StartCoroutine(setAttack());

            }
        }
    }

    protected virtual IEnumerator setAttack()
    {
        animator.SetBool(IsAttack, true);
        yield return new WaitForSeconds(3.0f);
        animator.SetBool(IsAttack, false);
        yield return new WaitForSeconds(5.0f);
        canAttack = false;
    }

    //protected IEnumerator startDeadEffect()
    //{
        
    //    Destroy(this.gameObject);
    //}

    private void OnDestroy()
    {
        DeadEffectManager.Instance.CreateDeadEffect(this.transform.position);
    }


}
