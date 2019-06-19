using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public GameObject obj;
    public PickUp ability1_collected;
    public PickUp ability2_collected;

    // Start is called before the first frame update
    void Start()
    {
        SpawnAbility1();
        SpawnAbility2();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SpawnAbility1()
    {
        GameObject instance = Instantiate(obj, transform);  
    }

    private void SpawnAbility2()
    {
        GameObject instance = Instantiate(obj, transform);  
    }
}
