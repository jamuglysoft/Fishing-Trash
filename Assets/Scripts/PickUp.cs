using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public Text text_trash;
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
            Destroy(collision.gameObject);
            number_trash++;
            text_trash.text = "Trash: " + number_trash.ToString();
        }
    }
}
