using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalDirectionChange : MonoBehaviour
{
    public Action OnDirectionChange;

    [SerializeField]
    private GroundCheck left;
    [SerializeField]
    private GroundCheck right;

    private bool switchedRecently;
    private float minTimeAfterSwitch = 0.2f;
    private float lastSwitchTime = 0;

    private void Update()
    {
        if (left == null || right == null)
            return;


        if (Time.realtimeSinceStartup - lastSwitchTime > minTimeAfterSwitch && (left.Grounded ^ right.Grounded))
        {
            OnDirectionChange?.Invoke();
            lastSwitchTime = Time.realtimeSinceStartup;
        }

        //if (!switchedRecently && (left.Grounded ^ right.Grounded))
        //{
        //    OnDirectionChange?.Invoke();
        //    switchedRecently = true;
        //}

        //if (switchedRecently && left.Grounded && right.Grounded)
        //    switchedRecently = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.realtimeSinceStartup - lastSwitchTime > minTimeAfterSwitch)
        {
            OnDirectionChange?.Invoke();
            lastSwitchTime = Time.realtimeSinceStartup;
        }
    }
}
