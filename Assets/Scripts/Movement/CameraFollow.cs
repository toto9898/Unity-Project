using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    private void LateUpdate()
    {
        if (player != null)
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        else
            Debug.LogWarning("Camera has lost the player refference.");
    }
}
