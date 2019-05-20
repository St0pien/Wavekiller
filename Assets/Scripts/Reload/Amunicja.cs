using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Amunicja : MonoBehaviour
{

    int basic_mag;
    int basic_out;

    int mag;
    int outMag;


	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public Amunicja(int i, int o)
    {
        Text UI = GameObject.Find("Ammo").GetComponent<Text>();

        basic_mag = i;
        basic_out = o;

        mag = basic_mag;
        outMag = basic_out;

        //Debug.Log(mag + basic_mag + outMag + basic_out);
    }

    public void update_counter()
    {
        Text UI = GameObject.Find("Ammo").GetComponent<Text>();
        UI.text = mag + "/" + outMag;
    }

    public void laduj()
    {
        if (outMag >= basic_mag)
        {
            mag = basic_mag;
            outMag -= basic_mag;
        }
        else
        {
            mag = outMag;
            outMag = 0;
        }
    }

    public void shot()
    {
        if (mag > 0)
        {
            mag -= 1;
        }
    }

    public int Mag()
    {
        return mag;
    }

    public int Outmag()
    {
        return outMag;
    }

    public void skrzynka()
    {
        outMag += 120;
    }
}
