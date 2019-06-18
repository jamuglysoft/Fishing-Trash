using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    List<GameObject> list;
    public GameObject obj;
    float time = 0f;
    public float time_to_spawn;
    RectTransform area_spawn;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.realtimeSinceStartup;
        area_spawn = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.realtimeSinceStartup - time >= time_to_spawn)
        {
            GameObject instance = Instantiate(obj,transform);
            instance.transform.position = new Vector3(
                Random.Range(area_spawn.rect.xMin, area_spawn.rect.xMax), 
                Random.Range(area_spawn.rect.yMin, area_spawn.rect.yMax), 
                instance.transform.position.z) + area_spawn.transform.position;
            time = Time.realtimeSinceStartup;
        }
    }
}
