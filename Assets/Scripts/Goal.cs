using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] GameObject goalUI;
    [SerializeField] bool goalReached;
    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    //void Update()
    //{
    //    if (goalReached)
    //    {
    //        goalUI.SetActive(true);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameManager.GoalReached();
            gameManager.goalReached = true;
            goalUI.SetActive(true);
            goalReached = true;
        }


    }
}
