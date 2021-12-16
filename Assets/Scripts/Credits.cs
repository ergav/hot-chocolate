using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Credits : MonoBehaviour
{
    public GameObject creditsText;
    Animator anim;

    void Start()
    {
        anim = creditsText.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Cursor.visible = true;
            SceneManager.LoadScene(0);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            Cursor.visible = true;
            SceneManager.LoadScene(0);
        }
    }
}
