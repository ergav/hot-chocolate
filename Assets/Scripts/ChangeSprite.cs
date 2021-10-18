using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeSprite : MonoBehaviour
{
    public Sprite spriteToChangeTo;
    Image mainSprite;
    Animator anim;
    bool stop;

    private void Start()
    {
        mainSprite = GetComponent<Image>();
        anim = GetComponent<Animator>();

    }

    public void ChangeTheSprite()
    {
        mainSprite.sprite = spriteToChangeTo;
        stop = true;
    }

    private void Update()
    {
        anim.SetBool("Stop", stop);

    }
}
