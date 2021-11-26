using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    Rigidbody2D rb;
    public bool falling;
    [SerializeField] float fallSpeed = 20;
    [SerializeField] float despawnTime = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!falling)
        {
            //rb.isKinematic = true;
            //rb.simulated = false;

            transform.Translate(Vector3.zero);
        }
        else
        {
            //rb.isKinematic = false;
            //rb.simulated = true;

           
            transform.Translate(0, -fallSpeed * Time.deltaTime, 0);
            
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
