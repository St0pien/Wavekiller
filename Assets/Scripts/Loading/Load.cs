using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    static string loadingScene; //Scene to be loaded

    public static void LoadScene(string sceneName)
    {
        loadingScene = sceneName;
        SceneManager.LoadScene("loadScreen");
    }

    public static string getloadscene()
    {
        return loadingScene;
    }
}
