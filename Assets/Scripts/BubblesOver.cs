using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubblesOver : MonoBehaviour
{
    public GameObject playBubble;
    private GameObject buble;

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

    public void SetBubble()
    {
        buble = Instantiate(playBubble);
        GetComponent<Text>().color = new Color(255f / 255.0f, 120f / 255.0f, 0f / 255.0f);
    }

    public void DestroyBubble()
    {
        Destroy(buble);
        GetComponent<Text>().color = Color.white;
    }
}
