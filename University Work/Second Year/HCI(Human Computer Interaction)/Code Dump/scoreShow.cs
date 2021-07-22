using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreShow : MonoBehaviour {

	public Text scoreText;
	public int scoreCount;

	public gameInformation gameInfo;
	public GameObject gameData;

	// Use this for initialization
	void Start () 
	{
		GameObject gameData = GameObject.Find ("gameInfo");
		if (gameData != null) 
		{
			gameInformation gameInfo = gameData.GetComponent<gameInformation> ();
			scoreCount = gameInfo.scoreCounter;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		scoreText.text = "Score: " + scoreCount.ToString ();
	}
}
