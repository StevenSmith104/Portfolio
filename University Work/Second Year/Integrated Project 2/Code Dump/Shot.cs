﻿using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour 
{
	public float speed;
	
	void Start () 
	{
		gameObject.name = "Shot";
		GetComponent<Rigidbody2D>().velocity = transform.right * speed;
	}
	
	void OnTriggerEnter2D (Collider2D otherObject)
	{
		/*
		if (otherObject.gameObject.tag == "Enemy")
		{
			StartCoroutine (OnHit ());
		}
		*/
		if (otherObject.gameObject.tag == "Block" || otherObject.gameObject.tag == "Arena" || otherObject.gameObject.tag == "Placed")
		{
			//StartCoroutine (OnHit ());
			Destroy (gameObject);
		}
		if (otherObject.gameObject.tag == "Player")
		{
			Player1.player.health--;
			Player1.player.Hit();
			Destroy (gameObject);
		}
		if (otherObject.gameObject.tag == "Player2")
		{
			Player2.player.health--;
			Player2.player.Hit();
			Destroy (gameObject);
		}
	}
	
	IEnumerator OnHit ()
	{
		yield return new WaitForSeconds (0.1f);
		Destroy(gameObject);
	}
}