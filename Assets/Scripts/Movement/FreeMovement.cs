using UnityEngine;

public class FreeMovement : MonoBehaviour
{
    private MovementController controller;

    private Vector2 direction;
    private HorizontalDirectionChange directionChange;

    void Start()
    {
        directionChange = GetComponentInChildren<HorizontalDirectionChange>();
        controller = GetComponent<MovementController>();

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
        direction = -direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BlockInteractive block = collision.gameObject.GetComponent<BlockInteractive>();
        
        if (collision.gameObject.CompareTag("Player") && collision.otherCollider.gameObject.name != "HorizontalDirectionChange")
        {
            gameObject.GetComponent<MovementController>().JumpRegadrdless(Vector2.up);
            Destroy(gameObject);
        }
        else if (block != null && block.Activating)
            controller.Jump();
    }

    private void OnDestroy()
    {
        directionChange.OnDirectionChange -= DirectionChange;
    }
}
