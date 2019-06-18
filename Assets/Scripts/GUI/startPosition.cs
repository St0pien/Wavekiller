using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startPosition : MonoBehaviour
{
   
	// Use this for initialization
	void Start ()
    {
        GameObject player = GameObject.Find("FPSController");
        float x, z;
        x = Random.Range(200, 800);
        z = Random.Range(200, 800);
        Vector3 position = new Vector3(x, 100, z);
        player.transform.position = position;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
