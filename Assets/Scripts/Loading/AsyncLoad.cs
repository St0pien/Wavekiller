using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncLoad : MonoBehaviour
{
    string scenename;

    public GameObject slider;
	// Use this for initialization
	void Start ()
    {
        scenename = Load.getloadscene();
        StartCoroutine(LoadSceneAsync());
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(scenename);

        while(!sceneLoading.isDone)
        {
            Debug.Log(sceneLoading.progress);
            slider.GetComponent<Slider>().value = sceneLoading.progress;
            yield return null;
        }
    }
}
