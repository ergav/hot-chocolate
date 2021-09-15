using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Trigger : MonoBehaviour
{
    public UnityEvent[] triggerEvents;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < triggerEvents.Length; i++)
        {
            triggerEvents[i].Invoke();
        }
    }


}
