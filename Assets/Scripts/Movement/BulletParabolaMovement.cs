using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParabolaMovement : MonoBehaviour
{
    [SerializeField]
    private float shootForce = 8f;

    private Vector3 prevPos;

    // Start is called before the first frame update
    void Start()
    {
        prevPos = transform.position;
        shootForce = 8f;
        GetComponent<Rigidbody2D>().AddForce(transform.right * shootForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = prevPos - transform.position;
        
        if (direction != Vector3.zero)
        {
            transform.right = -direction.normalized;
        }

        prevPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Bullet") == false)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
