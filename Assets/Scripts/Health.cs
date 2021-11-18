using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public int currentHealth = 4;
    public int maxHealth = 4;
    public int lowHealth = 1;

    [SerializeField] float iframeTime = 1;

    bool dead;
    bool iframe;

    public Image HealthUI;
    public Sprite[] healthSprites;

    PlayerSound playerSound;

    void Start()
    {
        playerSound = GetComponent<PlayerSound>();
    }

    void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Death();
        }

        HealthUI.sprite = healthSprites[currentHealth];
    }

    public void TakeDamage(int amount)
    {
        if (!iframe)
        {
            currentHealth -= amount;
            iframe = true;
            StartCoroutine(IFrameTimer());
            if (playerSound != null && currentHealth > 0)
            {
                playerSound.Hurt();
            }
        }
    }

    public void HealDamage(int amount)
    {
        currentHealth += amount;
    }

    public void Death()
    {
        if (!dead)
        {
            Debug.Log("You are dead, not big surprise!");
            dead = true;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().PlayerDeath();

            if (playerSound != null)
            {
                playerSound.Death();
            }

            Destroy(this.gameObject);
        }
    }

    IEnumerator IFrameTimer()
    {
        yield return new WaitForSeconds(iframeTime);
        iframe = false;
        //if (noFlicker)
        //{
        //    noFlicker = false;
        //}
    }
}
