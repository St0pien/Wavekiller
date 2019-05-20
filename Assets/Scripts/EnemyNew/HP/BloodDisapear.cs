using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDisapear : MonoBehaviour
{
    float timer;
    public float duration = 5;
	// Use this for initialization
	void Start ()
    {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer > duration)
        {
            Destroy(gameObject);
        }
	}
}
