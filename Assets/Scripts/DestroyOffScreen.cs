using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 viewportPoint = Camera.main.WorldToViewportPoint(transform.position);
        if (!(viewportPoint.x >= 0 && viewportPoint.x <= 1 &&
            viewportPoint.y >= 0 && viewportPoint.y <= 1))
            Destroy(gameObject);
    }
}
