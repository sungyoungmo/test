using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    float damage;

    void Start()
    {
        damage = GetComponentInParent<Boss>().attackPower;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Untagged")
        {
            Debug.Log("player");
            
            if (damage == 0)
            {
                damage = GetComponentInParent<Boss>().attackPower;
            }


            collision.GetComponentInParent<PlayerInfo>().GetDamage(damage);
        }
    }
}
