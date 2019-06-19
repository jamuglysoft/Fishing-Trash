using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellySpawner : MonoBehaviour
{

    public GameObject obj;
    float time = 0f;
    public float time_to_spawn;
    RectTransform area_spawn;
    public int first_spawn = 5;
    int jelly_spawned = 0;
    public int max_jelly = 1;
    GameObject camera;
    [HideInInspector]
    public int active_jelly = 0;

    // Start is called before the first frame update
    void Start()
    {
        time = Time.realtimeSinceStartup;
        area_spawn = GetComponent<RectTransform>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        StartCoroutine("Spawn");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup - time >= time_to_spawn && active_jelly <= max_jelly)
        {
            SpawnJelly();
            time = Time.realtimeSinceStartup;
        }
    }
    private void SpawnJelly()
    {
        GameObject instance = Instantiate(obj, transform);
        Vector3 pos = new Vector3(Random.Range(area_spawn.rect.xMin, area_spawn.rect.xMax),
            Random.Range(area_spawn.rect.yMin, area_spawn.rect.yMax), instance.transform.position.z) + area_spawn.transform.position;
        if (pos.x > camera.transform.position.x && pos.x < camera.transform.position.x + 10)
            pos.x += 15;
        instance.transform.position = new Vector3(
            pos.x,
            pos.y,
            pos.z);
        Vector3 viewPos = GameObject.Find("Main Camera").GetComponent<Camera>().WorldToViewportPoint(instance.transform.position);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            DestroyImmediate(instance);
        }
        jelly_spawned++;
        active_jelly++;
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < first_spawn; i++)
        {
            SpawnJelly();
            yield return null;
        }
    }
}

