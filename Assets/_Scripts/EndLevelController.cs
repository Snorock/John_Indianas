﻿using UnityEngine;
using System.Collections;

public class EndLevelController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionStay2D (Collision2D col)
    {
        if (col.gameObject.CompareTag ("Player"))
        {
            Application.LoadLevel("GameOver1");
        }
    }
}
