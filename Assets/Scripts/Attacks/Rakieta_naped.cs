using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rakieta_naped : MonoBehaviour
{

    public float velocity;

    public AudioSource swist;

	// Use this for initialization
	void Start ()
    {
        swist.Play();  //dźwięk lotu
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    void FixedUpdate()
    {
        transform.Translate(transform.forward * velocity * Time.deltaTime, Space.World);
    }
}
