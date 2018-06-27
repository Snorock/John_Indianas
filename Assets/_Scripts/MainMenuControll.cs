using UnityEngine;
using System.Collections;

public class MainMenuControll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void _Start ()
    {
        Application.LoadLevel ("Level1");
    }
    public void _Manual()
    {
        Application.LoadLevel("Manual");
    }
    public void _Exit()
    {
        Application.Quit();
    }

}
