using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    GameObject appearancePrefab;
    GameObject archer;
    GameObject manAtArms;

    public GameObject[] spawnEnemy;

    bool isTriggerd;



    void Awake()
    {
        
        appearancePrefab = Resources.Load<GameObject>("Prefab/Enemy_Appearance");
        archer = Resources.Load<GameObject>("Prefab/Monster_Archer");
        manAtArms = Resources.Load<GameObject>("Prefab/Monster_ManAtArms");

    }


    public void SpawnEnemiesAtPositions()
    {
        foreach (var spawnPoint in spawnEnemy)
        {
            SpawnPostion spawnPosition = spawnPoint.GetComponent<SpawnPostion>();
            if (spawnPosition != null)
            {
                SpawnEnemy(spawnPosition.transform, spawnPosition.unit);
            }
            else
            {
                Debug.LogError("enemy error");
            }
        }
    }

    public void SpawnEnemy(Transform position, Unit unitName)
    {
        StartCoroutine(appearanceEffect(position, unitName));
    }

    IEnumerator appearanceEffect(Transform position, Unit unitName)
    {
        GameObject effectInstance = Instantiate(appearancePrefab, position.position, Quaternion.identity);
        yield return new WaitForSeconds(0.8f);
        Destroy(effectInstance);

        GameObject SpawnInstance = null;

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

        if (SpawnInstance != null && MonsterManager.Instance != null)
        {
            MonsterManager.Instance.AddMonster(SpawnInstance);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTriggerd && collision.CompareTag("Untagged"))
        {
            SpawnEnemiesAtPositions();
            isTriggerd = true;
        }
    }


    
}
public enum Unit
{
    Archer,
    ManAtArms
}
