using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPortalUse : MonoBehaviour
{
    public static PlayerPortalUse instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }


    public void portalUse()
    {
        CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();

        Vector2 boxSize = new Vector2(circleCollider.radius * 2, circleCollider.radius * 2);

        Collider2D[] hitColliders = Physics2D.OverlapBoxAll((Vector2)transform.position, boxSize, 0);


        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("portal"))
            {
                hitCollider.GetComponent<Portal>().portalUse();

            }
        }
    }

}
