using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    public Transform pos;
    public Vector2 boxSize;
    public RuntimeAnimatorController samuraiAnimatorController;
    public RuntimeAnimatorController LittleBoneAnimatorController;

    PlayerInfo playerInfo;


    SpriteRenderer spriteRenderer;
    GameObject samuraiAttackEffectPrefab;
    GameObject LittleBoneAttackEffectPrefab;

    Animator animator;


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        samuraiAttackEffectPrefab = Resources.Load<GameObject>("Prefab/Hit_SkeletonSword");
        LittleBoneAttackEffectPrefab = Resources.Load<GameObject>("Prefab/Hit_Skul");


        samuraiAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimController/Samurai_Controller");
        LittleBoneAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimController/LittleBone_Controller");

        playerInfo = GetComponentInParent<PlayerInfo>();

    }



    void ActivateHitArea()
    {
        if (spriteRenderer.flipX)
        {
            pos.position = new Vector2(this.transform.position.x - 1.0f, this.transform.position.y + 0.5f);
        }
        else
        {
            pos.position = new Vector2(this.transform.position.x + 1.0f, this.transform.position.y + 0.5f);
        }

        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);

        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.tag == "Enemy")
            {
                collider.GetComponent<Enemy>().TakeDamage(playerInfo.attackDamage);
                StartCoroutine(attackEffect());   
            }
        }
    }

    void DeactivateHitArea()
    {
       
    }

    
    IEnumerator attackEffect()
    {
        GameObject attackEffectInstance;
        
        if (animator.runtimeAnimatorController == samuraiAnimatorController)    
        {
            attackEffectInstance = Instantiate(samuraiAttackEffectPrefab, pos.position, Quaternion.identity);
            attackEffectFlipX(attackEffectInstance);
        }
        else
        {
            attackEffectInstance = Instantiate(LittleBoneAttackEffectPrefab, pos.position, Quaternion.identity);
            attackEffectFlipX(attackEffectInstance);
        }

        yield return new WaitForSeconds(1.3f);
        Destroy(attackEffectInstance);
    }

    void attackEffectFlipX(GameObject attackEffectInstance)
    {
        SpriteRenderer attackSpriteRenderer = attackEffectInstance.GetComponent<SpriteRenderer>();
        if (spriteRenderer.flipX)
        {
            attackSpriteRenderer.flipX = true;
        }
        else
        {
            attackSpriteRenderer.flipX = false;
        }

    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
}
