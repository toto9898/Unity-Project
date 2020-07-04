using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ConditionSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectsToSpawn;

    [SerializeField]
    private uint coinsNeeded = 0;

    [SerializeField]
    private bool respawnOnDeath = false;

    private TriggerNotify[] triggers;

    private class StatefulObject
    {
        public GameObject obj;
        public bool spawned;
        public int index;
    }

    private StatefulObject[] objects;

    private void Start()
    {
        triggers = GetComponentsInChildren<TriggerNotify>();
        foreach (var trigger in triggers)
            trigger.OnTriggerEnter += SpawnAll;

        objects = new StatefulObject[objectsToSpawn.Count];

        for (int i = 0; i < objectsToSpawn.Count; i++)
            objects[i] = new StatefulObject { index = i };
    }

    private void Update()
    {
        if (respawnOnDeath == false)
            return;

        foreach (var item in objects.Where(x =>
            x.obj == null &&
            x.spawned))
        {
            Spawn(item);
        }    
    }

    private void Spawn(StatefulObject obj)
    {
        if (obj.obj != null)
            return;

        obj.obj = Instantiate(objectsToSpawn[obj.index]);
        obj.spawned = true;
        obj.obj.transform.position = objectsToSpawn[obj.index].transform.position;
        obj.obj.SetActive(true);
    }
    
    private void SpawnAll()
    {
        if (Score.score < coinsNeeded) 
            return;

        foreach (var item in objects.Where(x => 
            x.obj == null &&
            x.spawned == false))
        {
            Spawn(item);
        }
    }

    private void OnDestroy()
    {
        foreach (var trigger in triggers)
            trigger.OnTriggerEnter -= SpawnAll;
    }
}
