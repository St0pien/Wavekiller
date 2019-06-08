using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float movementSpeed;
    public float timeDelay;
    public GameObject rightHand;

    public GameObject sparks;
    public AudioClip shotSND;
    public AudioSource snd;
    public GameObject pistol;
    public Quaternion handOffset;

    bool shot = false;
    Quaternion startRotation;

    float shotDelay = 0;
    float dist;

	// Use this for initialization
	void Start ()
    {
        startRotation = rightHand.transform.localRotation;
    }

    // Update is called once per frame
    void Update ()
    {
        if(!GetComponent<EnemyHP>().isDead() && !GameObject.Find("Canvas_Menu").GetComponent<Canvas>().isActiveAndEnabled)
        {
            dist = Vector3.Distance(transform.position, GameObject.Find("FPSController").transform.position);
            shotDelay += Time.deltaTime;
            decideToShoot();

            if (shot)
            {
                shotDelay = 0;
                sparks.GetComponent<ParticleSystem>().Play();
                snd.PlayOneShot(shotSND);
                checkHit();
            }
        }
	}

    void decideToShoot()
    {
        RaycastHit hit;
        Vector3 target = GameObject.FindWithTag("Player").transform.position - transform.position - new Vector3(0, 1, 0);
        setPistolTransform();
        Ray ray = new Ray(transform.position+new Vector3(0, 1.5f, 0), target);
        Physics.Raycast(ray, out hit, 100);

        if(hit.collider.gameObject.tag == "Player" && GetComponent<WalkAI>().isGrounded())
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

    void setPistolTransform()
    {
        Transform hand = transform.GetChild(2);
        Vector3 playerPosition = GameObject.FindWithTag("Player").transform.position+new Vector3(0,1,0);
        hand.position = playerPosition;
        hand.rotation = Quaternion.LookRotation(playerPosition - pistol.transform.position)*handOffset;
        if(shot)
        {
            shot = false;
        }
    }
}
