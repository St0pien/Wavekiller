using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{

    public float HP = 100;
    Animator anim;
    bool done = false;
    float timer = 0;

    public CapsuleCollider standing;
    public CapsuleCollider dying;

    string act; //name of animation

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(done)
        {
            timer += Time.deltaTime;
        }

        if(timer > 0.1)
        {
            anim.SetBool(act, false);
        }

		if(HP <= 0 && !done)
        {
            die();
        }
        anim.SetFloat("HP", HP);
	}

    public void damage(float dmg, float dist)
    {
        HP -= dmg / (dist*0.1f);
        anim.SetTrigger("hit");
    }

    void die()
    {

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
}
