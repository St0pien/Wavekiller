using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling : MonoBehaviour
{
    public GameObject [] hud;

    float wid;
    float hei;
    public float dif; //diference

    public GameObject HUD_prefab;

	// Use this for initialization
	void Start ()
    {      
        hud = new GameObject [9];
        hud[0] = GameObject.Find("Cross");
        hud[1] = GameObject.Find("HP_points");
        hud[2] = GameObject.Find("Karabin");
        hud[3] = GameObject.Find("RPG");
        hud[4] = GameObject.Find("pasek_tło");
        hud[5] = GameObject.Find("stamina");
        hud[6] = GameObject.Find("Ammo");
        hud[7] = GameObject.Find("Cross");
        hud[8] = GameObject.Find("Trafienie");

        wid = Screen.width;
        hei = Screen.height;
        //Debug.Log(Screen.width+" "+Screen.height);
        dif = (Screen.width - 1234)/17;

        if (wid > 3000)
        {
            forfourk();
        }
        else
        {
            foreach (GameObject obj in hud)
            {
                Vector3 cords = obj.GetComponent<RectTransform>().transform.localScale;

                //obj.GetComponent<RectTransform>().transform.localScale.Set(cords.x*(wid/1920), cords.y*(hei/1080), cords.z);
                obj.GetComponent<RectTransform>().transform.localScale = new Vector3(cords.x * (wid / 1234), cords.y * (hei / 652));
                //Debug.Log("co jest "+obj.name);

                if (obj == hud[6] || obj == hud[1])
                {
                    Vector3 xy = obj.GetComponent<RectTransform>().transform.localPosition;
                    obj.GetComponent<RectTransform>().transform.localPosition = new Vector3(xy.x + dif, xy.y);
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void forfourk()
    {
        GameObject oldHUD = GameObject.Find("HUD");
        Destroy(oldHUD);
        GameObject newHUD = Instantiate(HUD_prefab);

        newHUD.transform.SetParent(GameObject.Find("Interfejs").transform);
        //Debug.Log("newHud is true");
    }
}
