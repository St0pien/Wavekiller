using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{

    public float HP = 100;
    public GameObject pistol;
    Animator anim;
    bool done = false;

    public CapsuleCollider standing;

    GameObject[] bodyParts;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(HP <= 0 && !done)
        {
            die();
        }
        anim.SetFloat("HP", HP);
	}

    public void damage(float dmg, float dist)
    {
        HP -= dmg + dist/10;
        float rnd = Random.Range(0, 3);
        if(rnd > 1)
        {
            anim.SetBool("avoidL", true);
        }
        else
        {
            anim.SetBool("avoidR", true);
        }
        StartCoroutine(GetComponent<WalkAI>().disableAvoid());
    }

    void die()
    {
        endLife();
    }

    public bool isDead()
    {
        if(HP > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void endLife()
    {
        foreach (GameObject part in bodyParts)
        {
            if (part.transform.IsChildOf(transform))
            {
                if (part.GetComponent<CapsuleCollider>() != null)
                {
                    part.GetComponent<CapsuleCollider>().enabled = true;
                }
            }
        }
        GetComponent<Animator>().enabled = false;
        standing.enabled = false;
        transform.GetChild(0).GetComponent<SphereCollider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        Auto_Destruct destroy = gameObject.AddComponent<Auto_Destruct>();
        destroy.duration = 90;

        //drop Pistol
        pistol.transform.parent = null;
        pistol.AddComponent<Rigidbody>();
        done = true;
    }

    public void setChildren(GameObject[] parts)
    {
        bodyParts = parts;
    }
}
