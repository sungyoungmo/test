using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    GameObject player;

    void Awake()
    {
        player = GameObject.Find("Idle");
        player.transform.position = transform.position;

    }

    void OnEnable()
    {
    }

    void Start()
    {
        
    }
}
