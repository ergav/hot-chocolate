using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public int currentHealth = 4;
    public int maxHealth = 4;

    public float iframeTime = 1;

    bool dead;
    bool iframe;

    public Image HealthUI;
    public Sprite[] healthSprites;

    Controller2D controller;

    void Start()
    {
        controller = GetComponent<Controller2D>();
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
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().StartRespawnCount();
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
