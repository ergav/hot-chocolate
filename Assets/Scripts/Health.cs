using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public Image[] healthUI;

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
        }
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

    }
}
