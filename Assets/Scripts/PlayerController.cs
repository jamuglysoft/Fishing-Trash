using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    private Animator anim;
    private Rigidbody2D rigid_body;

    public float speed = 0.0F;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid_body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float axis_x = Input.GetAxis("Horizontal");
        float axis_y = Input.GetAxis("Vertical");

        if (axis_x != 0)
        {
            rigid_body.velocity = new Vector2(axis_x * speed, rigid_body.velocity.y);
        }
        if (axis_y != 0)
        {
            rigid_body.velocity = new Vector2(rigid_body.velocity.x, axis_y * speed);
        }
    }
}
