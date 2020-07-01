using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{
    private MovementController controller;

    private Vector2 direction;
    private bool activated = false;

    private HorizontalDirectionChange directionChange;

    void Start()
    {
        directionChange = GetComponentInChildren<HorizontalDirectionChange>();
        controller = GetComponent<MovementController>();

        direction = Vector2.zero;
        controller.Mode = MovementController.MovementMode.TRANSFORM;

        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;

    }

    void Update()
    {
        controller?.Move(direction);
    }

    void DirectionChange()
    {
        direction = -direction;
    }

    public void Activate()
    {
        if (activated == false)
            direction = Vector2.up;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (activated == false)
        {
            activated = true;
            controller.Mode = MovementController.MovementMode.RIGIDBODY;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            direction = Vector2.right;
            directionChange.OnDirectionChange += DirectionChange;
        }
    }

    private void OnDestroy()
    {
        directionChange.OnDirectionChange -= DirectionChange;
    }
}
