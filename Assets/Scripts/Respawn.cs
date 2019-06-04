using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject ammo;
    Vector3 XYZ;

    float a;
    float b;

    float x;
    float z;

    float czas = 5;

    int fala = 0;
    float ile;

    public GameObject stats;

	// Use this for initialization
	void Start ()
    {
        XYZ.y = 100;
    }
	
	// Update is called once per frame
	void Update ()
    {
        czas -= Time.deltaTime;
        if (czas <= 0)
        {
            czas = 10;
            fala++;
            ile = Mathf.Round((fala / 3) + 1);

            for (int i = 1; i <= ile; i++)
            {
                do
                {
                    a = Camera.main.transform.position.x;
                    b = Camera.main.transform.position.z;

                    x = Random.Range(a - 50, a + 50);
                    z = Random.Range(b - 50, b + 50);
                } while (x < 50 || z < 50 || x > 900 || z > 900);
                XYZ.x = x;
                XYZ.z = z;
                GameObject.Instantiate(enemyPrefab, XYZ, Quaternion.identity);
            }
            Vector3 ammovec = new Vector3(x + Random.Range(-10, 10), 100, z + Random.Range(-10, 10));
            Instantiate(ammo, ammovec, Quaternion.identity);
            czas += fala;
            updateWave();
        }
    }

    void updateWave()
    {
        int fal = fala - 1;
        string wave = fal.ToString();
        stats.GetComponent<TextMesh>().text = wave + " waves of enemies";
    }
}
