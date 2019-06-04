using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP_Player : MonoBehaviour
{
    public float zdrowie = 100;
    public bool dostalem = false;

    public GameObject light;
    public GameObject light1;

    public AudioSource Player;
    public AudioClip AOU;

    public float blysk;

    float czas;
    float deadSeconds;

    bool death = false;

    // Use this for initialization
    void Start()
    {
        Instantiate(light);
        Instantiate(light1);
        Cursor.lockState = CursorLockMode.Locked; //Zablokowanie kursora myszy.
        Cursor.visible = false;//Ukrycie kursora.
        czas = 1.5f;
    }

    public void otrzymaneobrażenia(float amt)
    {
        dostalem = true;
        zdrowie -= amt;

        if (zdrowie <= 0)
        {
            death = true;
            deadSeconds = 0;
        }

    }
	
	public void Die() //things to do before dead
    {
        Camera.main.clearFlags = CameraClearFlags.SolidColor;
        Destroy(GameObject.Find("Directional light(Clone)"));
        Destroy(GameObject.Find("Area light(Clone)"));
        Time.timeScale = 0.15f;
        GameObject.Find("Trafienie").GetComponent<Image>().color = new Color(1, 0, 0, 0);
        GameObject.Find("Terrain").GetComponent<AudioSource>().Stop();
    }

    public bool CzyMartwy()
    {
        if(zdrowie <= 0)
        {
            return true;
        }
        return false;
    }

    private void Update()
    {
        czas -= Time.deltaTime;
        if (!dostalem)
        {
            GameObject.Find("Trafienie").GetComponent<Image>().color = Color.Lerp(GameObject.Find("Trafienie").GetComponent<Image>().color, Color.clear, blysk * Time.deltaTime);
        }
        else if (dostalem)
        {
            GameObject.Find("Trafienie").GetComponent<Image>().color = new Color(1, 0, 0, 1);
            if (czas <= 0)
            {
                Player.PlayOneShot(AOU);
                czas = 1.5f;
            }
            dostalem = false;
        }
        if(death)
        {
            Die();
            deadSeconds += Time.deltaTime;
        }
        if(deadSeconds >= 0.2 && death)
        {
            Load.LoadScene("Death");
        }

        zdrowie = Mathf.Round(zdrowie);
    }

}
