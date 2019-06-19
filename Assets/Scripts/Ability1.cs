using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability1 : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    public float rotation_angle;

    public float min_angle_speed = 0.5f;
    public float max_angle_speed = 3f;

    public AudioClip buble_ability_sfx;
    public AudioSource buble_ability_sfx_source;

    // Start is called before the first frame update
    void Start()
    {;
        buble_ability_sfx_source.clip = buble_ability_sfx;
        
        rotation_angle = Random.Range(min_angle_speed, max_angle_speed);
        if (Random.Range(0, 1) == 1)
        {
            rotation_angle *= -1;
        }

        StartCoroutine("Fade");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, rotation_angle * Time.deltaTime);
    }

    IEnumerator Fade()
    {
        for (float i = 0; i <= 3.5f; i += 0.1f)
        {
            transform.localScale = new Vector3(i, i, 1);
            yield return null;
        }
    }
}
