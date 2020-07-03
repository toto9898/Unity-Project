using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]
    private bool grounded;
    public bool Grounded { get => grounded; private set => grounded = value; }

    [SerializeField]
    [Range(0, 5f)]
    private float RayLength = 0.58f;

    [SerializeField]
    [Range(0, 3f)]
    private float RayOffset = 0.35f;

    private void Update()
    {
        int mask = LayerMask.GetMask("Ground");

        RaycastHit2D ray1 = Physics2D.Raycast(
            transform.position + Vector3.right * RayOffset, 
            Vector3.down, 
            RayLength, mask);

        RaycastHit2D ray2 = Physics2D.Raycast(
            transform.position + Vector3.left * RayOffset,
            Vector3.down,
            RayLength, mask);


        if (ray1.collider != null || ray2.collider != null)
            Grounded = true;
        else
            Grounded = false;

        Debug.DrawRay(transform.position + Vector3.right * RayOffset, Vector3.down * RayLength);
        Debug.DrawRay(transform.position + Vector3.left * RayOffset, Vector3.down * RayLength);
    }
}
