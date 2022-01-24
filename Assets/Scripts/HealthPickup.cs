using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] int amountToHeal = 2;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Health health = collision.GetComponent<Health>();
            health.HealDamage(amountToHeal);
            Destroy(gameObject);
        }
    }
}
