using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public static PlayerDash instance;

    public Animator animator;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    public float dashForce = 1000.0f;
    public float antiGravity = 20.0f;
    public float dashCooldown = 2.0f; // Dash cooldown time
    private int dashCount = 2; // Maximum dash count
    private bool isDashing = false; // Whether the player is dashing

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        // Update 메서드는 비워둡니다. 대시 입력 처리는 InputKey 클래스에서 수행합니다.
    }

    public IEnumerator Dash()
    {
        animator.SetBool("stateIsDash", true); // Start the dash animation

        rb.velocity = Vector2.zero;

        if (!spriteRenderer.flipX)
            rb.AddForce(Vector2.right * dashForce);
        else
            rb.AddForce(Vector2.left * dashForce);

        rb.AddForce(Vector2.up * rb.mass * antiGravity);

        yield return new WaitForSeconds(0.2f); // Dash duration

        animator.SetBool("stateIsDash", false); // End the dash animation
        isDashing = false; // Reset the dash state
    }

    public IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashCooldown); // Wait for the set cooldown time
        dashCount = 2; // Reset the dash count
    }

    public bool CanDash()
    {
        return dashCount > 0 && !isDashing;
    }

    public void UseDash()
    {
        dashCount--;
        isDashing = true;
        if (dashCount == 1) // Start the cooldown when the first dash is used
        {
            StartCoroutine(DashCooldown());
        }
    }
}
