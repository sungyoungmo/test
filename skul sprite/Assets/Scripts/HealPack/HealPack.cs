using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPack : MonoBehaviour
{

    Rigidbody2D rb;
    DeadEffectManager deadEffectManager;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        deadEffectManager = DeadEffectManager.Instance;

        //rb.AddForce(Vector2.up * 5.0f, ForceMode2D.Impulse);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * 0.8f, ForceMode2D.Impulse);
        }

        if (other.CompareTag("Untagged") && 
            (other.GetComponentInParent<PlayerInfo>().playerHP < other.GetComponentInParent<PlayerInfo>().playerMaxHp))
        {
            other.GetComponentInParent<PlayerInfo>().GetHeal(10);

            Destroy(this.gameObject);
        }
    }

    void OnDestroy()
    {
        DeadEffectManager.Instance.CreateHealPackEffect(this.transform.position);
    }

}
