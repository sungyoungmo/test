using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlarform : MonoBehaviour
{

    void OnEnable()
    {
        StartCoroutine(activeCollider());
    }

    IEnumerator activeCollider()
    {
        yield return new WaitForSeconds(1.3f);

        GetComponent<BoxCollider2D>().enabled = true;
    
    }

}
