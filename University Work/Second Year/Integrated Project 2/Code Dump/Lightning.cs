using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour {

	public float enableTime = 0.0f;


	void Start()
	{
		enableTime = Time.time;
	}
	
	// Use this for initialization

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Block" || col.gameObject.tag == "Placed" || col.gameObject.tag == "Powerup") 
		{
			Destroy (col.gameObject);
		} 
		else if (col.gameObject.tag == "Player") 
		{
			Player1.player.health = 0;
		} 
		else if (col.gameObject.tag == "Player2") 
		{
			Player2.player.health = 0;
		}
	}
	// Update is called once per frame
	void Update () 
	{
		if (Time.time - enableTime >= 0.5f) 
		{
			Destroy(gameObject);
		}
	}
}
