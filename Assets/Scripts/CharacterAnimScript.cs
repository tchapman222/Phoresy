using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used to animate all my characters.

public class CharacterAnimScript : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    AudioSource characterAudio;
    public AudioClip clip0;
    public AudioClip clip1;
    public AudioClip clip2;
    private int teddyCounter;
    private int cowboyCounter;
    public enum Character
    {
        Cowboy,
        Teddy,
        Jaimie
    }

    public Character myCharacter;
    void Start()
    {
        anim = GetComponent<Animator>();
        characterAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (myCharacter == Character.Cowboy)
        {
            changeClip(cowboyCounter);
            cowboyCounter++;
        }
        if (myCharacter == Character.Teddy)
        {
            changeClip(teddyCounter);
            teddyCounter++;
        }
        if (characterAudio.isPlaying == false)
        {
            anim.SetBool("isTalking", true);
            characterAudio.Play();
        }
    }

    private void Update()
    {
        if (characterAudio.isPlaying == false)
        {
            anim.SetBool("isTalking", false);
        }
    }

    private void changeClip(int clipCounter)
    {
        
        switch (clipCounter)
        {
            case 0:
                characterAudio.clip = clip0;
                break;
            case 1:
                characterAudio.clip = clip1;
                break;
            default:
                characterAudio.clip = clip2;
                break;
        }
    }
}
