﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (P1Controller2D))]
public class Player1 : MonoBehaviour 
{
	/*
	public float movementSpeed;
	public float moveHorizontal;
	public float defaultSpeed;
	public float jumpVelocity;

	public bool facingRight = true;

	public bool grounded = false;
	public bool wallContact = false;
	public Transform groundCheckA;
	public Transform groundCheckB;
	public Transform leftWallCheckA;
	//public Transform leftWallCheckB;
	//public Transform rightWallCheckA;
	public Transform rightWallCheckB;
	public LayerMask whatIsGround;
	public LayerMask whatIsWall;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
*/
	public static Player1 player;
	public Respawn respawn;

	P1Controller2D controller;

	public GameObject playerSprite;
	public int health = 3;
	public float movementSpeed = 5f;
	public float JumpHeight = 5f;
	public float timeToJumpApex = 0.5f;
	public float wallSlideSpeedMax = 1f;
	public Vector2 wallJumpClimb;
	public Vector2 wallJumpOff;
	public Vector2 wallLeap;
	public bool facingRight = true;
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
			player = this;
		}
		else if (player != this)
		{
			Destroy (gameObject);
		}
	}

	void Start ()
	{
		controller = GetComponent<P1Controller2D> ();
		GameObject respawnPoint = GameObject.FindGameObjectWithTag("Respawn");
		respawn = respawnPoint.GetComponent<Respawn> ();

		gravity = -(2 * JumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs (gravity) * timeToJumpApex;
		//print ("Gravity: " + gravity + " Jump Velocity: " + jumpVelocity);

		anim = playerSprite.GetComponent<Animator> ();

		gameObject.name = "Player1";

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
		Vector2 movement = new Vector2 (Input.GetAxisRaw ("P1HorizontalLStick"), Input.GetAxisRaw ("P1VerticalLStick"));
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

		if (Input.GetButtonDown ("P1Fire1") && Time.time > nextFire)
		{
			if (hasFired == false)
			{
				nextFire = Time.time + fireRate;
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
				hasFired = true;
				audio.PlayOneShot (fire);
			}
		}

		if (Input.GetButtonUp ("P1Fire1"))
		{
			hasFired = false;
		}

		if (Input.GetButtonDown ("P1Jump"))
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

		if (Input.GetButton("P1Explode"))
		{
			explodeTimer += Time.deltaTime;
			
			if ( explodeTimer > explodeTime)
			{
				respawn.P1StartRespawn ();
				Destroy (gameObject);
			}
		}
		
		if (Input.GetButtonUp ("P1Explode")) 
		{
			explodeTimer = 0.0f;
		}

		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);

		//float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		if (movement.x > 0 && !facingRight)
		{
			Flip ();
			//shotSpawnRotate.SetFacingRight ();
		}
		else if (movement.x < 0 && facingRight)
		{
			Flip ();
			//shotSpawnRotate.SetFacingLeft ();
		}

		if (health <= 0)
		{
			respawn.P1StartRespawnShot ();
			Destroy (gameObject);
		}
	}

	/*
	void Update () 
	{
		if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}

		if (Input.GetKeyDown (KeyCode.Space) && grounded == true)
		{
			grounded = false;
			GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, jumpVelocity));
		}

		//GetAxisRaw is used as it returns either 1 or 0 which results in snappier movement
		moveHorizontal = Input.GetAxisRaw ("Horizontal");
	}

	void FixedUpdate ()
	{
		//grounded returns true when objects with layer selected for whatIsGround is detected in the area between groundCheckA and B
		//and when player's y velocity is 0
		grounded = Physics2D.OverlapArea (groundCheckA.position, groundCheckB.position, whatIsGround) && GetComponent<Rigidbody2D>().velocity.y == 0;
		wallContact = Physics2D.OverlapArea (leftWallCheckA.position, rightWallCheckB.position, whatIsWall);

		GetComponent<Rigidbody2D>().velocity = new Vector2(moveHorizontal * movementSpeed, GetComponent<Rigidbody2D>().velocity.y);

		if (moveHorizontal > 0 &&!facingRight)
		{
			Flip ();
			shotSpawn.rotation = Quaternion.Euler (0, 0, 0);
		}
		else if (moveHorizontal < 0 &&facingRight)
		{
			Flip ();
			shotSpawn.rotation = Quaternion.Euler (0, 180, 0);
		}
	}
*/
	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = playerSprite.transform.localScale;
		theScale.x *= -1;
		playerSprite.transform.localScale = theScale;
		//gun.localScale *= -1;
	}
}