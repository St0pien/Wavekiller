using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSet : MonoBehaviour
{
    public float velocity = 1f;
    public Light sun;

    public float maxIntens = 1f;
    public float minIntens = 0f;

    public Light moonLight;
    public float maxMoon;
    public float minMoon;

    public GameObject stars;
    public Material lowclouds;
    public Material highclouds;

	// Use this for initialization
	void Start ()
    {
        transform.Rotate(Random.Range(0, 360), 0, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(velocity * Time.deltaTime, 0, 0);
        SetLights();
	}

    void SetLights()
    {
        //Day
        if (transform.rotation.eulerAngles.x > 0 && transform.rotation.eulerAngles.x < 180)
        {
            sun.intensity = maxIntens;
            moonLight.intensity = minMoon;

            Color low = new Color(1, 1, 1, 0.5f);
            Color high = new Color(1, 1, 1, 0.8f);

            lowclouds.SetColor("_CloudColor", low);
            highclouds.SetColor("_CloudColor", high);
            stars.SetActive(false);
        }
        //Night
        else
        {
            sun.intensity = minIntens;
            moonLight.intensity = maxMoon;

            Color low = new Color(1, 1, 1, 0.1f);
            Color high = new Color(1, 1, 1, 0.2f);

            lowclouds.SetColor("_CloudColor", low);
            highclouds.SetColor("_CloudColor", high);
            stars.SetActive(true);
        }
    }
}
