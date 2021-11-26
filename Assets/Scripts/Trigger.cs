using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Trigger : MonoBehaviour
{
    public UnityEvent triggerEvent;
    public UnityEvent triggerExitEvent;

    [SerializeField] bool onceOnly;

    [SerializeField] float delay = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(TriggerEnterDelay());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        triggerExitEvent.Invoke();
        if (onceOnly)
        {
            Destroy(gameObject);
        }

    }

    IEnumerator TriggerEnterDelay()
    {
        yield return new WaitForSeconds(delay);
        triggerEvent.Invoke();

    }

}
