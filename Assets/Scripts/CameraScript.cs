using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject object_to_follow = null;
    public float smoth_time = 0.0F;
    public GameObject cam_limits;
    public Transform camera_pivot;

    private float width;
    private float height;
    private Camera cam;
    private Vector2 off_set_pivot_cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();

        off_set_pivot_cam.x = camera_pivot.position.x - transform.position.x;
        off_set_pivot_cam.y = camera_pivot.position.y - transform.position.y;


        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;

    }

    // Update is called once per frame
    void Update()
    {
        camera_pivot.transform.position = new Vector3(Mathf.SmoothStep(camera_pivot.transform.position.x, object_to_follow.transform.position.x - 10.5F, smoth_time), Mathf.SmoothStep(camera_pivot.transform.position.y, object_to_follow.transform.position.y + 7.014F, smoth_time), camera_pivot.transform.position.z);
        //camera_pivot.position = new Vector3(Mathf.SmoothStep(camera_pivot.position.x + off_set_pivot_cam.x, object_to_follow.transform.position.x, smoth_time), Mathf.SmoothStep(camera_pivot.position.y + off_set_pivot_cam.y, object_to_follow.transform.position.y, smoth_time), camera_pivot.position.z);
        //camera_pivot.position = new Vector3(transform.position.x + off_set_pivot_cam.x, transform.position.y + off_set_pivot_cam.y, camera_pivot.position.z);
        //transform.position = new Vector3(Mathf.SmoothStep(transform.position.x, object_to_follow.transform.position.x, smoth_time), Mathf.SmoothStep(transform.position.y, object_to_follow.transform.position.y, smoth_time), transform.position.z);
        if (camera_pivot.transform.position.x < cam_limits.transform.position.x)
        {
            camera_pivot.transform.position = new Vector3(cam_limits.transform.position.x, camera_pivot.transform.position.y, camera_pivot.transform.position.z);
        }
        if (camera_pivot.transform.position.x + width > cam_limits.GetComponent<BoxCollider2D>().bounds.size.x)
        {
            camera_pivot.transform.position = new Vector3(cam_limits.GetComponent<BoxCollider2D>().bounds.size.x - width, camera_pivot.transform.position.y, camera_pivot.transform.position.z);
        }
        if (camera_pivot.transform.position.y > cam_limits.transform.position.y)
        {
            camera_pivot.transform.position = new Vector3(camera_pivot.transform.position.x, cam_limits.transform.position.y, camera_pivot.transform.position.z);
        }
        if (camera_pivot.transform.position.y < cam_limits.transform.position.y - 26.2F)
        {
            camera_pivot.transform.position = new Vector3(camera_pivot.transform.position.x, cam_limits.transform.position.y - 26.2F, camera_pivot.transform.position.z);
        }
    }
}
