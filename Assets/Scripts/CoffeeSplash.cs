using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeSplash : MonoBehaviour
{
    [SerializeField] GameObject splashEffect;

    GameObject splash;

    Vector3 splashPos = new Vector3(0, 2, 0);

    [SerializeField]AudioSource audioSource;

    [SerializeField] AudioClip[] splashSounds;

    int rng;

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        }

        rng = Random.Range(0, splashSounds.Length);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            splash = Instantiate(splashEffect, collision.transform.position + splashPos, transform.rotation);
            if (splashSounds.Length > 0)
            {
                audioSource.PlayOneShot(splashSounds[rng]);
                rng = Random.Range(0, splashSounds.Length);
            }
            StartCoroutine(DespawnSplash());
            Debug.Log("Splash!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            splash = Instantiate(splashEffect, collision.transform.position + splashPos, transform.rotation);


            StartCoroutine(DespawnSplash());
        }
    }

    IEnumerator DespawnSplash()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(splash.gameObject);
    }
}
