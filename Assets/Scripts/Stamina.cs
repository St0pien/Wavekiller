using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Stamina : MonoBehaviour
{
    public float zmeczenie;
    public float czas = 5;
    public GameObject pasek;



    // Use this for initialization
    void Start()
    {
        zmeczenie = czas;
        pasek = GameObject.Find("stamina");
    }

    // Update is called once per frame
    void Update()
    {
        pasek = GameObject.Find("stamina");
        ustaw_stamine();
    }

    void ustaw_stamine()
    {
        if (czy_bieg() && stamina())
        {
            zmeczenie -= 1.5f*Time.deltaTime;
        }
        else if(zmeczenie < czas)
        {
            zmeczenie += Time.deltaTime;
        }
        pasek.GetComponent<Image>().fillAmount = zmeczenie / czas;
    }

    public bool czy_bieg()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            return true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            return false;
        }
        else
            return false;
    }

    public bool stamina()
    {
        if (zmeczenie > -0.5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
