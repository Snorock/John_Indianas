using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionStay2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Platform") && !col.gameObject.CompareTag("Coin") && !col.gameObject.CompareTag("Wall") && !col.gameObject.CompareTag("GWall"))
        Destroy(gameObject);
    }
}
