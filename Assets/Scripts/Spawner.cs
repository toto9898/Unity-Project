using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objects;

    public GameObject Spawn(int objectIndex, Vector3 possition, Quaternion rotation)
    {
        if ((objectIndex >= 0 && objectIndex < objects.Count) == false)
        {
            Debug.LogError("Failed to load the spawnable objects, or invalid object index");
            return null;
        }

        GameObject obj = Instantiate(objects[objectIndex]);
        obj.transform.position = possition;
        obj.transform.rotation = rotation;

        return obj;
    }
}
