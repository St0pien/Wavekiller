using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SNDOP : MonoBehaviour
{
    public Button btnExit;
    public Button btnOpt;
    public Button btnStart;

    public Slider all;
    public Slider music;
    public Slider effects;

    public AudioMixer all_s;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
