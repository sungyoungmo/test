using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager Instance;

    public List<GameObject> monsters = new List<GameObject>();
    public GameObject portal;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddMonster(GameObject monster)
    {
        monsters.Add(monster);
    }

    public void RemoveMonster(GameObject monster)
    {
        monsters.Remove(monster);
        CheckMonsters();
    }

    void CheckMonsters()
    {
        if (monsters.Count == 0)
        {
            ActivatePortal();
        }
    }

    void ActivatePortal()
    {
        if (portal != null)
        {
            portal.SetActive(true);
            Debug.Log("All monsters are defeated. Portal activated!");
        }
    }
}
