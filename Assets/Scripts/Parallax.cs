using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Vector3 init_position;
    public Camera cam;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        init_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cam.transform.position * speed + init_position;
    }
}
