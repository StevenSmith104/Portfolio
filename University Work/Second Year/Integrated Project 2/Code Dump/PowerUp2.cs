using UnityEngine;
using System.Collections;

public class PowerUp2 : MonoBehaviour {

	public float enableTime = 0.0f;
	public GameObject iceScreen;
	public AudioClip frostStart;

	// Use this for initialization
	void Start () 
	{

	}

	void OnEnable()
	{
		iceScreen.SetActive (true);
		enableTime = Time.time;
		audio.PlayOneShot (frostStart);
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Time.time - enableTime >= 15.0f) {
			Player1.player.movementSpeed = 10.0f;
			Player2.player.movementSpeed = 10.0f;
			iceScreen.SetActive (false);
			this.enabled = false;
		} else {
			Player1.player.movementSpeed = 2.5f;
			Player2.player.movementSpeed = 2.5f;
		}
	}
}
