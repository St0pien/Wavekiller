using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour
{
    public GameObject AK;
    public Animator ak_anim;
    public GameObject celownik;
    public GameObject hand;

    float czas = 2;

    public bool zoom;

	// Use this for initialization
	void Start ()
    {
        celownik = GameObject.Find("Cross");
	}
	
	// Update is called once per frame
	void Update ()
    {
        celownik = GameObject.Find("Cross");
        ak_anim.SetBool("zoom_on", false);
        // ak_anim.SetBool("zoom_out", false);
        if (Input.GetMouseButtonDown(1) && !GetComponent<Stamina>().czy_bieg() && !hand.active && !GameObject.Find("Canvas_Menu").GetComponent<Canvas>().isActiveAndEnabled)
        {
            zoom = true;
            ak_anim.SetBool("zoom_on", true);
        }
        if(Input.GetMouseButtonUp(1))
        {
            zoom = false;
            ak_anim.SetBool("zoom_out", true);
        }
        zoomowanie(zoom);
        czas += Time.deltaTime;
	}

    void zoomowanie(bool flag)
    {
        if (flag == true)
        {
            ak_anim.SetBool("zoom_out", false);
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 13, Time.deltaTime * 20);
            celownik.GetComponent<Image>().enabled = false;
            czas = 0;
        }
        else if(flag == false)
        {
            if (czas < 0.18)
            {
                Camera.main.fieldOfView = 13;
            }
            else
            {
                ak_anim.SetBool("zoom_on", false);
                Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60, Time.deltaTime * 3);
                celownik.GetComponent<Image>().enabled = true;
            }
        }
    }
}
