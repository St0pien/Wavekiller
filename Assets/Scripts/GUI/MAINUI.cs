using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MAINUI : MonoBehaviour
{
    public GameObject Help;
    public GameObject Flames;

	// Use this for initialization
	public void B_Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Load.LoadScene("MAP", null);
    }
	
	// Update is called once per frame
	public void B_Exit ()
    {
        Application.Quit();
	}

    public void help()
    {
        Flames.SetActive(false);
        Help.SetActive(true);
        Debug.Log("help");
    }

    public void back()
    {
        Flames.SetActive(true);
        Help.SetActive(false);
        Debug.Log("back");
    }

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
