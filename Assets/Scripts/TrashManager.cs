using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrashManager : MonoBehaviour
{
    public GameObject obj;
    float time = 0f;
    public float time_to_spawn;
    RectTransform area_spawn;
    public int first_spawn = 5;
    public int max_trash = 1;
    public PickUp trash_collected;
    public List<Bar> bars = new List<Bar>();
    private Bar current_bar;
    private bool bars_done = false;
    public GameObject jelly_spawner;
    public GameObject ability1;
    public GameObject ability2;
    public GameObject shark;
    public GameObject big_trash_manager;
    private AudioSource AudioSource;

    public AudioClip song1;
    public AudioClip song2;
    public AudioClip song3;
    public AudioClip song4;

    private PauseMenu pause;

    public Camera cam;
    [HideInInspector] public int trash_spawned = 0;

    private bool is_spawned_bar = false;

    private void Start()
    {
        current_bar = bars[0];
        time = Time.realtimeSinceStartup;
        area_spawn = GetComponent<RectTransform>();

        AudioSource = GetComponent<AudioSource>();
        AudioSource.clip = song1;
        AudioSource.Play();

        for (int i = 0; i < first_spawn; i++)
            SpawnTrash();

        GameObject canvas = GameObject.Find("Canvas");
        pause = canvas.GetComponent<PauseMenu>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!pause.GetPause())
            if (Time.realtimeSinceStartup - time >= time_to_spawn && trash_spawned - trash_collected.number_trash <= max_trash)
            {
                if (!obj.CompareTag("BigTrash") && trash_spawned - trash_collected.number_trash <= max_trash)
                {
                    SpawnTrash();
                    time = Time.realtimeSinceStartup;
                }
                else if (trash_spawned < max_trash)
                {
                    SpawnTrash();
                    time = Time.realtimeSinceStartup;
                }
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
            NextBar();
            is_spawned_bar = false;
        }
        if (current_bar.IsMiddle() && !is_spawned_bar)
        {
            MiddleEvents();
            is_spawned_bar = true;
        }
    }
    public void MiddleEvents()
    {
        if (current_bar == bars[0])
        {
            Instantiate(jelly_spawner);
            AudioSource.Stop();
            AudioSource.clip = song2;
            AudioSource.Play();
        }
        else if (current_bar == bars[1])
        {
            //posar spawn sharks
            Instantiate(shark);
            AudioSource.Stop();
            AudioSource.clip = song3;
            AudioSource.Play();
        }
    }
    public void NextBar()
    {
        if (current_bar == bars[0])
        {
            Instantiate(ability1);

            current_bar = bars[1];
        }
        else if (current_bar == bars[1])
        {
            Instantiate(ability2);
            Instantiate(big_trash_manager);
            cam.orthographicSize = 8f;
            current_bar = bars[2];
        }
        else if (current_bar == bars[2])
        {
            //boss
            AudioSource.Stop();
            AudioSource.clip = song4;
            AudioSource.Play();
            bars_done = true;
            SceneManager.LoadScene("Win", LoadSceneMode.Single);
        }
    }
}
