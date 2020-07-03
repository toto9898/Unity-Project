using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class ConditionSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectsToSpawn;

    [SerializeField]
    private uint coinsNeeded = 0;

    [SerializeField]
    private bool respawnOnDeath = false;

    private GameObject[] spawnedObjects = null;
    private bool[] alreadySpawned = null;

    private void Start()
    {
        spawnedObjects = new GameObject[objectsToSpawn.Count];
        alreadySpawned = new bool[objectsToSpawn.Count];

        for (int i = 0; i < objectsToSpawn.Count; i++)
        {
            spawnedObjects[i] = null;
            alreadySpawned[i] = false;
        }
    }

    private void Update()
    {
        if (Score.score >= coinsNeeded)
        {
            for (int i = 0; i < spawnedObjects.Length; ++i)
            {
                if (spawnedObjects[i] == null)
                {
                    if (respawnOnDeath ||
                        respawnOnDeath == false && alreadySpawned[i] == false)
                    {
                        spawnedObjects[i] = Instantiate(objectsToSpawn[i]);
                        spawnedObjects[i].transform.position = objectsToSpawn[i].transform.position;
                        spawnedObjects[i].SetActive(true);
                    }
                }
            }
        }
    }
}
