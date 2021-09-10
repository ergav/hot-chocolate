using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public int currentHealth = 4;
    public int maxHealth = 4;

    bool dead;

    public Image HealthUI;
    public Sprite[] healthSprites;

    void Start()
    {
        
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
        currentHealth -= amount;
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
        }
    }
}
