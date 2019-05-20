using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
       // if (GameObject.Find("Interfejs").GetComponent<Bronie>().scalescreen == 1.5)
       // {
           // GameObject.Find("HP").GetComponent<RectTransform>().transform.localScale *= 1.5f;
           // GetComponent<Text>().fontSize = 40;
        //}
    }
	
	// Update is called once per frame
	void Update ()
    {
        float points = GameObject.Find("FPSController").GetComponent<HP_Player>().zdrowie;

        GetComponent<Text>().text = points.ToString();
	}
}
