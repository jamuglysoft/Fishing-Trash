using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public float speed = 5f;
    private float time_destroy = 2f;
    private float time;
    public int damage = 0;

    // Start is called before the first frame update
    void Start()
    {
        time = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (Time.realtimeSinceStartup - time >= time_destroy)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
