using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float xOffset; //must be lower than 0
    public float yOffset; //must be lower than 0
    public float movementSpeed;
    public GameObject rightHand;
    bool shot = false;
    Quaternion startRotation;
    float maxX;
    float maxY;

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
        holdStill();
        if (Input.GetKeyDown(KeyCode.J))
        {
            shot = true;
        }

        if(shot)
        {
            shootAnim();
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
}
