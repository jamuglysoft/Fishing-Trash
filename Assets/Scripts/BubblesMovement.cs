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

        ParticleSystem.MainModule main = particles.main;
        ParticleSystem.EmissionModule emission = particles.emission;

        if (player.GetComponent<PlayerController>().player_state == PlayerController.PlayerStates.FLASHING)
        {
           
            main.maxParticles = 30;
            emission.rateOverTime = 60;
        }
        else
        {
            main.maxParticles = 5;
            emission.rateOverTime = 10;
        }

        Debug.Log(main.maxParticles);

    }
}
