using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Timeline;

public class BulletMovement : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        Vector3 direction = transform.right;
        direction *= speed;

        transform.position += direction * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.gameObject.CompareTag("Bullet") == false)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);        
    }
}
