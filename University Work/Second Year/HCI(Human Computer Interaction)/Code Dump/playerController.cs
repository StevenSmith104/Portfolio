using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	public gameInformation gameInfo;
	private Animator animator;

	public float speedForce = 5.0f;
	public Vector2 jumpVector;

	public bool isGrounded;
	public Transform grounder;
	public float radius;
	public LayerMask ground;

	public GameObject player;
	public GameObject spawn;
	public int lives = 3;
	public int score = 0;

	public GameObject heart3;
	public GameObject heart2;
	public GameObject heart1;


	// Use this for initialization
	void Start () 
	{
		animator = this.GetComponent<Animator> ();

		if (player.collider2D.enabled == false) 
		{
			player.collider2D.enabled = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "spike") 
		{
			Respawn ();
		} 
		else if (other.tag == "rubbish") 
		{
			score++;
			audio.Play();
			Destroy (other.gameObject);
		} 
		else if (other.tag == "endPoint") 
		{
			Application.LoadLevel (1);
		}
	}

	void Respawn()
	{
		if (lives > 0) 
		{
			player.transform.position = spawn.transform.position;
			lives--;
			DisplayLives();
		}
		else
		{
			Application.LoadLevel("2D-Platformer-EndScene");
		}
	}

	void DisplayLives()
	{
		if (lives == 2) 
		{
			Destroy(heart3);
		}
		if (lives == 1) 
		{
			Destroy (heart2);
		}
		if (lives == 0) 
		{
			Destroy(heart1);
		}
	}
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetKey (KeyCode.A)) 
		{
			rigidbody2D.velocity = new Vector2 (-speedForce, rigidbody2D.velocity.y);
			transform.localScale = new Vector3(-1,1,1);
		} 
		else if (Input.GetKey (KeyCode.D)) 
		{
			rigidbody2D.velocity = new Vector2 (speedForce, rigidbody2D.velocity.y);
			transform.localScale = new Vector3(1,1,1);
		} 
		else 
		{
			rigidbody2D.velocity = new Vector2(0,rigidbody2D.velocity.y);
		}

		isGrounded = Physics2D.OverlapCircle (grounder.transform.position, radius, ground);

		if (Input.GetKey (KeyCode.W) && isGrounded == true) 
		{
			rigidbody2D.AddForce(jumpVector, ForceMode2D.Force);
		}
	
		var vertical = Input.GetAxis ("Vertical");
		var horizontal = Input.GetAxis ("Horizontal");

		if (vertical > 0 || vertical < 0) 
		{
			animator.SetInteger("Direction", 1);
		}
		else if (horizontal > 0 || horizontal < 0) 
		{
			animator.SetInteger("Direction", 0);
		}

	}
}
