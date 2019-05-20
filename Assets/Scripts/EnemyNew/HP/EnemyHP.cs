﻿using System.Collections;
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
        foreach (AnimatorControllerParameter param in anim.parameters)
        {
            anim.SetBool(param.name, false);
        }

        int choice = Random.Range(0, 3);
        switch (choice)
        {
            case 0: act = "dead0"; break;
            case 1: act = "dead1"; break;
            case 2: act = "dead2"; break;
            default: Debug.Log("ERROR in die animation"); break;
        }
        anim.SetBool(act, true);

        standing.height = 1.5f;
        standing.radius = 1.5f;
        standing.center = new Vector3(0.1f, 1.5f, 0);
        dying.enabled = true;

        done = true;
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
