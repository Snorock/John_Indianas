using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax;
}

public class EnemyController : MonoBehaviour {

    public Boundary bound;
    public float Speed;
   public int CountStep;
    public float yPos;
   // public GameObject player;
    
    //Rigidbody2D rigidBody;


    private Transform _transform;
    private float speed;
    private float speedUpd;
    private bool _isFacingRight = true;
    //private int WallCount;
   // private bool death = false;

    // Use this for initialization
    void Start () {
       // WallCount = 0;
        //rigidBody = GetComponent<Rigidbody2D>();
        this._transform = gameObject.GetComponent<Transform>();
        speedUpd = Speed;
        speed = Speed;
    }
	
	// Update is called once per frame
	void Update () {
        
       Vector2 pos = transform.position;

        pos += new Vector2(speed * Time.deltaTime, 0);
        transform.position = pos;
       /* Vector2 currentPosition = gameObject.GetComponent<Transform>().position;
        if (currentPosition.x >= bound.xMax )
        {
            // Debug.Log("Rcol");
            //WallCounter();
            _isFacingRight = false;
            _flip();
            speed = -speedUpd;
        }
        else if (currentPosition.x <= bound.xMin)
        {
            // Debug.Log("Lcol");
            //WallCounter();
            _isFacingRight = true;
            _flip();
            speed = speedUpd;
        }*/

       
       //rigidBody.velocity = transform.TransformDirection(-speed, 0.0f, 0.0f);
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.CompareTag("GWall"))
        {
            speed = -speed;
           
            _isFacingRight = !_isFacingRight;
            _flip();

        }
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        
       
        if (col.gameObject.CompareTag("Coin"))
        {
            //player.SendMessage("UpdScore", -1);
        }

       /* WallCount++;*/
       // Debug.Log("Col");
        if (col.gameObject.CompareTag("Wall")||col.gameObject.CompareTag("Player"))
        {
            speed = -speed;
           // Debug.Log("col");
            _isFacingRight = !_isFacingRight;
            _flip();
            
        }
     
    }
    /*private void WallCounter()
    {
        WallCount++;
        if (WallCount >= CountStep && speedUpd < 100)
        {
            speedUpd = 3 * speedUpd;
            speedUpd = speedUpd / 2;
            Debug.Log(speedUpd);
            WallCount = 0;
        }
    }*/

    private void _flip()
    {

        if (this._isFacingRight)
        {
            this._transform.localScale = new Vector3(0.8f, 0.8f, 0.8f); // flip back to normal
        }
        else
        {
            this._transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);
        }
    }

    public void _Reset()
    {
        _isFacingRight = true;
        this._flip();
        speedUpd = Speed;
        speed = Speed;
        Vector2 resetPosition = new Vector2(Random.Range(bound.xMin, bound.xMax), yPos);
        gameObject.GetComponent<Transform>().position = resetPosition;
    }

}

