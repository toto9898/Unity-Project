using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNotify : MonoBehaviour
{
    [SerializeField]
    public Action OnTriggerEnter;
    public Action OnTriggerExit;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerEnter?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnTriggerExit?.Invoke();
    }
}
