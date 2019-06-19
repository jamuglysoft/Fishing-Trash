﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    public GameObject obj;
    float time = 0f;
    public float time_to_spawn;
    RectTransform area_spawn;
    public int first_spawn = 5;
    int trash_spawned = 0;
    public int max_trash = 1;
    public PickUp trash_collected;
    public List<Bar> bars = new List<Bar>();
    private Bar current_bar;
    private bool bars_done = false;
    public GameObject jelly_spawner;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.realtimeSinceStartup;
        area_spawn = GetComponent<RectTransform>();

        for (int i = 0; i < first_spawn; i++)
            SpawnTrash();

        current_bar = bars[0];
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
    public void UpdateBar()
    {
        if (!bars_done && current_bar.TrashPicked())
        {
            if (current_bar.IsMiddle())
                MiddleEvents();
            NextBar();
        }
    }
    public void MiddleEvents()
    {
        if (current_bar == bars[0])
        {
            Instantiate(jelly_spawner);
        }
        else if (current_bar == bars[1])
        {
            //posar spawn sharks 

        }
    }
    public void NextBar()
    {
        if (current_bar == bars[0])
        {
            //ability 1 spawn

            current_bar = bars[1];
        }
        else if (current_bar == bars[1])
        {
            //posar ability 2

            current_bar = bars[2];
        }
        else if (current_bar == bars[2])
        {
            //boss

            bars_done = true;
        }
    }
}
