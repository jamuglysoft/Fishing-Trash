﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public int number_trash;
   

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
            GameObject.Find("TrashManager").GetComponent<TrashManager>().UpdateBar();
            GetComponentInParent<PlayerController>().PickUpCollision();
            Destroy(collision.gameObject);
            number_trash++;
            
        }
        if (collision.CompareTag("Ability1"))
        {
            Destroy(collision.gameObject);
            GameObject.Find("Player").GetComponent<PlayerController>().ability1 = true;
            AudioScript.PlaySound("ability1");

        }
        if (collision.CompareTag("Ability2"))
        {
            Destroy(collision.gameObject);
            GameObject.Find("Player").GetComponent<PlayerController>().ability2 = true;
            AudioScript.PlaySound("ability2");

        }
    }
}
