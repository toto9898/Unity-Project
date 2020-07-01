using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalDirectionChange : MonoBehaviour
{
    public Action OnDirectionChange;

    [SerializeField]
    GroundCheck left;
    [SerializeField]
    GroundCheck right;

    bool switchedRecently;


    private void Update()
    {
        if (left == null || right == null)
            return;

        if (!switchedRecently && (left.Grounded ^ right.Grounded))
        {
            OnDirectionChange?.Invoke();
            switchedRecently = true;
        }

        if (switchedRecently && left.Grounded && right.Grounded)
            switchedRecently = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnDirectionChange?.Invoke();
    }
}
