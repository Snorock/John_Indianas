using UnityEngine;
using System.Collections;

public class BgController : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 X = new Vector3 (player.gameObject.GetComponent<Transform>().position.x, 50f, 1f);
       // X = player.gameObject.GetComponent<Transform>().position.x;
         this.gameObject.GetComponent<Transform>().position = X;
    }
}
