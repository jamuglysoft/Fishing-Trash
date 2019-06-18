using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject object_to_follow = null;
    public float smoth_time = 0.0F;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(Mathf.SmoothStep(transform.position.x, object_to_follow.transform.position.x, smoth_time), Mathf.SmoothStep(transform.position.y, object_to_follow.transform.position.y, smoth_time), transform.position.z);

    }
}
