using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    List<GameObject> list;
    public GameObject obj;
    float time = 0f;
    public float time_to_spawn;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.realtimeSinceStartup - time >= time_to_spawn)
        {
            GameObject instance = Instantiate(obj);
            instance.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-5, 5), instance.transform.position.z);
            time = Time.realtimeSinceStartup;
        }
    }
}
