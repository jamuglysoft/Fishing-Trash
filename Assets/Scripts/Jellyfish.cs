using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : MonoBehaviour
{
    public float max_up;
    public float min_up;
    private bool go_up = true;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (go_up)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            if (transform.position.y >= max_up)
                go_up = !go_up;
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            if (transform.position.y <= min_up)
                go_up = !go_up;
        }
    }
}
