using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementController : MonoBehaviour
{
    public enum MovementMode { RIGIDBODY, TRANSFORM }
    public MovementMode Mode { get; set; } = MovementMode.RIGIDBODY;

    public bool fullSpeed = false;


    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float maxSpeed = 8;

    [SerializeField]
    private float jumpForce = 8;

    [SerializeField]
    private float fallMultiplier = 2.5f;

    [SerializeField]
    private float lowJumpMultiplier = 2f;

    [SerializeField]
    private bool grounded = false;
    
    private bool doJump;

    [SerializeField]
    private Vector2 direction;

    private GroundCheck groundCheck;

    private float aceleration;
    public float Aceleration 
    { 
        get => grounded ? aceleration : aceleration / 1.5f; 
        set => aceleration = value; 
    }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        groundCheck = GetComponentInChildren<GroundCheck>();
        if (groundCheck == null)
            Debug.LogWarning("Object does not have GroundCheck component");

        direction = Vector2.zero;
        Aceleration = maxSpeed / 3;
    }

    // Update is called once per frame
    private void Update()
    {
        if (groundCheck)
            grounded = groundCheck.Grounded;

        if (Mode == MovementMode.TRANSFORM)
        {
            transform.position += maxSpeed * (Vector3)direction * Time.deltaTime;
            if (doJump)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                doJump = false;
                grounded = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Mode == MovementMode.TRANSFORM)
        {
            BetterJump();
            return;
        }

        //if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        //    direction = Vector2.zero;
        
        if (fullSpeed)
        {
            rb.velocity = new Vector2(maxSpeed * direction.x, rb.velocity.y);
        }
        else if (Mathf.Abs(rb.velocity.x) < maxSpeed)
        {
            rb.velocity += direction * Aceleration * 10 * Time.fixedDeltaTime;

            rb.velocity =
                new Vector2(
                    Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed),
                    rb.velocity.y);
        }

        if (doJump && Mathf.Abs(rb.velocity.y) < 0.2)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            doJump = false;
            grounded = false;
        }

        BetterJump();
        FastStopping();
    }

    private void FastStopping()
    {
        if (direction == Vector2.zero && Mathf.Abs(rb.velocity.x) > Aceleration)
            rb.velocity -= new Vector2(Mathf.Sign(rb.velocity.x) * Aceleration * Time.fixedDeltaTime, 0);
    }

    private void BetterJump()
    {
        // Debug.Log(Physics2D.gravity.y);

        if (rb.velocity.y < 0)
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
        else if (rb.velocity.y < 2 && Input.GetButton("Jump"))
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
    }

    public void Move(Vector2 direction)
    {
        this.direction = direction;
    }

    public void Jump()
    {
        if (grounded)
            doJump = true;
    }

    public void JumpRegadrdless(Vector2 direction)
    {
        rb.AddForce(direction * jumpForce, ForceMode2D.Impulse);
    }
}
