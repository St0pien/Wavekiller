using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    public AudioSource source;
    public AudioClip picking;

	// Use this for initialization
	void Start ()
    {
        source = GameObject.Find("FirstPersonCharacter").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == GameObject.Find("FPSController"))
        {
            GameObject soldier = other.gameObject;

            soldier.GetComponent<weapons_r>().ak.skrzynka();
            source.PlayOneShot(picking);

            Destroy(gameObject);
        }
    }
}
