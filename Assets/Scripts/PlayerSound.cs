using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] hurtSounds, deathSounds, jumpSounds;

    int rng;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void Jump()
    {
        rng = Random.Range(0, jumpSounds.Length);
        audioSource.PlayOneShot(jumpSounds[rng]);
    }

    public void Hurt()
    {
        rng = Random.Range(0, hurtSounds.Length);
        audioSource.PlayOneShot(hurtSounds[rng]);
    }

    public void Death()
    {
        rng = Random.Range(0, deathSounds.Length);
        audioSource.PlayOneShot(deathSounds[rng]);
    }
}
