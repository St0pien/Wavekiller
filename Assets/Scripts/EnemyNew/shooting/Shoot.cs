using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Audio;

public class Shoot : MonoBehaviour
{
    public float xOffset; //must be lower than 0
    public float yOffset; //must be lower than 0
    public float movementSpeed;
    public float timeDelay;
    public GameObject rightHand;

    public GameObject sparks;
    public AudioClip shotSND;
    public AudioSource snd;

    bool shot = false;
    Quaternion startRotation;
    float maxX;
    float maxY;

    float shotDelay = 0;
    float dist;

	// Use this for initialization
	void Start ()
    {
        startRotation = rightHand.transform.localRotation;
        maxX = rightHand.transform.localRotation.x + xOffset;
        maxY = rightHand.transform.localRotation.y + yOffset;
    }

    // Update is called once per frame
    void Update ()
    {
        if(!GetComponent<EnemyHP>().isDead() && !GameObject.Find("Canvas_Menu").GetComponent<Canvas>().isActiveAndEnabled)
        {
            dist = Vector3.Distance(transform.position, GameObject.Find("FPSController").transform.position);
            shotDelay += Time.deltaTime;
            holdStill();
            decideToShoot();
            if (Input.GetKeyDown(KeyCode.J))
            {
                shot = true;
            }

            if (shot)
            {
                shotDelay = 0;
                sparks.GetComponent<ParticleSystem>().Play();
                snd.PlayOneShot(shotSND);
                shootAnim();
                checkHit();
            }
        }
	}

    void shootAnim()
    {
        Quaternion rotation = rightHand.transform.localRotation;
        rotation.x -= xOffset;
        rotation.y -= yOffset;
        rightHand.transform.localRotation = Quaternion.Slerp(rightHand.transform.localRotation, rotation, Time.deltaTime*movementSpeed);
        if (rightHand.transform.localRotation.x < maxX)
        {
            shot = false;
        }
    }

    void holdStill()
    {

        rightHand.transform.localRotation = Quaternion.Slerp(rightHand.transform.localRotation, startRotation, Time.deltaTime*movementSpeed*5);
    }

    void decideToShoot()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position+new Vector3(0, 1.5f, 0), transform.forward);
        Physics.Raycast(ray, out hit, 100);

        if(hit.collider.gameObject.tag == "Player")
        {
            float rnd = Random.Range(0, 10)*dist*30;
            if(rnd < 1 && !shot && shotDelay > timeDelay)
            {
                shot = true;
            }
        }
    }

    void checkHit()
    {
        if(Random.Range(1, 11)*2/dist > 0.4f)
        {
            float damage = Random.Range(10, 30) / dist * 5;

            GameObject.Find("FPSController").GetComponent<HP_Player>().otrzymaneobrażenia(damage);
        }
    }
}
