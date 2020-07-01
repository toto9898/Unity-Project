using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class FreeMovement : MonoBehaviour
{
    private MovementController controller;
    private Rigidbody2D rigidbody;

    private Vector2 direction;
    private HorizontalDirectionChange directionChange;

    void Start()
    {
        directionChange = GetComponentInChildren<HorizontalDirectionChange>();
        controller = GetComponent<MovementController>();
        rigidbody = GetComponent<Rigidbody2D>();

        direction = Vector2.right;
        controller.Mode = MovementController.MovementMode.RIGIDBODY;
        controller.fullSpeed = true;

        directionChange.OnDirectionChange += DirectionChange;
    }

    void Update()
    {
        controller?.Move(direction);
    }

    void DirectionChange()
    {
        rigidbody.velocity = new Vector2(-rigidbody.velocity.x, rigidbody.velocity.y);
        direction = -direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BlockInteractive block = collision.gameObject.GetComponent<BlockInteractive>();
        
        if (collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);
        else if (block != null && block.Activating)
            controller.Jump();
    }

    private void OnDestroy()
    {
        directionChange.OnDirectionChange -= DirectionChange;
    }
}
