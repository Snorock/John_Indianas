using UnityEngine;
using System.Collections;

public class ManController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void _Back()
    {
        Application.LoadLevel("MainMenu");
    }
}
