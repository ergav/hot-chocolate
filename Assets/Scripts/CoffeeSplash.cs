using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeSplash : MonoBehaviour
{
    [SerializeField] GameObject splashEffect;

    GameObject splash;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            splash = Instantiate(splashEffect, collision.transform.position, transform.rotation);
            StartCoroutine(DespawnSplash());
            Debug.Log("Splash!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            splash = Instantiate(splashEffect, collision.transform.position, transform.rotation);
            StartCoroutine(DespawnSplash());
            Debug.Log("Splash!");
        }
    }

    IEnumerator DespawnSplash()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(splash.gameObject);
    }
}
