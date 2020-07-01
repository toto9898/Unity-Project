using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringHandle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MovementController controller = collision.gameObject.GetComponent<MovementController>();
        if (controller == null)
            return;

        controller.JumpRegadrdless(Vector2.right);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MovementController controller = collision.gameObject.GetComponent<MovementController>();
        if (controller == null)
            return;

        controller.Move(Vector2.right);
        controller.JumpRegadrdless(Vector2.right * 50);
    }
}
