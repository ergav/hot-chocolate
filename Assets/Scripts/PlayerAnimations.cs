using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator anim;

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
        }
    }

    void Update()
    {
        anim.SetBool("facingRight", facingRight);

        float setFaceDir = Input.GetAxisRaw("Horizontal");

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
