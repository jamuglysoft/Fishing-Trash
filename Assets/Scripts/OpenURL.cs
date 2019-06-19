using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpenURL : MonoBehaviour
{

    public Sprite img_face;
    private Sprite img_courtain;

    private void Start()
    {
        img_courtain = GetComponent<Image>().sprite;
    }


    public void Oriol ()
    {
        Application.OpenURL("https://github.com/OriolCS2");
    }

    public void Marc()
    {
        Application.OpenURL("https://github.com/optus23");
    }

    public void Christian ()
    {
        Application.OpenURL("https://github.com/christt105");
    }

    public void Lluis ()
    {
        Application.OpenURL("https://github.com/youis11");
    }

    public void Victor ()
    {
        Application.OpenURL("https://github.com/VictorSegura99");
    }

    public void ChangeSprite ()
    {
        GetComponent<Image>().sprite = img_face;
    }

    public void RechangeSprite()
    {
        GetComponent<Image>().sprite = img_courtain;
    }

}
