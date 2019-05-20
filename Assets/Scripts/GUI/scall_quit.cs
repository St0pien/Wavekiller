using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scall_quit : MonoBehaviour
{

    GameObject quit;

	// Use this for initialization
	void Start ()
    {
        quit = GameObject.Find("Image");
        if (Screen.width > 3000)
        {
            scale();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    void scale()
    {
        quit.GetComponent<RectTransform>().localScale *= 3f;
    }
}
