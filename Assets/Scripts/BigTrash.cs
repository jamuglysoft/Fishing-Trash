using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTrash : Trash
{
    public GameObject little_trash;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            Destroy(collision.gameObject);
            GameObject inst;
            for (int i = 0; i < 3; i++)
            {
                inst = Instantiate(little_trash);
                inst.transform.position = transform.position;
            }
            GetComponentInParent<TrashManager>().trash_spawned--;
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            // Quitale vida al player
        }
    }
}
