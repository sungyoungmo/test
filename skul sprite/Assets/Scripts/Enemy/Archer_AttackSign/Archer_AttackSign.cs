using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_AttackSign : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }


    void OnEnable()
    {
        if (animator != null)
        {
            animator.Play("AttackSign");
        }
    }
}
