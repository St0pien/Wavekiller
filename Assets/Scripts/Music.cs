using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip Hydro;
    public AudioClip Cryst;
    public AudioClip Paris;

    public AudioSource glosnik;

    float los;

	// Use this for initialization
	void Start ()
    {
        los = Random.Range(1, 3);
	}

    // Update is called once per frame
    void Update()
    {
        if(Camera.main.clearFlags != CameraClearFlags.SolidColor)
        {

            if (!glosnik.isPlaying && los == 1)
            {
                glosnik.PlayOneShot(Hydro);
                los = Random.Range(2, 3);
            }
            if (!glosnik.isPlaying && los == 2)
            {
                glosnik.PlayOneShot(Cryst);
                if (Random.Range(1, 2) == 1)
                {
                    los = 1;
                }
                else
                {
                    los = 3;
                }
            }
            if (!glosnik.isPlaying && los == 3)
            {
                glosnik.PlayOneShot(Paris);
                los = Random.Range(1, 2);
            }
        }
    }
}
        

