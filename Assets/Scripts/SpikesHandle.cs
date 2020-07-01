using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpikesHandle : Poppable
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        int mask = LayerMask.GetMask("Player");

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, PoppingHeight, mask);
        Debug.DrawRay(transform.position, transform.up, Color.red);

        if (hit.collider != null)
            StartPop(transform.up);
    }
}
