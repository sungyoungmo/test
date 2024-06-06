using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPostion : MonoBehaviour
{
    public Vector2 boxSize;
    public Transform boxPos;
    public Unit unit;

    bool isTriggerd;
    SpawnManager spawnManager;

    void Awake()
    {
        isTriggerd = false;
        spawnManager = SpawnManager.Instance;
    }


    // 트리거로 해야할까 콜리전으로 해야할까
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.collider.tag == "Untagged")
        //{
        //    Debug.Log(1);
        //    spawnManager.SpawnEnemy(boxPos, unit);
        //}
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(boxPos.position, boxSize);
    }

}
