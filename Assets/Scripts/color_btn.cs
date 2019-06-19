using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class color_btn : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Image>().color = Color.red;
    }
}
