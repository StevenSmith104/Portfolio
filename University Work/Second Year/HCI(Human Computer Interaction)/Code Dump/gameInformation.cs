using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameInformation : MonoBehaviour {
		
	public playerController playerScript;
	public int scoreCounter = 0;

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad (this);
	}

	// Update is called once per frame
	void Update () 
	{
		if (playerScript != null) 
		{
			scoreCounter = playerScript.score;
		}
	}
}
