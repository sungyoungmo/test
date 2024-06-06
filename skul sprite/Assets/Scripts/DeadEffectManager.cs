using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEffectManager : MonoBehaviour
{
    public static DeadEffectManager Instance;

    GameObject deadEffectPrefab;

    void Awake()
    {
       if (Instance == null)
        {
            Instance = this;
        }
       else
        {
            DestroyImmediate(this);
        }

        deadEffectPrefab = Resources.Load<GameObject>("Prefab/Enemy_Dead");
    }

    public void CreateDeadEffect(Vector3 position)
    {
        StartCoroutine(deadEffect(position));
    }

    IEnumerator deadEffect(Vector3 position)
    {
        
        GameObject effectInstance = Instantiate(deadEffectPrefab, position, Quaternion.identity);
        yield return new WaitForSeconds(0.6f);

        Destroy(effectInstance);

    }

}
