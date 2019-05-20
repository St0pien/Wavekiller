using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketAiming : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    static public void createTarget (GameObject player, GameObject cel)
    {
        RaycastHit hit;
        Ray ray = new Ray(player.transform.position, player.transform.forward);
        Physics.Raycast(ray, out hit, 300);

        cel.SetActive(true);
        Vector3 cords = new Vector3(hit.point.x, hit.point.y + 0.5f, hit.point.z);
        cel.transform.position = cords;
    }
}
