using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShot : MonoBehaviour
{

    public float czekaj;
    public float odlicz;
    public GameObject Rakieta;
    public GameObject target_prefab;

    public AudioSource gracz;
    public AudioClip pal;

    public AudioSource radio;
    public AudioClip request;

    RaycastHit hit;
    Quaternion look;

    float [] randomCord;
    float [] rnd;


	// Use this for initialization
	void Start ()
    {
        randomCord = new float[3];
        rnd = new float[3];
	}
	
	// Update is called once per frame
    void Update ()
    {
        odlicz -= Time.deltaTime;
        if(GameObject.Find("ładunek(Clone)") == null)
        {
            if(odlicz <= -10)
            Destroy(GameObject.Find("Explosion(Clone)"));
        }

        if (Input.GetMouseButton(0) && odlicz <= 0 && !GameObject.Find("Interfejs").GetComponent<Bronie>().gun && !GameObject.Find("Canvas_Menu").GetComponent<Canvas>().isActiveAndEnabled)
        {
            radio.Stop();
            radio.volume = 1;
            radio.PlayOneShot(request);
            odlicz = czekaj;
            Destroy(GameObject.Find("Explosion(Clone)"));
            Destroy(GameObject.Find("Pusty(Clone)"));            
            Physics.Raycast(new Ray(Camera.main.transform.position, Camera.main.transform.forward), out hit);
            Instantiate(target_prefab, hit.point, Quaternion.identity);
            //gracz.PlayOneShot(pal);
            fireOn();
            Destroy(GameObject.Find("Pusty(Clone)"));
        }
	}

    void fireOn()
    {

        for (int i=0; i<30; i++)
        {
            for(int j=0; j<3; j++)
            {
                randomCord[j] = (Random.Range(1, 100)) + 300;
                if(j != 0 && randomCord[j-1] == randomCord[j])
                {
                    randomCord[j]++;
                }
            }

            for (int j = 0; j < 3; j++)
            {
                rnd[j] = (Random.Range(-0.019f, 0.019f));
                if (j != 0 && rnd[j - 1] == rnd[j])
                {
                    rnd[j]++;
                }
            }

            Vector3 pozycja = new Vector3(randomCord[0], randomCord[1], randomCord[2]);
            look = Quaternion.LookRotation(GameObject.Find("Pusty(Clone)").transform.position - pozycja);
            look.x += rnd[0];
            look.y += rnd[1];
            look.z += rnd[2];

            Instantiate(Rakieta, pozycja, look);
            //Debug.Log("Wystrzał");
        }
    }
}
