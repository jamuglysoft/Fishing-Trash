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
    private PolygonCollider2D collision;

    public float speed = 0.0F;
    public float water_friction = 0.0F;

    [HideInInspector]
    public float rotation = 0.0F;

    private float axis_x = 0.0F;
    private float axis_y = 0.0F;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid_body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        collision = GetComponent<PolygonCollider2D>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //transform.lossyScale{ };

        StartCoroutine(LerpScale(0.5f));
    }

    private IEnumerator LerpScale(float time)
    {
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = originalScale + new Vector3( 1.0f, 1.0f, 1.0f);
        float OriginalTime = time;
        float halftime = time / 2;

        while (time>0.0f)
        {
            time -= Time.deltaTime;
            if (time > halftime)
            {
                transform.localScale = Vector3.Lerp(targetScale, originalScale, time / OriginalTime);
            }
            else if (time <= halftime)
            {
                transform.localScale = Vector3.Lerp(originalScale, targetScale, time / OriginalTime);
            }
            yield return null;
        }   
    }

}
