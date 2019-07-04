using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public GameObject shovel;
    float time=0;
    bool map=false;

    public AudioClip dig;
    AudioSource sndShovel;

    public GameObject stats;
    public GameObject stats1;

    public int wave;

	// Use this for initialization
	void Start ()
    {
        sndShovel = shovel.GetComponent<AudioSource>();
        Time.timeScale = 1;
        Instantiate(stats);
        GameObject waves = Instantiate(stats1);
        waves.GetComponent<TextMesh>().text = Load.getWaves() + " waves of enemies";
    }

    // Update is called once per frame
    void Update ()
    {
        time += Time.deltaTime;

        //Show shovel
	    if(Input.GetKeyDown(KeyCode.Space))
        {
            shovelAnim();
        }

        //Back to menu
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Load.LoadScene("MEnu", null);
        }

        //Restart Game
        if(time > 1 && map)
        {
            Load.LoadScene("MAP", null);
        }
	}

    void shovelAnim()
    {
        if(!map)
        {
            map = true;
            time = 0;
            Instantiate(shovel);
        }
    }
}
