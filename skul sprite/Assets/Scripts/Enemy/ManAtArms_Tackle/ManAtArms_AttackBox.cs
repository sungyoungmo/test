using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManAtArms_AttackBox : MonoBehaviour
{
    public Transform pos;
    public Vector2 boxSize;

    float damage;
    SpriteRenderer spriteRenderer;


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        damage = GetComponentInParent<LargeMob>().attackPower;
    }

    void ActivateHitArea()
    {
        if (spriteRenderer.flipX)
        {
            pos.position = new Vector2(this.transform.position.x - 1.5f, this.transform.position.y + 1.0f);
        }
        else
        {
            pos.position = new Vector2(this.transform.position.x + 1.5f, this.transform.position.y + 1.0f);
        }

        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);

        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.tag == "Untagged")
            {
                collider.GetComponentInParent<PlayerInfo>().GetDamage(damage);

            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }

}
