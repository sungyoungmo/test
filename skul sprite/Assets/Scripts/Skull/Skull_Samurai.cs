using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull_Samurai : MonoBehaviour
{
    public static Skull_Samurai instance;

    public Animator animator;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;


    void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        
    }
}
