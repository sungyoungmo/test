using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSkull : MonoBehaviour
{
    Rigidbody2D rb;
    bool isUsed = false;
    float damage;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        damage = GameObject.Find("player").GetComponent<PlayerInfo>().attackDamage;
    }


    // 여기서 플레이어와 부딪쳤을 때 쿨타임 초기화 구현
    // 초기화가 되면 애니메이션 컨트롤러를 변경해주어야 하는데
    // 그건 playerSkill에서 처리하는게 나을 것 같다.
    // 얘는 캐릭터의 스킬 이펙트 부분이니까

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") && !isUsed)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.velocity = Vector2.zero;
            isUsed = true;
        }


        if (collision.collider.CompareTag("Enemy") && !isUsed)
        {
            rb.constraints = RigidbodyConstraints2D.None;

            this.gameObject.layer = 7;
            rb.velocity = Vector2.zero;

            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage * 2);

            isUsed = true;
        }

        if (collision.collider.CompareTag("Untagged"))
        {
            Debug.Log(3);
        }
    }
}
