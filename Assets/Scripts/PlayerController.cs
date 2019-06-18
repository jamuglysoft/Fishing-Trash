using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    enum PlayerStates
    {
        IDLE = 1,
        MOVE = 2,

        NONE
    }

    private PlayerStates player_state = PlayerStates.IDLE;

    private Animator anim;
    private Rigidbody2D rigid_body;
    private SpriteRenderer sprite;

    public float speed = 0.0F;
    public float water_friction = 0.0F;
    private float rotation = 0.0F;

    private float axis_x = 0.0F;
    private float axis_y = 0.0F;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid_body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        anim.SetInteger("State", (int)player_state);

        if (transform.rotation.eulerAngles.z > 90.0F && transform.rotation.eulerAngles.z < 270F)
        {
            sprite.flipY = true;
        }
        else if (transform.rotation.eulerAngles.z < 90.0F && transform.rotation.eulerAngles.z > -90.0F)
        {
            sprite.flipY = false;
        }
        GetInput();
        ChangeState();
    }

    private void FixedUpdate()
    {
        PerformActions();
    }
    void GetInput()
    {
        axis_x = Input.GetAxis("Horizontal");
        axis_y = Input.GetAxis("Vertical");
    }

    void ChangeState()
    {
        switch (player_state)
        {
            case PlayerStates.IDLE:
                if (axis_x != 0 || axis_y != 0)
                {
                    player_state = PlayerStates.MOVE;
                }
                break;
            case PlayerStates.MOVE:
                if (axis_x == 0 && axis_y == 0)
                {
                    player_state = PlayerStates.IDLE;
                }
                break;
            default:
                break;
        }
    }

    void PerformActions()
    {
        switch (player_state)
        {
            case PlayerStates.IDLE:
                rigid_body.velocity = new Vector2(axis_x * water_friction, axis_y * water_friction);
                break;
            case PlayerStates.MOVE:
                rigid_body.velocity = new Vector2(axis_x * speed * water_friction, axis_y * speed * water_friction);
                float angle = Mathf.Atan2(axis_y, axis_x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                rotation = angle;
                break;
            default:
                break;
        }
    }
}
