using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bronie : MonoBehaviour
{
    public GameObject gunico;
    public GameObject rico;
    public GameObject ak;

    public bool gun = true;

    public float scalescreen = 1;

    float wid;
    float hei;
    float time = 0;

    Vector3 radioCords;
    Vector3 WrapperCords;

    public AudioSource radio;
    public AudioClip hum;

    public GameObject aimPref;

    // Use this for initialization
    void Start()
    {
        gunico = GameObject.Find("Karabin");
        rico = GameObject.Find("RPG");

        wid = Screen.width;
        hei = Screen.height;
        wid /= 1234;
        hei /= 652;

        if (Screen.width > 1000)
        {
            //scalescreen = 1.5f;
        }
        //Debug.Log("Screen " + scalescreen);
        // setGun();
        // setRocket();
        //setGun();



        //Debug.Log("no o co cho " + wid);
        radioCords = new Vector3(-0.18f, -0.7f, 0.37f);
        WrapperCords = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        gunico = GameObject.Find("Karabin");
        rico = GameObject.Find("RPG");


        if (time > 1)
        {
            posRadio();
        }
        posCar();
        
        if(!gun && !radio.isPlaying)
        {
            sndforRadio();
        }

        if(!gun)
        {
            rocketAiming.createTarget(GameObject.Find("FirstPersonCharacter"), aimPref);
        }

        if(gun)
        {
            aimPref.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.Alpha1) && !GameObject.Find("Canvas_Menu").GetComponent<Canvas>().enabled && !gun && !GameObject.Find("FPSController").GetComponent<Zoom>().zoom)
        {
            setGun();
            radioCords = new Vector3(-0.18f, -0.7f, 0.37f);
            WrapperCords = new Vector3(0, 0, 0);
            radio.GetComponent<AudioSource>().Stop();
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2) && !GameObject.Find("Canvas_Menu").GetComponent<Canvas>().enabled && gun && !GameObject.Find("FPSController").GetComponent<Zoom>().zoom)
        {
            setRocket();
            radioCords = new Vector3(-0.18f, -0.35f, 0.37f);
            WrapperCords = new Vector3(0, -0.5f, -0.5f);
            time = 0;
            sndforRadio();
        }
    }

    void setGun()
    {
        gunico.GetComponent<RectTransform>().localScale = new Vector2(0.15f * wid, 0.15f * hei);
        rico.GetComponent<RectTransform>().localScale = new Vector2(0.03f * wid, 0.03f * hei);
        gun = true;
    }

    void setRocket()
    {
        rico.GetComponent<RectTransform>().localScale = new Vector2(0.1f * wid, 0.1f * hei);
        gunico.GetComponent<RectTransform>().localScale = new Vector2(0.05f * wid, 0.05f * hei);
        gun = false;
    }

    void posRadio()
    {
        GameObject radio = GameObject.Find("radio");
        radio.transform.localPosition = Vector3.Lerp(radio.transform.localPosition, radioCords, Time.deltaTime * 7);
    }

    void posCar()
    {
        GameObject Wrapper = GameObject.Find("Wrapper");
        Wrapper.transform.localPosition = Vector3.Slerp(Wrapper.transform.localPosition, WrapperCords, Time.deltaTime*6);
    }

    void sndforRadio()
    {
        radio.volume = 0.5f;
        radio.PlayOneShot(hum);
    }
}
