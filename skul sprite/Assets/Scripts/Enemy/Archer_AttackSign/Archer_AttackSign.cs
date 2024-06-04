using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_AttackSign : MonoBehaviour
{
    public GameObject parentObject;

    Animator animator;
    SpriteRenderer archerSpriteRenderer;
    SpriteRenderer attackRenderer;
    Transform enemyPos;

    void Awake()
    {
        animator = GetComponent<Animator>();

        if (parentObject != null)
        {
            enemyPos = parentObject.transform;
            archerSpriteRenderer = parentObject.GetComponent<SpriteRenderer>();
        }

        
        attackRenderer = GetComponent<SpriteRenderer>();
        
    }


    void OnEnable()
    {

        if (archerSpriteRenderer.flipX)
        {
            this.transform.position = new Vector3(enemyPos.position.x - 1, enemyPos.position.y + 0.8f, 0);
            attackRenderer.flipX = true;
        }
        else
        {
            this.transform.position = new Vector3(enemyPos.position.x + 1, enemyPos.position.y + 0.8f, 0);
            attackRenderer.flipX = false;

        }

        animator.Play("AttackSign");
    }
}
