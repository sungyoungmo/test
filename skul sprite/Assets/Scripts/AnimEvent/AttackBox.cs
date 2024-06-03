using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    public BoxCollider2D hitArea;

    void Start()
    {
        if (hitArea != null)
        {
            hitArea.enabled = false;
            hitArea.isTrigger = true;
        }
    }

    void ActivateHitArea()
    {
        Debug.Log("ActivateHitArea");
        if (hitArea != null)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                hitArea.size = spriteRenderer.size;
            }
            hitArea.enabled = true;
        }
    }

    void DeactivateHitArea()
    {
        Debug.Log("DeactivateHitArea");
        if (hitArea != null)
        {
            hitArea.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(1);
        }
    }
}
