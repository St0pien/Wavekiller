using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAI : MonoBehaviour
{
    public GameObject rightHand;

    bool grounded = false;
    bool landing = false;
    GameObject player; //Player object
    Animator body;
    string act; //name of bool which trigger current animation 
    Transform leftLeg;
    Transform rightLeg;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("FPSController");
        body = GetComponent<Animator>();
        leftLeg = gameObject.transform.GetChild(0).GetChild(0).GetChild(1);
        rightLeg = gameObject.transform.GetChild(0).GetChild(0).GetChild(2);

        GameObject [] bodyParts = GameObject.FindGameObjectsWithTag("body");
        foreach(GameObject part in bodyParts)
        {
            if(part.transform.IsChildOf(transform))
            {
                if(part.GetComponent<CapsuleCollider>() != null)
                {
                    part.GetComponent<CapsuleCollider>().enabled = false;
                }
            }
        }
        GetComponent<EnemyHP>().setChildren(bodyParts);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<EnemyHP>().isDead() && grounded)
        {
            control();
        }
        else
        {
            body.SetBool("walk", false);
            body.SetBool("neutral", false);
            body.SetBool("back", false);
            body.SetBool("avoidL", false);
            body.SetBool("avoidR", false);
            body.SetBool("run", false);
            body.SetBool("fall", false);
        }
        if(!grounded && !GetComponent<EnemyHP>().isDead())
        {
            engageLanding();
        }
    }

    void control() //switch stance
    {
        float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);

        if (distance < 10 && !GetComponent<EnemyHP>().isDead())
        {
            neutral();
            if (distance < 5)
            {
                stepBack();
            }
        }
        else if(distance > 20 && !GetComponent<EnemyHP>().isDead())
        {
            run();
        }
        else if(!GetComponent<EnemyHP>().isDead())
        {
            walkFire();
        }
    }

    void walkFire () //walking forward and shooting
    {
        body.SetBool(act, false);
        body.SetBool("walk", true);
        act = "walk";
        myRotation();
    }

    void neutral() //close distance
    {
        body.SetBool(act, false);
        body.SetBool("neutral", true);
        act = "neutral";
        myRotation();
    }

    void stepBack() //too close
    {
        body.SetBool(act, false);
        body.SetBool("back", true);
        act = "back";
        myRotation();
    }

    void run() //too far
    {
        body.SetBool(act, false);
        body.SetBool("run", true);
        act = "run";
        myRotation();
    }

    void falling() //is not grounded, falling
    {
        landing = true;
        body.SetBool("fall", true);
        StartCoroutine(sleep(0.05f));
    }

    void myRotation() //setting rotation
    {
        Quaternion look = Quaternion.LookRotation(GameObject.Find("FPSController").transform.position - transform.position);
        Quaternion lookf = Quaternion.LookRotation(Vector3.forward);
        transform.rotation = new Quaternion(lookf.x, look.y, lookf.z, look.w);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (grounded && !GetComponent<EnemyHP>().isDead() && !landing && collision.gameObject.name != "Terrain")
        {
            Vector3 point = collision.contacts[0].point;
            float leftDistance = Vector3.Distance(point, leftLeg.position);
            float rightDistance = Vector3.Distance(point, rightLeg.position);

            if(leftDistance > rightDistance)
            {
                //prawo
                body.SetBool("avoidL", false);
                body.SetBool("avoidR", true);
            }
            else
            {
                //lewo
                body.SetBool("avoidR", false);
                body.SetBool("avoidL", true);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.name == "Terrain")
        {
            grounded = true;
        }
        else
        {
            //grounded = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        body.SetBool("avoidL", false);
        body.SetBool("avoidR", false);
    }

    void engageLanding()
    {
        RaycastHit point;
        Physics.Raycast(new Ray(transform.position, Vector3.down), out point, 4);
        if (point.collider != null && point.collider.gameObject.tag != "body")
        {
            if (!body.GetBool("fall") && !grounded)
            { 
                falling();

                grounded = true;
            }
        }
    }

    IEnumerator sleep(float time)
    {
        yield return new WaitForSeconds(time);
        body.SetBool("fall", false);
        landing = false;
    }

    void OnAnimatorIK()
    {
        Transform pistol = transform.GetChild(2);
        body.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        body.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
        body.SetIKRotation(AvatarIKGoal.RightHand, pistol.rotation);
        body.SetIKPosition(AvatarIKGoal.RightHand, pistol.position);
    }
}
