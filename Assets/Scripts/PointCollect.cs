using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollect : MonoBehaviour
{
    public int pointsWorth = 1;

    public float rotateSpeed = 100;

    [SerializeField] GameManager gameManager;

    public AudioSource audioSource;
    public AudioClip collectSound;

    private void Start()
    {
        if (gameManager == null)
        {
            gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        }

        if (audioSource == null)
        {
            audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        }
    }

    private void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameManager.points += pointsWorth;
            audioSource.PlayOneShot(collectSound);
            Destroy(gameObject);
        }

    }
}
