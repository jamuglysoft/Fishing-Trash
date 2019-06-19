using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    public float rotation_angle;

    public float min_angle_speed = 0.5f;
    public float max_angle_speed = 3f;

    SpriteRenderer sprite;

    public Sprite[] basurillas;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direction.Normalize();
        speed = Random.Range(0.1f, 0.7f);
        rotation_angle = Random.Range(min_angle_speed, max_angle_speed);
        if(Random.Range(0,1) == 1)
        {
            rotation_angle *= -1;
        }

        int id = Random.Range(0, basurillas.Length);
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = basurillas[id];

        StartCoroutine("Fade");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        transform.Rotate(Vector3.forward, rotation_angle * Time.deltaTime);
    }

    IEnumerator Fade()
    {
        for (float i = 0; i <= 1f; i += 0.1f)
        {
            transform.localScale = new Vector3(i, i, 1);
            yield return null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MapLimit"))
        {
            direction = -transform.position;
            direction.Normalize();
        }
    }
}
