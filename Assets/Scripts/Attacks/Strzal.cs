using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strzal : MonoBehaviour
{

    public float zasieg = 100;
    public float czekaj = 2;
    public float odlicz;

    public GameObject pocisk;
    public GameObject hole;
    public GameObject blood;
    public GameObject waterHit;
    public float obrazenia = 10;
    public AudioSource wystrzal;
    public AudioClip dzwiek;
    public Animator kara;

    public AudioSource check;

    public ParticleSystem smuga;

    public bool isShooting;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		if(odlicz < czekaj)
        {
            odlicz += Time.deltaTime;
            isShooting = false;
        }

        if(odlicz >= czekaj && Input.GetMouseButton(0) && GameObject.Find("Interfejs").GetComponent<Bronie>().gun && !GameObject.Find("Canvas_Menu").GetComponent<Canvas>().enabled && !check.isPlaying && GetComponent<weapons_r>().ak.Mag() > 0)
        {
            odlicz = 0;
            isShooting = true;

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, zasieg))
            {
                Vector3 hitPoint = hitInfo.point;
                GameObject go = hitInfo.collider.gameObject;

                if (go != gameObject)
                {
                    hit(go);


                    if (pocisk != null)
                    {
                        Destroy(GameObject.Find("ExplosionMobile(Clone)"));
                        if(go.tag == "Enemy" || go.name == "Armature" || go.name == "Chest")
                        {
                            GameObject activeBlood = Instantiate(blood, hitPoint, Quaternion.identity);
                            activeBlood.transform.LookAt(GameObject.Find("FPSController").transform);
                        }
                        else
                        {
                            if(go.name == "WaterProDaytime")
                            {
                                Instantiate(waterHit, hitPoint, Quaternion.identity);
                            }
                            else
                            {
                                Instantiate(hole, hitPoint, Quaternion.FromToRotation(Vector3.up, hitInfo.normal));
                                Instantiate(pocisk, hitPoint, Quaternion.identity);
                            }
                        }
                        pocisk.tag = "Sparks";
                    }
                }
            }
            smuga.Play();
            wystrzal.PlayOneShot(dzwiek);
            kara.SetBool("wypal_AK", true);
        }
        if (Input.GetMouseButtonDown(0) && GetComponent<weapons_r>().ak.Mag() > 0)
        {
            kara.SetBool("wypal_AK", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
           kara.SetBool("wypal_AK", false);
        }
        if(GetComponent<weapons_r>().ak.Mag() <= 0)
        {
            kara.SetBool("wypal_AK", false);
        }
    }

    private void hit(GameObject go)
    {
        EnemyHP zdrowie = go.GetComponent<EnemyHP>();
        HeadShot head = go.GetComponent<HeadShot>();


        if(head != null)
        {
            head.execute();
        }
        else if(zdrowie != null)
        {
            zdrowie.damage(obrazenia, Vector3.Distance(gameObject.transform.position, go.transform.position));
        }
    }
}
