using UnityEngine;
using System;
using System.Collections;

public class itembobScript : MonoBehaviour {
	
	float originalY;

	public float floatStrength = 0.1f;

	// Use this for initialization
	void Start () 
	{
		this.originalY = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3 (transform.position.x,
		                                 originalY + ((float)Math.Sin (Time.time) * floatStrength),
		                                 transform.position.z);
	}
}
