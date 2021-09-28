using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator anim;

    Player player;

    [HideInInspector]public bool facingRight = true;

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
        }
    }

    void Update()
    {
        anim.SetBool("facingRight", facingRight);

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

        
    }
}
