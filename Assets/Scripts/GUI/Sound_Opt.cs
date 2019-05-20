using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Sound_Opt : MonoBehaviour
{
    Button btnExit;
    Button btnOpt;
    Button btnStart;

    public Slider all;
    public Slider music;
    public Slider effects;

    public AudioMixer all_s;

    // Use this for initialization
    void Start ()
    {
        btnExit = GameObject.Find("Exit").GetComponent<Button>();
        btnStart = GameObject.Find("Start").GetComponent<Button>();
        btnOpt = GameObject.Find("Options").GetComponent<Button>();

        all = GameObject.Find("all").GetComponent<Slider>();
        music = GameObject.Find("Slider").GetComponent<Slider>();
        effects = GameObject.Find("Slider (1)").GetComponent<Slider>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        all = GameObject.Find("all").GetComponent<Slider>();
        music = GameObject.Find("Slider").GetComponent<Slider>();
        effects = GameObject.Find("Slider (1)").GetComponent<Slider>();

        if (GetComponent<Canvas>().enabled)
        {
            all_s.SetFloat("Master", all.value);
            all_s.SetFloat("Musicas", music.value);
            all_s.SetFloat("Effectis", effects.value);
        }
	}

    public void btn_Exit()
    {
        GetComponent<Canvas>().enabled = false;
        btnExit.enabled = true;
        btnStart.enabled = true;
        btnOpt.enabled = true;
        //all_s.FindSnapshot("Pause").TransitionTo(0.01f);
        all_s.SetFloat("Master", all.value - 20);
    }
}
