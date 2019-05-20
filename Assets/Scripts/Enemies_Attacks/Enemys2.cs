using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys2 : MonoBehaviour
{
    bool obrot = true;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (obrot)
        {
            Quaternion rotate = Quaternion.LookRotation(Camera.main.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * 25);
        }
	}

    public void smierc()
    {
        obrot = false;
    }
}
