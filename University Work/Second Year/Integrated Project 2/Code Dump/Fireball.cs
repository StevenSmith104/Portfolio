using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

	// Use this for initialization
	void Start()
	{

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Block" || col.gameObject.tag == "Placed" || col.gameObject.tag == "Powerup") 
		{
			Destroy (col.gameObject);
			Destroy (gameObject);
		} 
		else if (col.gameObject.tag == "Player") 
		{
			Player1.player.health = 0;
			Destroy (gameObject);
		} 
		else if (col.gameObject.tag == "Player2") 
		{
			Player2.player.health = 0;
			Destroy (gameObject);
		}
		else if (col.gameObject.tag == "Arena")
		{
			Destroy(gameObject);
		}
	}
}
