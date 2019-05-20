using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public CharacterController character_controller;

    public float Poruszanie;
    public float Skok;
    public float Bieg;
    public float wyskok;
    public float mysz;
    float Mgora_dol = 0;

    // Use this for initialization
    void Start ()
    {
        character_controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        klawiatura();
        myszka();
	}

    void klawiatura()
    {
        float przod_tyl = Input.GetAxis("Vertical")*Poruszanie;
        float prawo_lewo = Input.GetAxis("Horizontal")*Poruszanie;

        if(character_controller.isGrounded && Input.GetKey(KeyCode.Space))
        {
            wyskok = Skok;
        }
        else if(!character_controller.isGrounded)
        {
            wyskok += Physics.gravity.y*Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Poruszanie += Bieg;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            Poruszanie -= Bieg;
        }

        Vector3 ruch = new Vector3(prawo_lewo, wyskok, przod_tyl);
        ruch = transform.rotation * ruch;

        character_controller.Move(ruch * Time.deltaTime);
    }

    void myszka()
    {
        float Mlewo_prawo = Input.GetAxis("Mouse X")*mysz;
        
        transform.Rotate(0, Mlewo_prawo, 0);

        Mgora_dol -= Input.GetAxis("Mouse Y") * mysz;

        //Funkcja nie pozwala aby wartość przekroczyła dane zakresy.
        Mgora_dol = Mathf.Clamp(Mgora_dol, -90, 90);
        //Ponieważ CharacterController nie obraca się góra/dół obracamy tylko kamerę.
        Camera.main.transform.localRotation = Quaternion.Euler(Mgora_dol, 0, 0);
    }
}
