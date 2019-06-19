using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnSelected : MonoBehaviour
{
    public GameObject credits;
    public GameObject mainmenu;
    public Button creditsbtn;
    public Button backbtn;



    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Button>().isActiveAndEnabled)
        {
            GetComponent<Button>().Select();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReturnMain ()
    {
        GameObject.Find("CreditsMenu").SetActive(false);
        //GameObject.Find("MainMenu").SetActive(true);
        mainmenu.SetActive(true);

        creditsbtn.Select();
    }

    public void GoCredits ()
    {
        GameObject.Find("MainMenu").SetActive(false);
        //GameObject.Find("CreditsMenu").SetActive(true);
        credits.SetActive(true);
        //GetComponent<Button>().Select();

        backbtn.Select();
    }
}
