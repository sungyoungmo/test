using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackReset : MonoBehaviour
{

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void att()
    {
        animator.ResetTrigger("trAttack");
    }
}
