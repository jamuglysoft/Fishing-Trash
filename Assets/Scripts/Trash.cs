using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    public float rotation_angle;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direction.Normalize();
        speed = Random.Range(0.1f, 0.7f);
        rotation_angle = Random.Range(0.5f, 3f);
        if(Random.Range(0,1) == 1)
        {
            rotation_angle *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        transform.Rotate(Vector3.forward, rotation_angle * Time.deltaTime);
    }
}
