using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    static string loadingScene; //Scene to be loaded
    static string waves;

    public static void LoadScene(string sceneName, string wave)
    {
        loadingScene = sceneName;
        SceneManager.LoadScene("loadScreen");
        waves = wave;
    }

    public static string getloadscene()
    {
        return loadingScene;
    }

    public static string getWaves()
    {
        return waves;
    }
}
