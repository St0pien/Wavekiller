using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scall_menu : MonoBehaviour
{

    public GameObject [] UIs;

    // Use this for initialization
    void Start()
    {
        UIs = new GameObject[4];
        GameObject.Find("Canvas_Menu").GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update ()
    {
        UIs[0] = GameObject.Find("Title");
        UIs[1] = GameObject.Find("Start");
        UIs[2] = GameObject.Find("Options");
        UIs[3] = GameObject.Find("Exit");

        if (Screen.width > 3000 && UIs[1].GetComponent<RectTransform>().localScale.x < 5)
        {
            scall();
        }
	}

    void scall()
    {
        int counter = 1;

        foreach (GameObject img in UIs)
        {
            img.GetComponent<RectTransform>().localScale *= 3f;
            if (img == UIs[0])
            {
                Vector3 helpTitle = img.GetComponent<RectTransform>().transform.position;
                img.GetComponent<RectTransform>().transform.position = new Vector3(helpTitle.x + 300, helpTitle.y);
                continue;
            }
            Vector3 helpVar = img.GetComponent<RectTransform>().transform.position;
            img.GetComponent<RectTransform>().transform.position = new Vector3(helpVar.x + 300, helpVar.y - (280*counter));
            counter++;
        }
    }
}
