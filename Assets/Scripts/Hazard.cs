using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : RaycastController
{
    public LayerMask hurtMask;

    public bool destroyOnCollission;

    public int damage = 1;

    public bool hurtUp = true, hurtDown = true, hurtLeft = true, hurtRight = true;

    void Start()
    {
        base.Start();

    }

    void Update()
    {
        UpdateRaycastOrigins();

        if (hurtUp)
        {
            CollissionsUp();
        }
        if (hurtDown)
        {
            CollissionsDown();
        }
        if (hurtLeft)
        {
            CollissionsLeft();
        }
        if (hurtRight)
        {
            CollissionsRight();
        }


    }

    void CollissionsUp()
    {
        float rayLength = skinWidth * 2;

        for (int i = 0; i < verticalRaycount; i++)
        {
            Vector2 rayOrigin = raycastOrigins.topLeft + Vector2.right * (verticalRaySpacing * i);

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up, rayLength, hurtMask);

            Debug.DrawRay(rayOrigin, Vector2.up * rayLength, Color.red);

            if (hit)
            {
                Health health = hit.transform.GetComponent<Health>();
                health.TakeDamage(damage);
                if (destroyOnCollission)
                {
                    Destroy(this.gameObject);
                }
                
            }
        }
    }
    void CollissionsDown()
    {
        float rayLength = skinWidth * 2;

        for (int i = 0; i < verticalRaycount; i++)
        {
            Vector2 rayOrigin = raycastOrigins.bottomLeft + Vector2.right * (verticalRaySpacing * i);

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, -Vector2.up, rayLength, hurtMask);

            Debug.DrawRay(rayOrigin, -Vector2.up * rayLength, Color.red);

            if (hit)
            {
                Health health = hit.transform.GetComponent<Health>();
                health.TakeDamage(damage);
                if (destroyOnCollission)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
    void CollissionsRight()
    {
        float rayLength = skinWidth * 2;

        for (int i = 0; i < horizontalRaycount; i++)
        {
            Vector2 rayOrigin = raycastOrigins.bottomRight + Vector2.up * (horizontalRaySpacing * i);

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right, rayLength, hurtMask);

            Debug.DrawRay(rayOrigin, Vector2.right * rayLength, Color.red);

            if (hit)
            {
                Health health = hit.transform.GetComponent<Health>();
                health.TakeDamage(damage);
                if (destroyOnCollission)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
    void CollissionsLeft()
    {
        float rayLength = skinWidth * 2;

        for (int i = 0; i < horizontalRaycount; i++)
        {
            Vector2 rayOrigin = raycastOrigins.bottomLeft + Vector2.up * (horizontalRaySpacing * i);

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, -Vector2.right, rayLength, hurtMask);

            Debug.DrawRay(rayOrigin, -Vector2.right * rayLength, Color.red);

            if (hit)
            {
                Health health = hit.transform.GetComponent<Health>();
                health.TakeDamage(damage);
                if (destroyOnCollission)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.tag == "Player")
    //    {
    //        Health health = collision.transform.GetComponent<Health>();
    //        health.TakeDamage(damage);
    //    }
    //}
}
