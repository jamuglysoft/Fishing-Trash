﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public Text text_trash;
    public int number_trash;
    bool ability1;
    bool ability2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PickUp"))
        {
            Destroy(collision.gameObject);
            number_trash++;
            text_trash.text = "Trash: " + number_trash.ToString();
            GameObject.Find("TrashManager").GetComponent<TrashManager>().UpdateBar();
        }
        if (collision.CompareTag("Ability1"))
        {
            Destroy(collision.gameObject);
            ability1 = true;
        }
        if (collision.CompareTag("Ability2"))
        {
            Destroy(collision.gameObject);
            ability2 = true;
        }
    }
}
