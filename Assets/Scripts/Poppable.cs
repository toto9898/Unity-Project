using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Poppable : MonoBehaviour
{
    public Action OnPop;
    public Action OnGoingDown;

    [SerializeField]
    protected float PoppingSpeed = 1;

    // Distance which the object travels up
    [SerializeField]
    protected float PoppingHeight;

    protected bool GoingUp { get; private set; } = false;
    protected bool GoingDown { get; private set; } = false;


    public bool Activating { get; private set; } = false;

    protected Vector3 popDirection;
    private float poppingDist = 0;


    protected virtual void Start()
    {
        PoppingHeight = GetComponent<BoxCollider2D>().size.y;
        popDirection = Vector3.zero;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Activating)
            DoPopping();
    }

    protected void StartPop()
    {
        OnPop?.Invoke();
        OnGoingDown?.Invoke();
    }

    protected void StartPop(Vector2 direction)
    {
        if (direction == Vector2.zero)
        {
            StartPop();
            return; 
        }

        if (Activating == false)
            popDirection = direction;

        Activating = true;
        if (!GoingDown)
        {
            GoingUp = true;
            OnPop?.Invoke();
        }
    }

    private void DoPopping()
    {
        // Moving up
        if (GoingUp && poppingDist < PoppingHeight)
        {
            if (poppingDist + PoppingSpeed * Time.deltaTime < PoppingHeight)
            {
                transform.position += popDirection * PoppingSpeed * Time.deltaTime;
                poppingDist += PoppingSpeed * Time.deltaTime;
            }
            else
            {
                transform.position += popDirection * (PoppingHeight - poppingDist);
                poppingDist += (PoppingHeight - poppingDist);

                GoingUp = false;
                GoingDown = true;
                OnGoingDown?.Invoke();
            }
        }
        // Moving down
        else if (GoingDown && poppingDist >= 0)
        {
            if (poppingDist > PoppingSpeed * Time.deltaTime)
            {
                transform.position -= popDirection * PoppingSpeed * Time.deltaTime;
                poppingDist -= PoppingSpeed * Time.deltaTime;
            }
            else
            {
                transform.position -= popDirection * poppingDist;
                poppingDist -= poppingDist;
                GoingDown = false;
                Activating = false;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Harmful"))
            StartPop(popDirection);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Harmful"))
            StartPop(popDirection);
    }
}
