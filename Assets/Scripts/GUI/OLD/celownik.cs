using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class celownik : MonoBehaviour
{

    public Texture2D Cross;
    public Rect position;
    public bool visible;

	// Use this for initialization
	void Start ()
    {
        position = new Rect((Screen.width - Cross.width) / 2, (Screen.height - Cross.height) / 2, Cross.width, Cross.height);
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void OnGUI ()
    {
		if(visible)
        {
            GUI.DrawTexture(position, Cross);
        }
	}
}
