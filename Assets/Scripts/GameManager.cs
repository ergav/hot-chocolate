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

    PlayerInput pInput;
    PlayerAnimations pAnim;
    Health pHealth;


    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player == null)
            {
                Debug.Log("Player not found");

            }
        }

        selectPlayer = GameObject.Find("PlayerSelect").GetComponent<SelectPlayer>();

        if (selectPlayer != null)
        {
            Debug.Log("Selectplayer found");
            if (selectPlayer.player2Selected)
            {
                Debug.Log("Player 2 was selected.");
                PlayerAnimations playerAnimations = player.GetComponent<PlayerAnimations>();
                if (playerAnimations == null)
                {
                    Debug.Log("Playeranimations not found");
                }
                if (playerAnimations.anim == null)
                {
                    Debug.Log("anim not found");

                }
                if (playerAnimations.player2Controller == null)
                {
                    Debug.Log("player2controller not found");

                }
                if (playerAnimations.anim.runtimeAnimatorController == null)
                {
                    Debug.Log("anim.runtimeanimationcontroller not found");

                }
                playerAnimations.anim.runtimeAnimatorController = playerAnimations.player2Controller;
            }
            else
            {
                Debug.Log("Player 1 was selected.");

            }
        }
        else
        {
            Debug.Log("Selectplayer NOT found");

        }


        pInput = GameObject.FindObjectOfType<PlayerInput>();
        pAnim = GameObject.FindObjectOfType<PlayerAnimations>();
        pHealth = player.GetComponent<Health>();
    }

    void Update()
    {
        if (paused || goalReached)
        {
            Time.timeScale = 0;
            pInput.enabled = false;
            pAnim.enabled = false;

        }
        else
        {
            Time.timeScale = 1;
            if (!pHealth.dead)
            {
                pInput.enabled = true;
                pAnim.enabled = true;
            }


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

    public void LoadNextLevel()
    {
        goalReached = false;
        paused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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

    public void ExitToMenu()
    {
        Destroy(selectPlayer.gameObject);
        paused = false;
        SceneManager.LoadScene(0);

    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
