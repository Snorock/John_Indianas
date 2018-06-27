using UnityEngine;
using System.Collections;




public class EnemyDeath : MonoBehaviour {
    public GameObject enemy;
    public GameObject enemyPack;

	// Use this for initialization
	void Start () {
	//enemy = GameObject.FindGameObjectsWithTag("Enenmy");
    
    }
	
	// Update is called once per frame
	void Update () {
        this.gameObject.GetComponent<Transform>().position = enemy.gameObject.GetComponent<Transform>().position;
	}

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player")) {
            // var enemyctrl : EnemyController = enemy.GetComponent ( EnemyController);
            // enemy
            //var enemyctrl =  enemy.gameObject.GetComponent<EnemyController>;
            //enemy.SendMessage("_Reset");
            Destroy(enemyPack);
           // Destroy(this);
        }
    }
}
