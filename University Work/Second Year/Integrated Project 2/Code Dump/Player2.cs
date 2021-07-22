using UnityEngine;
using System.Collections;

[RequireComponent (typeof (P2Controller2D))]
public class Player2 : MonoBehaviour 
{
	public static Player2 player;
	public Respawn respawn;
	
	P2Controller2D controller;

	public GameObject playerSprite;
	public int health = 3;
	public float movementSpeed;
	public float JumpHeight;
	public float timeToJumpApex = 0.5f;
	public float wallSlideSpeedMax = 1f;
	public Vector2 wallJumpClimb;
	public Vector2 wallJumpOff;
	public Vector2 wallLeap;
	public bool facingRight = false;
	float gravity;
	float jumpVelocity;
	Vector3 velocity;
	
	float velocityXSmoothing;
	float accelerationTimeAirborne = 0.175f;
	float accelerationTimeGrounded = 0;
	
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	private bool hasFired = false;

	public float explodeTime = 2.0f;
	public float explodeTimer = 0.0f;

	public Animator anim;

	public AudioClip fire;
	public AudioClip jump;
	public AudioClip hit;
	public AudioClip squish;
	
	void Awake ()
	{
		if (player == null)
		{
			//DontDestroyOnLoad (gameObject);
			player = this;
		}
		else if (player != this)
		{
			Destroy (gameObject);
		}
	}
	
	void Start ()
	{
		controller = GetComponent<P2Controller2D>();
		GameObject respawnPoint = GameObject.FindGameObjectWithTag("Respawn");
		respawn = respawnPoint.GetComponent<Respawn> ();

		gravity = -(2 * JumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs (gravity) * timeToJumpApex;

		anim = playerSprite.GetComponent<Animator> ();

		gameObject.name = "Player2";

		explodeTimer = 0.0f;
	}

	public void Hit()
	{
		audio.PlayOneShot(hit);
	}

	public void Squish()
	{
		audio.PlayOneShot(squish);
	}
	void Update ()
	{
		Vector2 movement = new Vector2 (Input.GetAxisRaw ("P2HorizontalLStick"), Input.GetAxisRaw ("P2VerticalLStick"));
		int wallDirX = (controller.collisions.left)? -1: 1;
		
		float targetVelocityX = movement.x * movementSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);

		anim.SetBool ("Grounded", controller.collisions.below);
		anim.SetFloat ("Speed", Mathf.Abs (velocity.x));

		bool wallSliding = false;
		
		if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
		{
			wallSliding = true;
			if (velocity.y < -wallSlideSpeedMax)
			{
				velocity.y = -wallSlideSpeedMax;
			}
		}
		
		if (controller.collisions.above || controller.collisions.below)
		{
			velocity.y = 0;
		}

		if (Input.GetButtonDown ("P2Fire1") && Time.time > nextFire)
		{
			if (hasFired == false)
			{
				nextFire = Time.time + fireRate;
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
				hasFired = true;
				audio.PlayOneShot (fire);
			}
		}
		
		if (Input.GetButtonUp ("P2Fire1"))
		{
			hasFired = false;
		}

		/*
		if (Input.GetAxisRaw ("P2Fire1") != 0 && Time.time > nextFire && wallSliding == false)
		{
			if (hasFired == false)
			{
				nextFire = Time.time + fireRate;
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
				hasFired = true;
			}
		}
		
		if (Input.GetAxisRaw ("P2Fire1") == 0)
		{
			hasFired = false;
		}
		*/
		if (Input.GetButtonDown ("P2Jump"))
		{
			if (wallSliding == true)
			{
				if (wallDirX > 0 || wallDirX < 0)
				{
					velocity.x = -wallDirX * wallJumpClimb.x;
					velocity.y = wallJumpClimb.y;
					audio.PlayOneShot (jump);
				}
				else if (movement.x == 0)
				{
					velocity.x = -wallDirX * wallJumpOff.x;
					velocity.y = wallJumpOff.y;
					audio.PlayOneShot (jump);
				}
			}
			
			if (controller.collisions.below)
			{
				velocity.y = jumpVelocity;
				anim.SetBool ("Grounded", false);
				audio.PlayOneShot (jump);
			}
		}

		if (Input.GetButton("P2Explode"))
		{
			explodeTimer += Time.deltaTime;
			
			if ( explodeTimer > explodeTime)
			{
				respawn.P2StartRespawn ();
				Destroy (gameObject);
			}
		}
		
		if (Input.GetButtonUp ("P2Explode")) 
		{
			explodeTimer = 0.0f;
		}
		
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);

		if (movement.x > 0 && !facingRight)
		{
			Flip ();
		}
		else if (movement.x < 0 && facingRight)
		{
			Flip ();
		}

		if (health <= 0)
		{
			respawn.P2StartRespawnShot ();
			Destroy (gameObject);
		}
	}

	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = playerSprite.transform.localScale;
		theScale.x *= -1;
		playerSprite.transform.localScale = theScale;
	}
}