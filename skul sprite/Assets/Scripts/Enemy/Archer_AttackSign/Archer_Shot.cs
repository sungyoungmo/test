using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_Shot : MonoBehaviour
{
    public GameObject parentObject;

    Animator animator;
    SpriteRenderer archerSpriteRenderer;
    SpriteRenderer arrowRenderer;
    Transform enemyPos;

    void Awake()
    {
        animator = GetComponent<Animator>();

        if (parentObject != null)
        {
            enemyPos = parentObject.transform;
            archerSpriteRenderer = parentObject.GetComponent<SpriteRenderer>();
        }


        arrowRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        if (archerSpriteRenderer.flipX)
        {
            this.transform.position = new Vector3(enemyPos.position.x - 1.5f, enemyPos.position.y + 0.8f, 0);
            arrowRenderer.flipX = true;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-10f, 0);
        }
        else
        {
            this.transform.position = new Vector3(enemyPos.position.x + 1.5f, enemyPos.position.y + 0.8f, 0);
            arrowRenderer.flipX = false;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(10f, 0);

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Untagged"))
        {
            this.gameObject.SetActive(false);
        }
    }

}
