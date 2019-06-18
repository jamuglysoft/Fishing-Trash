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
    public int first_spawn = 5;
    int trash_spawned = 0;
    public int max_trash = 1;
    public PickUp trash_collected;

    // Start is called before the first frame update
    void Start()
    {
        time = Time.realtimeSinceStartup;
        area_spawn = GetComponent<RectTransform>();

        for (int i = 0; i < first_spawn; i++)
            SpawnTrash();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.realtimeSinceStartup - time >= time_to_spawn && trash_spawned - trash_collected.number_trash <= max_trash)
        {
            SpawnTrash();
            time = Time.realtimeSinceStartup;
        }
    }

    private void SpawnTrash()
    {
        GameObject instance = Instantiate(obj, transform);
        instance.transform.position = new Vector3(
            Random.Range(area_spawn.rect.xMin, area_spawn.rect.xMax),
            Random.Range(area_spawn.rect.yMin, area_spawn.rect.yMax),
            instance.transform.position.z) + area_spawn.transform.position;
        trash_spawned++;
    }
}
