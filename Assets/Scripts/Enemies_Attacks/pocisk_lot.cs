using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pocisk_lot : MonoBehaviour
{
    public float velocity;

	// Use this for initialization
	void Start ()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.Translate(transform.forward * velocity * Time.deltaTime, Space.World);
	}
}
