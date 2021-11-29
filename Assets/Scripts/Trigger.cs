using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Trigger : MonoBehaviour
{
    [SerializeField] string collissionTagName = "Player";

    public UnityEvent triggerEvent;
    public UnityEvent triggerExitEvent;

    [SerializeField] bool onceOnly;
    bool activated;

    [SerializeField] float delay = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == collissionTagName)
        {
            if (onceOnly)
            {
                if (!activated)
                {
                    StartCoroutine(TriggerEnterDelay());
                    activated = true;
                }
            }
            else
            {
                StartCoroutine(TriggerEnterDelay());

            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == collissionTagName)
        {
            triggerExitEvent.Invoke();

        }

    }

    IEnumerator TriggerEnterDelay()
    {
        yield return new WaitForSeconds(delay);
        triggerEvent.Invoke();
        if (onceOnly)
        {
            Destroy(gameObject);
        }
    }

}
