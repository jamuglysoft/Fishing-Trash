using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesOver : MonoBehaviour
{
    public GameObject playBubble;
    private GameObject buble;

    public void SetBubble()
    {
        buble = Instantiate(playBubble);
    }

    public void DestroyBubble()
    {
        Destroy(buble);
    }
}
