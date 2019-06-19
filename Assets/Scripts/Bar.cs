using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{

    public int trashes_to_fill;
    private int current_trash = 0;
    private float divided_parts;
    // Start is called before the first frame update
    void Start()
    {
        divided_parts = 1f / (float)trashes_to_fill;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool TrashPicked()
    {
        current_trash++;
        transform.localScale = new Vector3(transform.localScale.x - divided_parts, transform.localScale.y, transform.localScale.z);
        if (current_trash == trashes_to_fill)
            return true;
        return false;
    }
    public bool IsMiddle()
    {
        if (transform.localScale.x <= 0.5F)
            return true;
        return false;
    }
}
