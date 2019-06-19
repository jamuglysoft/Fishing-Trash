using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : MonoBehaviour
{
    public float max_up = 1f;
    public float min_up = -1f;
    private bool go_up = true;
    public float speed = 1f;
    public int life = 0;

    public Transform player;
    private Vector3 to_go;
    private BoxCollider2D coll;

    private Vector3 init_pos;
    private bool die = false;
    private SpriteRenderer sprite_render;

    // Start is called before the first frame update
    void Start()
    {
        init_pos = transform.position;

        sprite_render = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }
    ~Jellyfish()
    {
        GameObject.Find("JellySpawner").GetComponent<JellySpawner>().active_jelly--;
    }
    // Update is called once per frame
    void Update()
    {
        if (!die)
        {
            if (go_up)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
                if (transform.position.y >= init_pos.y + max_up)
                    go_up = !go_up;
            }
            else
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
                if (transform.position.y <= init_pos.y + min_up)
                    go_up = !go_up;
            }

            to_go = player.position - transform.position;
            transform.Translate(to_go.normalized * 0.02f);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 20 * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            life-=collision.gameObject.GetComponent<laser>().damage;
            if (life <= 0)
            {
                die = true;
                Destroy(coll.gameObject.GetComponent<BoxCollider2D>());
                StartCoroutine(Die());
            }
        }
    }
    IEnumerator Die()
    {
        float alpha = 1.0F;
        for (; ; )
        {
            alpha -= 0.05F;
            if (alpha <= 0)
            {
                break;
            }
            sprite_render.color = new Color(sprite_render.color.r, sprite_render.color.g, sprite_render.color.b, alpha);
            yield return null;
        }
        Destroy(this);
    }
}
