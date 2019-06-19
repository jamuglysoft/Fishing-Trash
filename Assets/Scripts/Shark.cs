using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    public float speed = 5f;
    public int life = 0;

    public GameObject shark;

    public bool dead = false;

    private SpriteRenderer sprite;
    private Rigidbody2D rigid_body;
    private BoxCollider2D coll;
    private Animator anim;


    float time_to_die = 0.0f;

    BoxCollider2D a;
    BoxCollider2D b;
    BoxCollider2D c;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rigid_body = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();

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
            transform.position = new Vector3(transform.position.x, Random.Range(-3, 16), transform.position.z);
        }

        else if (collision.gameObject.CompareTag("Laser"))
        {
            life -= collision.gameObject.GetComponent<laser>().damage;
            if (life <= 0)
            {
                dead = true;
                time_to_die = Time.realtimeSinceStartup;
                sprite.flipY = true;
                anim.Play("Shark_Dead");
                rigid_body.gravityScale = 0.5f;
                speed = 0;
                Destroy(coll.gameObject.GetComponent<BoxCollider2D>());
            }
        }
    }

    private void Die()
    {
        if(Time.realtimeSinceStartup-time_to_die>=3)
        {
            Destroy(gameObject);
        }
    }
}
