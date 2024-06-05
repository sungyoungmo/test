using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManAtArms_TackleEffect : MonoBehaviour
{
    public GameObject parentObject;

    Animator animator;
    SpriteRenderer manAtArmsSpriteRenderer;
    SpriteRenderer tackleRenderer;
    Transform enemyPos;

    float damage;

    void Awake()
    {
        animator = GetComponent<Animator>();

        if (parentObject != null)
        {
            enemyPos = parentObject.transform;
            manAtArmsSpriteRenderer = parentObject.GetComponent<SpriteRenderer>();
        }


        tackleRenderer = GetComponent<SpriteRenderer>();
        damage = GetComponentInParent<LargeMob>().attackPower * 2;
    }

    void OnEnable()
    {

        if (manAtArmsSpriteRenderer.flipX)
        {
            this.transform.position = new Vector3(enemyPos.position.x, enemyPos.position.y + 1.5f, 0);

            this.GetComponent<BoxCollider2D>().offset = new Vector2(-1.5f, 0);

            tackleRenderer.flipX = true;
        }
        else
        {
            this.transform.position = new Vector3(enemyPos.position.x, enemyPos.position.y + 1.5f, 0);

            this.GetComponent<BoxCollider2D>().offset = new Vector2(1.5f, 0);

            tackleRenderer.flipX = false;

        }

        animator.Play("Tackle_Flash");
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Untagged")
        {
            other.GetComponentInParent<PlayerInfo>().GetDamage(damage);
        }
    }

}
