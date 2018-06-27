using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// VELOCITYRANGE UTILITY CLASS
[System.Serializable]
public class VelocityRange
{
    // PUBLIC INSTANC VARIABLES
    public float vMin, vMax;

    // CONSTRUCTOR +++++++++++++++++++++++++++++++
    public VelocityRange(float vMin, float vMax)
    {
        this.vMin = vMin;
        this.vMax = vMax;
    }
}

// PLAYERCONTROLLER CLASS
public class PlayerController : MonoBehaviour
{
    //TESTING
    public Transform target;

    public float moveSpeed;
    public float jumpHeight;
    Rigidbody2D rigidBody;
    bool facingright;

    //PUBLIC INSTANCE VARIABLES +++++++++++++++++++++++++++++++
    public float speed = 50f;
    public float jump = 500f;
    public int Lives = 3;
    public Text scorelbl;
    public Text liveslbl;
   // public AudioClip explosion;
    public AudioClip pickup;
    public float vol = 0.8f;
    public VelocityRange velocityRange = new VelocityRange(300f, 1000f);
    public GameObject Exit;


    //PRIVATE INSTANCE VARIABLES ++++++++++++++++++++++++++++++
    private Rigidbody2D _rigidBody2D;
    private Transform _transform;
    private Animator _animator; // we'll use this later
    private int score = 0;
    private int lives;
   private int scoreCount = 0;
  private AudioSource _audioSource;

  private AudioSource _coinSound;
 // private AudioSource _deathSound;

    private float _movingValue = 0;
    private bool _isFacingRight = true;
    private bool _isGrounded = true;

    // Use this for initialization
    void Start()
    {
        //TEST
        rigidBody = GetComponent<Rigidbody2D>();

        this._rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        this._transform = gameObject.GetComponent<Transform>();
        this._animator = gameObject.GetComponent<Animator>();
       lives = Lives;
        liveslbl.text = lives.ToString();
        scorelbl.text = "0/3";

        this._audioSource = gameObject.GetComponent<AudioSource>();
      // this._coinSound = this._audioSources[0];
        //this._jumpSound = this._audioSources[1];
    }

    void FixedUpdate()
    {
        Debug.DrawLine(transform.position, target.position);
        float forceX = 0f;
        float forceY = 0f;

        RaycastHit2D _ground = Physics2D.Linecast(transform.position, target.position, 1 << LayerMask.NameToLayer("Platform"));
        //if (Physics2D.Linecast(transform.position, target.position, 1<<LayerMask.NameToLayer("Platform")))
        if (_ground.collider != null)
        {
            _isGrounded = true;
           // Debug.Log(_isGrounded);
        }
       else
        {
            _isGrounded = false;
           // Debug.Log(_isGrounded);
        }

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            //this._animator.SetInteger("AnimState", 2);
            forceY += jumpHeight;
           // _isGrounded = false;
            
           // rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpHeight);


           
        }
        if (Input.GetKey(KeyCode.D))
        {
           // rigidBody.velocity = new Vector2(moveSpeed, rigidBody.velocity.y);

            _isFacingRight = true;
            _flip();
            forceX += moveSpeed;
           // if (_isGrounded)
          //  this._animator.SetInteger("AnimState", 1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
           // rigidBody.velocity = new Vector2(-moveSpeed, rigidBody.velocity.y);
            _isFacingRight = false;
            _flip();
            forceX -= moveSpeed;
           // if(_isGrounded)
           // this._animator.SetInteger("AnimState", 1);
        }

        if (!_isGrounded)
            this._animator.SetInteger("AnimState", 2);
        else if (rigidBody.velocity.x != 0)
            this._animator.SetInteger("AnimState", 1);
        else
            this._animator.SetInteger("AnimState", 0);

        /*if (_isGrounded)
        {
            this._animator.SetInteger("AnimState", 0);
        }*/

        // if (rigidBody.velocity.x == 0 && _isGrounded)
        //      this._animator.SetInteger("AnimState", 0);



        /*  if (rigidBody.velocity.x < 0 && !facingright)
          {
              _flip();
          }
          if (rigidBody.velocity.x > 0 && facingright)
          {
              _flip();
          }*/

        /*
        float forceX = 0f;
        float forceY = 0f;

        float absVelX = Mathf.Abs(this._rigidBody2D.velocity.x);
        float absVelY = Mathf.Abs(this._rigidBody2D.velocity.y);

        this._movingValue = Input.GetAxis("Horizontal"); // value is between -1 and 1

        // check if player is moving

        if (this._movingValue != 0)
        {
            // we're moving
            this._animator.SetInteger("AnimState", 1); // play walk clip
            if (this._movingValue > 0)
            {
                // moving right
                if (absVelX < this.velocityRange.vMax)
                {
                    forceX = this.speed;
                    this._isFacingRight = true;
                    this._flip();
                }
            }
            else if (this._movingValue < 0)
            {
                // moving left
                if (absVelX < this.velocityRange.vMax)
                {
                    forceX = -this.speed;
                    this._isFacingRight = false;
                    this._flip();
                }
            }
        }
        else if (this._movingValue == 0)
        {
            // we're idle
            this._animator.SetInteger("AnimState", 0);
        }

        // Check if player is jumping

        if ((Input.GetKey("up") || Input.GetKey(KeyCode.W)))
        {
            // check if the player is grounded
            if (this._isGrounded)
            {
                // player is jumping
                this._animator.SetInteger("AnimState", 2);
                if (absVelY < this.velocityRange.vMax)
                {
                    forceY = this.jump;
                    //this._jumpSound.Play();
                    this._isGrounded = false;
                    Debug.Log(_isGrounded.ToString());

                }
            }

        }

        this._rigidBody2D.AddForce(new Vector2(forceX, forceY));*/
        Vector2 old = rigidBody.velocity;
        rigidBody.velocity = new Vector2(old.x/15 + forceX, old.y + forceY);
    }

    /* void OnCollisionEnter2D(Collision2D otherCollider)
     {
         if (otherCollider.gameObject.CompareTag("Coin"))
         {
             this._coinSound.Play();
         }
     }*/

    void OnCollisionEnter2D(Collision2D otherCollider)
    {
        /*if (otherCollider.gameObject.CompareTag("Platform"))
        {
            
           // this._isGrounded = true;
            
            //  Debug.Log(_isGrounded.ToString());

        }*/
         if (otherCollider.gameObject.CompareTag("Enemy") || otherCollider.gameObject.CompareTag("Arrow"))
        {
            
            //   _audioSource.PlayOneShot(explosion);
              UpdLives(-1);
            //Debug.Log("COL");
        }
         if (otherCollider.gameObject.CompareTag("Coin"))
        {
            _audioSource.PlayOneShot(pickup);
            UpdScore(1);
            //Destroy(otherCollider.gameObject);
        }
        if (otherCollider.gameObject.CompareTag("Water"))
        {
            UpdLives(-1);
            this.GetComponent<Transform>().position = new Vector3(0f, 4f, 0f);
        }

            /*if (otherCollider.gameObject.CompareTag("EnemyDeath"))
           {
               UpdScore(5);
           }*/
        }


    // PRIVATE METHODS +++++++++++++++++++++++++++++++++++++++
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
       // facingright = !facingright;
       /* Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;*/
    }
    private void UpdLives(int updL)
    {
        lives += updL;
        liveslbl.text = lives.ToString();
        if (lives <= 0)
        {
            Application.LoadLevel("GameOver");
        }
    }
    private void UpdScore(int updS)
    {
        score += updS;
        
        scorelbl.text = score + "/3";
        if (score == 3)
        {
            Instantiate(Exit);
        }

    }

}
