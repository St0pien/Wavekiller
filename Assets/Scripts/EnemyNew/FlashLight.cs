using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject pistolLight;
    public GameObject leftEye;
    public GameObject rightEye;

    GameObject dayNight;
    bool night;

	// Use this for initialization
	void Start ()
    {
        dayNight = GameObject.Find("DayNight");
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(dayNight.transform.rotation.eulerAngles.x < 0 || dayNight.transform.rotation.eulerAngles.x > 180)
        {
            night = true;
        }
        else
        {
            night = false;
        }

        pistolLight.SetActive(night);
        leftEye.SetActive(night);
        rightEye.SetActive(night);
	}
}
