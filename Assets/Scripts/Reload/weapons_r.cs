using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapons_r : MonoBehaviour
{
    public Amunicja ak;
    public Amunicja rpg;

    public Animator anim;

    public GameObject player;

    bool ak_active = true;
    float czas=3;

	// Use this for initialization
	void Start ()
    {
        ak = new Amunicja(30, 120);
        rpg = new Amunicja(1, 10);

        ak.update_counter();
	}
	
	// Update is called once per frame
	void Update ()
    {
        ak_active = GameObject.Find("Interfejs").GetComponent<Bronie>().gun;
        on_r();
        on_strzal();
        change_UI();
        czas += Time.deltaTime;
	}

    void on_r()
    {
        if(ak_active)
        {
            if (Input.GetKeyDown(KeyCode.R) && GetComponent<weapons_r>().ak.Outmag() > 0 && czas > 2 && anim.GetBool("zoom_out"))
            {
                czas = 0;
                ak.laduj();
            }
        }
    }

    void on_strzal()
    {
        if(ak_active)
        {
            if(player.GetComponent<Strzal>().isShooting)
            {
                ak.shot();
            }
        }
    }

    public void change_UI()
    {
        if(ak_active)
        {
            ak.update_counter();
        }
    }
}
