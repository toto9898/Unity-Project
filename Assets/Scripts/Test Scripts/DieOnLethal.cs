using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnLethal : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lethal"))
            if (gameObject.layer != collision.gameObject.layer)
                Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Lethal"))
            if (gameObject.layer != collision.collider.gameObject.layer)
                Destroy(gameObject);
    }
}
