using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip nature;

    public AudioSource glosnik;

	// Use this for initialization
	void Start ()
    {
         
	}

    // Update is called once per frame
    void Update()
    {
        if(Camera.main.clearFlags != CameraClearFlags.SolidColor)
        {
            if(!glosnik.isPlaying)
            {
                glosnik.PlayOneShot(nature);
            }
        }
    }
}
        

