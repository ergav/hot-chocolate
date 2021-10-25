using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Trigger : MonoBehaviour
{
    public UnityEvent triggerEvent;
    public UnityEvent triggerExitEvent;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggerEvent.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        triggerExitEvent.Invoke();

    }

}
