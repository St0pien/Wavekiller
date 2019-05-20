using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_shot : MonoBehaviour
{

    public float czekaj;
    public float odlicz;
    public GameObject pociskprefab;
    public GameObject Wystrzal;

    public AudioSource enemy;
    public AudioClip strzal;

    public RaycastHit hitInfo;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        odlicz -= Time.deltaTime;
        Physics.Raycast(new Ray(transform.Find("Sphere").position, transform.Find("Sphere").forward),out hitInfo, 90);
        Debug.DrawRay(transform.Find("Sphere").position, transform.Find("Sphere").forward, Color.blue, 90);

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.gameObject.name == "FPSController" && odlicz <= 0 && GetComponent<AI_3>().spadl && !GetComponent<AI_3>().isDead())
            {
                odlicz = czekaj;


                Transform PociskXYZ = pociskprefab.transform;
                PociskXYZ.position = new Vector3(0, 0.43f, 0);
                GetComponent<pocisk_hit>().hit();

                GameObject[] zniszcz = GameObject.FindGameObjectsWithTag("Wystrzal");

                for (int i = 0; i < zniszcz.Length - 1; i++)
                {
                    Destroy(zniszcz[i]);
                }

                Instantiate(Wystrzal, transform.position + PociskXYZ.position, transform.Find("Sphere").rotation);
                enemy.PlayOneShot(strzal);
            }
        }
	}
}
