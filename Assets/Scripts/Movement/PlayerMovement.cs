using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    MovementController controller;

    private void Start()
    {
        controller = GetComponent<MovementController>();
    }

    private void Update()
    {
        Vector2 direction = Vector2.right * Input.GetAxisRaw("Horizontal");
        controller.Move(direction);

        if (Input.GetButtonDown("Jump"))
            controller.Jump();
    }
}
