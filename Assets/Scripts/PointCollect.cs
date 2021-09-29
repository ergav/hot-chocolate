using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollect : MonoBehaviour
{
    public int pointsWorth = 1;

    public float rotateSpeed = 100;

    [SerializeField] GameManager gameManager;

    private void Start()
    {
        if (gameManager == null)
        {
            gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
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
            Destroy(gameObject);
        }

    }
}
