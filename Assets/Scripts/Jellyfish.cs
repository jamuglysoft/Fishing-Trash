﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : MonoBehaviour
{
    public float max_up;
    public float min_up;
    private bool go_up = true;
    public float speed;
    private Vector3 init_pos;
    // Start is called before the first frame update
    void Start()
    {
        init_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
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
    }
}
