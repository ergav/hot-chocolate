using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{

    public float startDelay = 0.5f;

    bool starting;

    public void PlayGame()
    {
        if (!starting)
        {
            starting = true;
            StartCoroutine(StartDelay());
        }
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(startDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}