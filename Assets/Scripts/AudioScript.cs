﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    static AudioSource audioSrc;

    public static AudioClip laser_sfx;
    public static AudioClip picktrash_sfx;
    public static AudioClip dash_sfx;
    public static AudioClip pick_up_ability1_sfx;
    public static AudioClip pick_up_ability2_sfx;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        laser_sfx = Resources.Load<AudioClip>("Laser");
        picktrash_sfx = Resources.Load<AudioClip>("Pick_Trash");
        dash_sfx = Resources.Load<AudioClip>("Dash");
        pick_up_ability1_sfx = Resources.Load<AudioClip>("Glug");
        pick_up_ability2_sfx = Resources.Load<AudioClip>("Glug");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "laser":
                audioSrc.PlayOneShot(laser_sfx);
                break;
            case "pick_trash":
                audioSrc.PlayOneShot(picktrash_sfx);
                break;
            case "dash":
                audioSrc.PlayOneShot(dash_sfx);
                break;
            case "ability1":
                audioSrc.PlayOneShot(pick_up_ability1_sfx);
                break;
            case "ability2":
                audioSrc.PlayOneShot(pick_up_ability2_sfx);
                break;
        }
    }

}
