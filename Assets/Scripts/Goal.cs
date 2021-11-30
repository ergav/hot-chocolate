using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] GameObject goalUI;
    [SerializeField] GameObject textBox;

    [SerializeField] bool goalReached;
    GameManager gameManager;

    bool clearTextVisible;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        //if (goalReached)
        //{
        //    goalUI.SetActive(true);
        //}

        if (clearTextVisible)
        {
            textBox.SetActive(true);
        }
        else
        {
            textBox.SetActive(false);
        }
    }

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


    public void ClearText()
    {
        if (clearTextVisible)
        {
            clearTextVisible = false;
        }
        else
        {
            clearTextVisible = true;
        }
    }

}
