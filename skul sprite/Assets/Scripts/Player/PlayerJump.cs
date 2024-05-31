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

    public float jumpPower = 10.0f;
    protected int maxJumpCount = 2;


    float groundCheckDistance = 0.1f;


    int jumpCount = 0;
    private bool isOnGround = false;

    void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GroundCheck();
        Debug.Log(isOnGround);
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
            jumpCount++;
        }
        
    }

    void GroundCheck()
    {
        int groundLayer = LayerMask.GetMask("GroundLayer");
        // 플레이어 아래쪽으로 Raycast를 발사하여 땅이 있는지 확인
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
}
