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

        if (health.currentHealth <= 1)
        {
            hurt = true;
        }
        else
        {
            hurt = false;
        }

    }
}
