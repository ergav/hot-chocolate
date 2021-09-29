using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectAnimations : MonoBehaviour
{
    Animator anim;

    public bool mouseHover;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("MouseHover", mouseHover);
    }

    public void MouseHoverEnter()
    {
        mouseHover = true;
    }

    public void MouseHoverExit()
    {
        mouseHover = false;
    }
}
