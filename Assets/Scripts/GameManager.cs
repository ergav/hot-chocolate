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

        pInput = GameObject.FindObjectOfType<PlayerInput>();
        pAnim = GameObject.FindObjectOfType<PlayerAnimations>();
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
            pInput.enabled = true;
            pAnim.enabled = true;

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
