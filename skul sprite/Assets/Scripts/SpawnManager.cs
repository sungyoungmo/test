using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    GameObject appearancePrefab;
    GameObject archer;
    GameObject manAtArms;

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

        appearancePrefab = Resources.Load<GameObject>("Prefab/Enemy_Appearance");
        archer = Resources.Load<GameObject>("Prefab/Monster_Archer");
        manAtArms = Resources.Load<GameObject>("Prefab/Monster_ManAtArms");
    }

    public void SpawnEnemy(Transform position, Unit unitName)
    {
        StartCoroutine(appearanceEffect(position, unitName));
    }

    IEnumerator appearanceEffect(Transform position, Unit unitName)
    {
        GameObject effectInstance = Instantiate(appearancePrefab, position.position, Quaternion.identity);
        yield return new WaitForSeconds(1.0f);
        Destroy(effectInstance);

        GameObject SpawnInstance;

        switch (unitName)
        {
            case Unit.Archer:
                SpawnInstance = Instantiate(archer, position.position, Quaternion.identity);
                break;
            case Unit.ManAtArms:
                SpawnInstance = Instantiate(manAtArms, position.position, Quaternion.identity);
                break;
            default:
                Debug.Log("Nothing is spawned");
                break;
        }

    }
}
public enum Unit
{
    Archer,
    ManAtArms
}
