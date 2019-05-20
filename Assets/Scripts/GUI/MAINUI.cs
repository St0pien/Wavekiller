using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MAINUI : MonoBehaviour
{

	// Use this for initialization
	public void B_Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Load.LoadScene("MAP");
    }
	
	// Update is called once per frame
	public void B_Exit ()
    {
        Application.Quit();
	}

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
