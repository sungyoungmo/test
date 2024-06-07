using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public static PlayerDash instance;

    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    GameObject dashSmokeEffectPrefab;


    public float dashForce = 1000.0f;
    public float antiGravity = 20.0f;
    public float dashCooldown = 1.0f;
    private int dashCount = 2;
    private bool isDashing = false;

    readonly int stateIsDash = Animator.StringToHash("stateIsDash");


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }


        dashSmokeEffectPrefab = Resources.Load<GameObject>("Prefab/Dash_Smoke");
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
        StartCoroutine(OnDashEffect());

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

    public IEnumerator Dashafterimage()
    {
        GameObject afterimage = new GameObject("afterimage");

        SpriteRenderer newSpriteRenderer = afterimage.AddComponent<SpriteRenderer>();

        newSpriteRenderer.sprite = spriteRenderer.sprite;
        newSpriteRenderer.color = new Color(0, 0, 0, 1);
        if (!spriteRenderer.flipX)
        {
            newSpriteRenderer.flipX = false;
        }
        else
        {
            newSpriteRenderer.flipX = true;
        }

        afterimage.transform.position = this.transform.position;

        yield return new WaitForSeconds(0.2f);

        Destroy(afterimage);
    }

    IEnumerator DashEffect()
    {
        GameObject dashsmokeEffectInstance = Instantiate(dashSmokeEffectPrefab, this.transform.position, Quaternion.identity);
        SpriteRenderer dashSpriteRenderer = dashsmokeEffectInstance.GetComponent<SpriteRenderer>();
        if (spriteRenderer.flipX)
        {
            dashSpriteRenderer.flipX = true;
        }
        else
        {
            dashSpriteRenderer.flipX = false;
        }

        yield return new WaitForSeconds(2.0f);
        Destroy(dashsmokeEffectInstance);
    }



    IEnumerator OnDashEffect()
    {
        StartCoroutine(DashEffect());
        for (int i = 0; i < 5; i++)
        {
            StartCoroutine(Dashafterimage());

            yield return new WaitForSeconds(0.05f);
        }
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
