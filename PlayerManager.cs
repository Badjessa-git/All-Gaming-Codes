using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public float speedX;
	public float jumpSpeedY;
    public Vector3 respawnPoint;
    public LevelManager gameLevelManager;
    private LifeManager lifeManager;
    

    bool facingRight, Jumping, isGrounded;
	float speed;
	Animator anim;

	Rigidbody2D rb;


	// Use this for initialization
	void Start () {

        lifeManager = FindObjectOfType<LifeManager>();
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		facingRight = true;
        respawnPoint = transform.position;
        gameLevelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		MovePlayer(speed);
		flip ();

            //left player movement
        if (Input.GetKeyDown (KeyCode.LeftArrow))
        {
			speed = -speedX;
		}
		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			speed = 0;
		}

		//right player movement
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			speed = speedX;
		}
		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			speed = 0;
		}

		//jumping movement
		if (Input.GetKeyDown (KeyCode.UpArrow) && isGrounded) {

            Jump();
            GetComponent<AudioSource>().Play();
		}
	}
	void MovePlayer(float playerSpeed)
	{
		//for player movement
		if (playerSpeed < 0 && !Jumping || playerSpeed > 0 && !Jumping)
        {
			anim.SetInteger("State",1); 
		}
		if(playerSpeed == 0 && !Jumping)
        {
			anim.SetInteger("State",0);		
		}
		rb.velocity = new Vector3(speed, rb.velocity.y, 0);
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "ground" || other.gameObject.tag == "MovingPlatform") {
            isGrounded = true;
			Jumping = false;
			anim.SetInteger ("State", 0);
		}
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
        if(other.gameObject.tag == "Slide")
        {
            isGrounded = true;
            Jumping = false;
            anim.SetInteger("State", 3);
        }
       
    }
	void flip(){
	//flip player direction
		if(speed > 0 &&!facingRight || speed < 0 && facingRight){
			facingRight = !facingRight;

			Vector3 temp = transform.localScale;
				temp.x *= -1;
			transform.localScale = temp;
		}

	}

	public void WalkLeft(){
		speed = -speedX;
	}
	public void WalkRight(){
		speed = speedX;
	}
    public void Jump()
    {
        if (isGrounded)
        {
            isGrounded = false;
            Jumping = true;
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));
            anim.SetInteger("State", 2);
            GetComponent<AudioSource>().Play();
        }
       
    }
    public void StopMoving()
    {
        speed = 0;
    }

    void OnCollisionExit2D(Collision2D other)
        {
            if (other.transform.tag == "MovingPlatform")
            {
                transform.parent = null;
            }
        }
   public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetector")
        {
            lifeManager.Takelife();
            gameLevelManager.Respawn();
            
        }
        if(collision.tag == "Checkpoint")
        {
            respawnPoint = collision.transform.position;
        }
    }

}
