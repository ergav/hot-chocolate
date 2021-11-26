using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator anim;

    Player player;

    Health health;

    public RuntimeAnimatorController player1Controller, player2Controller;

    [HideInInspector]public bool facingRight = true;
    [HideInInspector]public bool hurt;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        if (anim == null)
        {
            anim = GetComponent<Animator>();
            if (anim == null)
            {
                anim = GetComponentInChildren<Animator>();
            }

            player = GetComponent<Player>();

            health = GetComponent<Health>();

            spriteRenderer = GetComponent<SpriteRenderer>();

            if (spriteRenderer == null)
            {
                spriteRenderer = GetComponentInChildren<SpriteRenderer>();

            }
        }
    }

    void Update()
    {
        anim.SetBool("facingRight", facingRight);
        anim.SetBool("hurt", hurt);

        float setFaceDir = Input.GetAxisRaw("Horizontal");

        if (!player.wallSliding)
        {
            if (setFaceDir > 0)
            {
                facingRight = true;
            }
            else if (setFaceDir < 0)
            {
                facingRight = false;
            }
        }

        if (health.currentHealth <= health.lowHealth)
        {
            hurt = true;
        }
        else
        {
            hurt = false;
        }



    }

    public void Death()
    {
        if (!facingRight)
        {
            spriteRenderer.flipX = true;
        }
        anim.SetTrigger("Death");
    }
}
