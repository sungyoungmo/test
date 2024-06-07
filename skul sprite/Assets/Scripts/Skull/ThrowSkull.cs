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


    // ���⼭ �÷��̾�� �ε����� �� ��Ÿ�� �ʱ�ȭ ����
    // �ʱ�ȭ�� �Ǹ� �ִϸ��̼� ��Ʈ�ѷ��� �������־�� �ϴµ�
    // �װ� playerSkill���� ó���ϴ°� ���� �� ����.
    // ��� ĳ������ ��ų ����Ʈ �κ��̴ϱ�

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
