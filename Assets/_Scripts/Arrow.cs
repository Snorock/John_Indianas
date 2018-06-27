using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	public Vector3 v = new Vector3(0, 0, 0);
	public Vector3 a = new Vector3(0, -10, 0);
    public bool right = true;
    public float speed = 0.5f;

	void Start () {
		Destroy(this.gameObject, 10);
        if (!right)
            v.x = -v.x;
	}

	void Update () {

        transform.position += new Vector3 (speed, 0f, 0f);  //v*Time.deltaTime;
		//v += a * Time.deltaTime;
        
       transform.rotation = Quaternion.LookRotation(v, new Vector3(0,0,-1));
	}

    void OnCollisionStay2D (Collision2D col)
    {

        Destroy(this.gameObject);
    }
}
