using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;


public class HandMovement : MonoBehaviour
{
    [SerializeField]
    [Range(0, 2)]
    float radius = 0.8f;

    [SerializeField]
    Transform eyes;

    Transform player;

    void Start()
    {
        player = transform.parent;
    }

    void Update()
    {
        AdjustRadius();
        RotateHand();
    }

    void AdjustRadius()
    {
        Vector3 currRadius = transform.position - player.position;
        float currRadiusLength = Vector3.Distance(transform.position, player.position);

        Vector3 newRadius = currRadius;
        newRadius *= radius / currRadiusLength;

        transform.position = player.position + newRadius;
    }

    void RotateHand()
    {
        float oldPos = transform.localPosition.x;

        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 from = transform.position - player.position;
        Vector3 to = mousePos - player.position;

        float angle = Vector2.SignedAngle(from, to);
        transform.RotateAround(player.position, player.forward, angle);

        if (Mathf.Sign(oldPos) != Mathf.Sign(transform.localPosition.x))
            Flip();
    }

    void Flip()
    {
        transform.Rotate(Vector2.right, 180);
        eyes.Rotate(Vector2.up, 180);
    }

}
