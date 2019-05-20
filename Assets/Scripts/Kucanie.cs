using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kucanie : MonoBehaviour
{
    public GameObject Player;
    bool kucaj = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(kucaj)
        {
            Player.GetComponent<CharacterController>().height = Mathf.Lerp(Player.GetComponent<CharacterController>().height, 0.5f, Time.deltaTime*10);
        }

        if(!kucaj)
        {
            Player.GetComponent<CharacterController>().height = Mathf.Lerp(Player.GetComponent<CharacterController>().height, 1.8f, Time.deltaTime * 10);
        }

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            kucaj = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            kucaj = false;
        }
	}
}
