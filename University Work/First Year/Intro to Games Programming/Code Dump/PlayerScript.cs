using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	// These are the types used
	public Texture2D bullet;
	public GameObject respawnPoint;
	public GameObject player;
	public GameObject plasma;
	public GameObject gun;
	public AudioClip dead;
	public AudioClip footSteps;
	public AudioClip jump;
	public AudioClip pickUp;
	public Texture2D crosshair;
	float timeToDisable = 0.0f;
	public int charges = 0;
	public int lives = 3;
	const int capacity = 6;
	public int ammo = 24;
	public int score;
	public int currentClip;
	public int ammoSpent = 0;
	// This is a co-routine to load the GameOver screen
	IEnumerator LoadGameOver()
		{
				yield return new WaitForSeconds (audio.clip.length);
				Application.LoadLevel ("GameOver");
		}

	// Use this for initialization
	void Start () 
	{
		Screen.showCursor = false;
		// This sets the ammo at the start of the game
		charges = ammo;
		currentClip = capacity;
	}

	// Update is called once per frame
	void Update () 
	{
		//These lines are for footstep and jump sounds
		if (Input.GetButton ("Horizontal") || Input.GetButton ("Vertical")) 
				{
						if (!audio.isPlaying) 
						{
								audio.clip = footSteps;
								audio.loop = true;
								audio.Play ();
						}
				} else if (Input.GetButtonUp ("Horizontal") || Input.GetButtonUp ("Vertical")) 
				{
						audio.loop = false;
						audio.Stop ();
				}
		if (Input.GetButtonDown ("Jump")) 
				{
						audio.PlayOneShot (jump);
				}
		// This is updating the score on the GameData
		GameObject gameData = GameObject.Find ("GameData");
		if (gameData != null) 
				{
						GameDataScript gameDataScript = gameData.GetComponent<GameDataScript> ();
						gameDataScript.score = score;
				}
						// This is code for reloading
						if (ammo <= 0) 
						{
								charges = 0;
						}	

						if (Input.GetKeyDown ("r")) 
						{
	
								if (ammo > 0) 
								{
								
										if (ammo >= 6) 
										{
												currentClip = capacity;
										} else 
										{
												currentClip = ammo;
										}


										ammo -= ammoSpent; 
										ammoSpent = 0;
										charges = ammo;					
			
								}
						}
						// This is for the gun shooting and hitting targets, it also updates the score
						if (gun.activeSelf) 
						{
								if (timeToDisable <= 0.0f) 
								{
										plasma.SetActive (false); 
								} else 
								{
										timeToDisable -= Time.deltaTime;
								}
								if (Input.GetButtonDown ("Fire1")) 
								{
										if (currentClip > 0) 
										{
												ammoSpent++;
												currentClip--;
												plasma.SetActive (true);
												timeToDisable = 0.3f;
												gun.audio.Play ();
												Ray ray = 
						Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0));
												RaycastHit hit = new RaycastHit ();
												if (Physics.Raycast (ray, out hit)) 
												{
														if (hit.collider.gameObject.tag == "Target") 
														{
																TargetScript targetScript = 
								hit.collider.gameObject.GetComponent<TargetScript> ();
																if (targetScript != null) 
																{
																		targetScript.HitApplyForce (ray.direction, 1000.0f);
																		score++;
																}
							
														}
												}		
										}
								}
						}
	}

		
		void OnControllerColliderHit(ControllerColliderHit hit)
		{
			// This is to check if you hit an obstacle and if so remove a life and respawn you
			if (hit.gameObject.tag == "Respawn") 
				{
						lives--;
						audio.clip = dead;
						audio.Play ();
						if (lives >= 0) {
								player.transform.position = respawnPoint.transform.position;
						}
						if (lives < 0) {
								StartCoroutine (LoadGameOver ());
						}
				}
				//	This is the pistol pickup 
				if (hit.gameObject.name == "pistol") 
				{
						Destroy (hit.gameObject);
						gun.SetActive (true);
						audio.clip = pickUp;
						audio.Play ();
				} 
				// Life pickup 
				else if (hit.gameObject.name == "life") 
				{
						Destroy (hit.gameObject);
						lives++;
						audio.clip = pickUp;
						audio.Play ();
				} 
				//Ammo pickup
				else if (hit.gameObject.name == "ammo") 
				{
						Destroy (hit.gameObject);
						charges = charges + 18;
						ammo = ammo + 18;
						audio.clip = pickUp;
						audio.Play ();		
				}
	
	
		}
	void OnGUI()
	{
		// This is to show crosshairs
		if (gun.activeSelf) 
				{
						GUI.Label (new Rect (Screen.width / 2 - 10, 
			                   Screen.height / 2 - 10, 10, 10), crosshair);
				}
		GameObject gameData = GameObject.Find ("GameData");
		//Displaying ammo and score
		GUI.Label(new Rect(Screen.width - 100, Screen.height / 2 + 140, 100, 50 ), "Lives:  " + lives );	
		int x = 720;
		for(int i = 0; i < currentClip; i++)
		{
			GUI.DrawTexture(new Rect(x, Screen.height/4, 20, 15),bullet);
			x+=8;
		}
				GUI.Label(new Rect(Screen.width - 100, Screen.height / 2 + 120, 100, 50 ), "Ammo  " + currentClip + " / " + charges);
	if (gameData != null) 
		{
						GameDataScript gameDataScript = gameData.GetComponent<GameDataScript> ();
			GUI.Label (new Rect (10, 10, 100, 40),
			           gameDataScript.playerName + "   score:  " + score.ToString ());
		}
	}

}
