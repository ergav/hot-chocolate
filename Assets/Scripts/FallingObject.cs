using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    Rigidbody2D rb;
    public bool falling;
    public float despawnTime = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!falling)
        {
            rb.isKinematic = true;
            rb.simulated = false;
        }
        else
        {
            rb.isKinematic = false;
            rb.simulated = true;
        }
    }

    public void TriggerFall()
    {
        falling = true;
        StartCoroutine(DespawnTime());
    }

    IEnumerator DespawnTime()
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(gameObject);
    }
}
