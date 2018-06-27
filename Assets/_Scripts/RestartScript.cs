using UnityEngine;
using System.Collections;

public class RestartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            Application.LoadLevel("Level1");
        }

    }
    public void _Back()
    {
        Application.LoadLevel("MainMenu");
    }
}
