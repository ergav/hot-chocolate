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

    public AudioSource audioSource;

    private void Start()
    {
        mainSprite = GetComponent<Image>();
        anim = GetComponent<Animator>();

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

    }

    public void ChangeTheSprite()
    {
        mainSprite.sprite = spriteToChangeTo;
        if (audioSource != null && !stop)
        {
            audioSource.Play();
        }
        stop = true;


    }

    private void Update()
    {
        anim.SetBool("Stop", stop);

    }
}
