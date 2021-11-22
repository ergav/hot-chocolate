using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    SelectPlayer selectPlayer;

    [SerializeField] GameObject player;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] float respawnTime = 1;

    public int points;
    [SerializeField] Text pointsUI;
    [SerializeField] GameObject deathScreen;

    public bool paused;
    public bool goalReached;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        selectPlayer = GameObject.Find("PlayerSelect").GetComponent<SelectPlayer>();

        if (selectPlayer != null)
        {
            if (selectPlayer.player2Selected)
            {
                player.GetComponent<PlayerAnimations>().anim.runtimeAnimatorController = player.GetComponent<PlayerAnimations>().player2Controller;
            }

        }
    }

    void Update()
    {
        if (paused || goalReached)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (paused)
            {
                ResumeGame();
            }
            else
            {
                if (!goalReached)
                {
                    PauseGame();
                }
            }
        }

        if (pointsUI != null)
        {
            pointsUI.text = points.ToString();
        }

    }

    public void StartRespawnCount()
    {
        StartCoroutine(RespawnTimer());
    }

    IEnumerator RespawnTimer()
    {
        yield return new WaitForSeconds(respawnTime);
        Respawn();
    }

    public void PlayerDeath()
    {
        deathScreen.SetActive(true);
        //StartRespawnCount();
    }

    public void GoalReached()
    {
        goalReached = true;
    }

    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame()
    {
        paused = true;
        pauseMenu.SetActive(true);

    }
    public void ResumeGame()
    {
        paused = false;
        pauseMenu.SetActive(false);

    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
