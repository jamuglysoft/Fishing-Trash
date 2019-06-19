using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public enum PlayerStates
    {
        IDLE = 1,
        MOVE = 2,
        FLASHING = 3,
        DEAD=4,

        NONE
    }

    private bool flashing = false;
    public bool ability1 = false;
    public bool ability2 = false;

    public float flash_cooldown = 0.0F;
    public Vector2 flash_force;
    private Vector2 flash_axis;
    private float flash_time = 0.0F;
    private float time_to_die = 0.0f;
    private bool dead = false;

    public PlayerStates player_state = PlayerStates.IDLE;

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

    public float seconds_between_laser = 0.0f;

    private bool grow = false;

    private float laser_timer = 0.0f;

    bool m_isAxisInUse = false;

    public GameObject laser;

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
        Debug.Log(Input.GetAxisRaw("Fire1"));
        Debug.Log(m_isAxisInUse);

        if (Input.GetAxisRaw("Fire1") != 0f)
        {
            if (m_isAxisInUse == false&&(Time.realtimeSinceStartup-laser_timer>= seconds_between_laser))
            {
                laser_timer = Time.realtimeSinceStartup;
                GameObject instant = Instantiate(laser);
                instant.transform.position = transform.position + transform.right * 0.75f;
                instant.transform.up = transform.right;
                AudioScript.PlaySound("laser");
                m_isAxisInUse = true;
            }
        }
        if (Input.GetAxisRaw("Fire1") == 0f)
        {
            m_isAxisInUse = false;
        }

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

        if ((Input.GetKeyDown(KeyCode.Joystick1Button5) || Input.GetKeyDown(KeyCode.LeftShift))  && !flashing &&  axis_x!=0 && ability1)
        {
            player_state = PlayerStates.FLASHING;
            flash_axis = new Vector2(axis_x, axis_y);
            rigid_body.AddForce(new Vector2(flash_axis.x * flash_force.x, flash_axis.y * flash_force.y), ForceMode2D.Impulse);
            flashing = true;
            flash_time = Time.realtimeSinceStartup;
            AudioScript.PlaySound("dash");
        }
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
            case PlayerStates.FLASHING:
                if (!flashing)
                {
                    player_state = PlayerStates.MOVE;
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
                rigid_body.velocity = new Vector2(axis_x * speed * water_friction, axis_y * speed * water_friction);
                break;
            case PlayerStates.MOVE:
                rigid_body.velocity = new Vector2(axis_x * speed * water_friction, axis_y * speed * water_friction);
                float angle = Mathf.Atan2(axis_y, axis_x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                rotation = angle;
                break;
            case PlayerStates.FLASHING:
                if (flash_time < Time.realtimeSinceStartup - flash_cooldown)
                {
                    flashing = false;
                }
                break;
            case PlayerStates.DEAD:
                rigid_body.gravityScale = 2;
                if (Time.realtimeSinceStartup - time_to_die >= 5 && dead)
                {
                    SceneManager.LoadScene(("MainMenu"), LoadSceneMode.Single);
                }
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //transform.lossyScale{ };
        if (collision.gameObject.CompareTag("PickUp"))
        {
            AudioScript.PlaySound("pick_trash");
            if (grow == false)
            {
                StartCoroutine(LerpScale(0.5f));
            }
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            player_state = PlayerStates.DEAD;
        }
    }

    private IEnumerator LerpScale(float time)
    {
        grow = true;
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
        grow = false;
    }

    private void PlayerDead()
    {
        time_to_die = Time.realtimeSinceStartup;
        sprite.flipY = !sprite.flipY;
        dead = true;
    }
}
