using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_detonation : MonoBehaviour
{

    public GameObject uderzenie;

    public float obrazenia;

    public float zasieg;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnTriggerEnter()
    {
        detonacja();
    }

    void detonacja()
    {
        Vector3 punkt = transform.position;


            if (uderzenie != null)
            {
                Instantiate(uderzenie, punkt, Quaternion.identity);
                uderzenie.tag = "Fire";
            }
        

        Destroy(gameObject);
        if (Vector3.Distance(transform.position, Camera.main.transform.position) < zasieg)
        {
            float dmg = 1 - (Vector3.Distance(transform.position, Camera.main.transform.position) / zasieg);
            Debug.Log("JEEEEEEEEEEEE");

            GameObject.Find("FPSController").GetComponent<HP_Player>().otrzymaneobrażenia(Mathf.Round(obrazenia * dmg));
        }

        Collider[] colliders = Physics.OverlapSphere(punkt, zasieg);

        foreach(Collider c in colliders)
        {
            EnemyHP h = c.GetComponent<EnemyHP>();

            HP_Player H = c.GetComponent<HP_Player>();

            if (h != null || H != null)
            {
                float dist = Vector3.Distance(punkt, c.transform.position);
                float newDamage = 10 - (dist / zasieg);

                h.damage(obrazenia * newDamage, 1);
                H.otrzymaneobrażenia(obrazenia * newDamage);
            }
        }
    }
}
