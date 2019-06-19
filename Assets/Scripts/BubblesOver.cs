using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubblesOver : MonoBehaviour
{
    public GameObject playBubble;
    private GameObject buble;
    public AudioSource hover_sfx_source;
    public AudioClip hover_sfx;

    //private void Update()
    //{
    //    if (IsHighlighted())
    //    {
    //        SetBubble();
    //    }
    //    else
    //    {
    //        DestroyBubble();
    //    }
    //}
    private void Start()
    {
        //GetComponent<Button>().Select();
        hover_sfx_source.clip = hover_sfx;

    }


    public void SetBubble()
    {
        buble = Instantiate(playBubble);
        GetComponent<Text>().color = new Color(255f / 255.0f, 120f / 255.0f, 0f / 255.0f);
        hover_sfx_source.Play();
    }

    public void DestroyBubble()
    {
        Destroy(buble);
        GetComponent<Text>().color = Color.white;
    }
}
