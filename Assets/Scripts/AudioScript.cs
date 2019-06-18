using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{

    static AudioSource audioSrc;

    public static AudioClip laser_sfx;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        laser_sfx = Resources.Load<AudioClip>("Laser");
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
        }
    }

}
