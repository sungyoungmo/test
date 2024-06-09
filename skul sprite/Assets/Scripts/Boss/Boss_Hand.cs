using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Hand : MonoBehaviour
{

    readonly int Attack = Animator.StringToHash("Attack");
    readonly int Slide = Animator.StringToHash("Slide");
    readonly int Magic = Animator.StringToHash("Magic");

    Animator animator;

    Vector2 startPosition;
    Vector2 settingPosition;
    Vector2 EndPosition;


    bool isSetting = false;
    float moveDuration = 2.0f;
    float elapsedTime = 0.0f;

    void Awake()
    {

        startPosition = this.transform.position;
        animator = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        if (animator.GetBool("Slide"))
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / moveDuration;

            if (!isSetting)
            {
                if (startPosition.x < 0)
                {
                    settingPosition = new Vector2(-18, -3);
                }
                else
                {
                    settingPosition = new Vector2(18, -3);
                }
                transform.position = Vector2.Lerp(startPosition, settingPosition, t);

                if (Vector2.Distance(transform.position, settingPosition) < 0.01f || t >= 1.0f)
                {
                    isSetting = true;
                    elapsedTime = 0.0f;
                    startPosition = settingPosition;
                }

            }
            else
            {
                if (startPosition.x < 0)
                {
                    EndPosition = new Vector2(18, -3);
                }
                else
                {
                    EndPosition = new Vector2(-18, -3);
                }

                transform.position = Vector2.Lerp(startPosition, EndPosition, t);

                if (Vector2.Distance(transform.position, EndPosition) < 0.01f || t >= 1.0f)
                {
                    elapsedTime = 0.0f;
                    startPosition = EndPosition;
                    isSetting = false;
                }
            }
        }
        else if (animator.GetBool(Attack))
        {

        }
        else if (animator.GetBool(Magic))
        {

        }

    }

    public void Hand_Slide()
    {
        if (animator.GetBool(Slide))
        {
            animator.SetBool(Slide, false);
        }
        else
        {
            animator.SetBool(Slide, true);
        }

        
    }

    public void Hand_Stamp()
    {
        if (animator.GetBool(Attack))
        {
            animator.SetBool(Attack, false);
        }
        else
        {
            animator.SetBool(Attack, true);
        }
    }

    public void Hand_Magic()
    {
        if (animator.GetBool(Magic))
        {
            animator.SetBool(Magic, false);
        }
        else
        {
            animator.SetBool(Magic, true);
        }
    }

}
