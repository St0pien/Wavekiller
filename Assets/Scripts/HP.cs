using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public float zdrowie = 100;

	// Use this for initialization
	public void otrzymaneobrażenia(float amt)
    {
        zdrowie -= amt;

        //if(zdrowie <= 0)
        {
            //Die();
        }
	}
	
	// Update is called once per frame
	public void Die()
    {
        transform.position = new Vector3(0, 100, 0);
	}

    public bool CzyMartwy()
    {
        if(zdrowie <= 0)
        {
            return true;
        }
        return false;
    }

}
