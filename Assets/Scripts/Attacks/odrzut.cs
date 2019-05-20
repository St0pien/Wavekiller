using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class odrzut : MonoBehaviour
{
    public GameObject cel;
   // float add_axis = 0;

	// Use this for initialization
	void Start ()
    {
        cel = GameObject.Find("Cross");
	}
	
	// Update is called once per frame
	void Update ()
    {
        cel = GameObject.Find("Cross");
        if (Input.GetMouseButton(0))
        {
            if(Input.GetMouseButton(1))
            {
               // add_axis = 10;
            }
            else
            {
                odrzut_cel();
            }
        }

        scaleUI();
	}

    void odrzut_cel()
    {
        if (cel.GetComponent<RectTransform>().localScale.x <= 4 && !GameObject.Find("Canvas_Menu").GetComponent<Canvas>().isActiveAndEnabled)
        {
            cel.GetComponent<RectTransform>().transform.localScale *= 1.05f;
        }
    }

    void scaleUI()
    {
        cel.GetComponent<RectTransform>().transform.localScale = Vector3.Lerp(cel.GetComponent<RectTransform>().transform.localScale, new Vector3(1, 1, 1), Time.deltaTime * 3f);
    }
}
