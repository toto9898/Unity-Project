using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopCheck : MonoBehaviour
{

    public Action<Vector2> OnPop;
    public Action OnPop2;
    public Action OnFirstPop;
    public Vector2 direction;

    private bool popped = false;

    private void Start()
    {
        direction = transform.up;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (popped == false)
        {
            popped = true;
            OnFirstPop?.Invoke();
        }

        OnPop?.Invoke(direction);
        OnPop2?.Invoke();
    }
}
