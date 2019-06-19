using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    public float speed = 5f;
    public int life = 0;

    BoxCollider2D a;
    BoxCollider2D b;
    BoxCollider2D c;
    // Start is called before the first frame update
    void Start()
    {
        List<BoxCollider2D> list = new List<BoxCollider2D>();
        GetComponentsInParent<BoxCollider2D>(true,list);
        a = list[0];
        b = list[1];
        c = list[2];

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("SharkCollider") && (collision == a || collision == b || collision == c)){
            transform.localScale = new Vector3(transform.localScale.x*-1, 1, 1);
            speed *= -1;
        }

        else if (collision.gameObject.CompareTag("Laser"))
        {
            life -= collision.gameObject.GetComponent<laser>().damage;
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
