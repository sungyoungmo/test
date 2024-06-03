using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public static PlayerJump instance;

    readonly int stateOnJumping = Animator.StringToHash("stateOnJumping");
    readonly int stateIsFalling = Animator.StringToHash("stateIsFalling");
    readonly int stateOnGround = Animator.StringToHash("stateOnGround");
    readonly int stateIsAttack = Animator.StringToHash("stateIsAttack");

    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    GameObject smokeEffectPrefab;

    public float jumpPower = 10.0f;
    protected int maxJumpCount = 2;


    float groundCheckDistance = 0.1f;
    int groundLayer;


    int jumpCount = 0;
    private bool isOnGround = false;

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

        smokeEffectPrefab = Resources.Load<GameObject>("Prefab/Land_Smoke");
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GroundCheck();
    }


    void FixedUpdate()
    {
        if (animator.GetBool(stateOnJumping))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            animator.SetBool(stateOnJumping, false);
        }

        if (!animator.GetBool(stateOnGround) && rb.velocity.y < 0)
        {
            animator.SetBool(stateIsFalling, true);
        }
        else if (animator.GetBool(stateOnGround))
        {
            animator.SetBool(stateIsFalling, false);
        }
    }

    public void Jump()
    {
        // && 
        if(jumpCount < maxJumpCount && !animator.GetBool(stateIsAttack))
        {
            if (animator.GetBool(stateIsFalling) && jumpCount == 0)
            {
                jumpCount++;
            }

            animator.SetBool(stateOnJumping, true);
            if (jumpCount == 1)
            {
                StartCoroutine("Smoke");
            }
            jumpCount++;
        }
        
    }

    void GroundCheck()
    {
        groundLayer = LayerMask.GetMask("GroundLayer");

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        if (hit.collider != null)
        {
            // 땅에 닿았다면
            isOnGround = true;
            animator.SetBool(stateOnGround, true);
            animator.SetBool(stateIsFalling, false);

            jumpCount = 0;
        }
        else
        {
            // 공중에 있다면
            isOnGround = false;
            animator.SetBool(stateOnGround, false);
            animator.SetBool(stateIsFalling, true);
        }
    }

    IEnumerator Smoke()
    {
        GameObject smokeEffectInstance = Instantiate(smokeEffectPrefab, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.8f);
        Destroy(smokeEffectInstance);
    }
}
