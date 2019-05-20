using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    public Animator ak;
    public Animator loc;

    public AudioSource snd;
    public AudioClip mag;
    public AudioClip pull;

    public GameObject hand;

    float czas = 0;

    bool play=false;
    bool show = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        animate();
        czas += Time.deltaTime;
        off();
        handControl();

        if(play && !snd.isPlaying)
        {
            snd.PlayOneShot(pull);
            play = false;
        }
	}

    void animate()
    {
        if(Input.GetKeyDown(KeyCode.R) && !snd.isPlaying && Camera.main.fieldOfView >30 && GetComponent<weapons_r>().ak.Outmag() > 0)
        {
            ak.SetBool("reload", true);
            show = true;
            czas = 0;
            if (!snd.isPlaying)
            {
                snd.PlayOneShot(mag);
                play = true;
            }
        }
    }

    float czasomierz()
    {
        return czas;
    }

    void off()
    {
        if(czasomierz() >= 0.3)
        {
            ak.SetBool("reload", false);
            loc.SetBool("go", false);

        }

        if (czasomierz() >= 1.9 && !show)
        {
            hand.SetActive(false);
        }
    }

    void handControl()
    {
        if (show && czasomierz() > 0.7)
        {
            hand.SetActive(true);
            loc.SetBool("go", true);
            show = false;
        }
    }
}
