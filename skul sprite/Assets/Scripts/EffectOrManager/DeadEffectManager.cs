using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEffectManager : MonoBehaviour
{
    public static DeadEffectManager Instance;

    GameObject deadEffectPrefab;
    GameObject getHealEffectPrefab;
    GameObject healPackPrefab;

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
        getHealEffectPrefab = Resources.Load<GameObject>("Prefab/HealEffect");
        healPackPrefab = Resources.Load<GameObject>("Prefab/HealPack");
    }

    public void CreateDeadEffect(Vector3 position)
    {
        StartCoroutine(deadEffect(position));
    }

    public void CreateHealPack(Vector3 position)
    {
        StartCoroutine(HealPackDrop(position));
    }

    public void CreateHealPackEffect(Vector3 position)
    {
        StartCoroutine(GetHealEffect(position));
    }

    IEnumerator deadEffect(Vector3 position)
    {
        
        GameObject effectInstance = Instantiate(deadEffectPrefab, position, Quaternion.identity);
        yield return new WaitForSeconds(0.6f);

        Destroy(effectInstance);

    }

    IEnumerator HealPackDrop(Vector3 position)
    {
        GameObject effectInstance = Instantiate(healPackPrefab, position, Quaternion.identity);
        yield return null;
    }

    IEnumerator GetHealEffect(Vector3 position)
    {
        GameObject effectInstance = Instantiate(getHealEffectPrefab, position, Quaternion.identity);
        yield return new WaitForSeconds(1.7f);

        Destroy(effectInstance);
    }



}
