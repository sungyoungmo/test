using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public static PlayerDash instance;

    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    public float dashForce = 1000.0f;
    public float antiGravity = 20.0f;
    public float dashCooldown = 1.0f;
    private int dashCount = 2;
    private bool isDashing = false;

    readonly int stateIsDash = Animator.StringToHash("stateIsDash");


    private void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        if (animator.GetBool(stateIsDash))
        {
            rb.velocity = Vector2.zero;

            if (!spriteRenderer.flipX)
            {
                rb.AddForce(Vector2.right * dashForce);
            }
            else
            {
                rb.AddForce(Vector2.left * dashForce);
            }

            rb.AddForce(Vector2.up * rb.mass * antiGravity);
        }
    }

    public IEnumerator Dash()
    {
        animator.SetBool(stateIsDash, true);

        yield return new WaitForSeconds(0.2f);

        animator.SetBool(stateIsDash, false);
        rb.velocity = Vector2.zero;
        isDashing = false;
    }

    public IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashCooldown);
        dashCount = 2;
    }

    public bool CanDash()
    {
        return dashCount > 0 && !isDashing;
    }

    public void UseDash()
    {
        dashCount--;
        isDashing = true;
        if (dashCount == 1)
        {
            StartCoroutine(DashCooldown());
        }
    }
}
