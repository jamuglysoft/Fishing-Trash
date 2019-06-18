using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesMovement : MonoBehaviour
{

    private ParticleSystem particles;

    public GameObject player = null;

    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position - player.transform.right*1.25f;
    }
}
