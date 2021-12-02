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

    Animator anim;

    [SerializeField] float endDelay = 0.5f;

    [SerializeField]AudioSource audioSource;
    [SerializeField] AudioClip winSound;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
            }
        }

        if (anim == null)
        {
            anim = GetComponent<Animator>();
            if (anim == null)
            {
                anim = GetComponentInChildren<Animator>();
            }
        }
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
            anim.SetTrigger("StartAnimation");
            //goalUI.SetActive(true);
            goalReached = true;
            gameManager.GoalReached();
            gameManager.goalReached = true;
            audioSource.PlayOneShot(winSound);
            StartCoroutine(DelayEnd());
        }


    }

    IEnumerator DelayEnd()
    {
        yield return new WaitForSecondsRealtime(endDelay);
        goalUI.SetActive(true);
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
