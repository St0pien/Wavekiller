using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AudioSource boom;
    public AudioClip grzmot;

	// Use this for initialization
	void Start ()
    {
        boom.PlayOneShot(grzmot);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
