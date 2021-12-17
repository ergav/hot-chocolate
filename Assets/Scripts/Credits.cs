using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Credits : MonoBehaviour
{
    public GameObject creditsText;
    Animator anim;

    SelectPlayer selectPlayer;

    void Start()
    {
        anim = creditsText.GetComponent<Animator>();
        selectPlayer = GameObject.FindObjectOfType<SelectPlayer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Cursor.visible = true;
            Destroy(selectPlayer.gameObject);
            SceneManager.LoadScene(0);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            Cursor.visible = true;
            Destroy(selectPlayer.gameObject);
            SceneManager.LoadScene(0);
        }
    }
}
