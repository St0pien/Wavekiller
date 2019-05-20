using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scall_snd : MonoBehaviour
{
    public GameObject sndpref;

	// Use this for initialization
	void Start ()
    {
		if(Screen.width > 3000)
        {
            fourk();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void fourk()
    {
        GameObject oldsnd = GameObject.FindWithTag("sndui");
        Destroy(oldsnd);
        GameObject newsnd = Instantiate(sndpref);
        newsnd.transform.SetParent(transform);
    }
}
