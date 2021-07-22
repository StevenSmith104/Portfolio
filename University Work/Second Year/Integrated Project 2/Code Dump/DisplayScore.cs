using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {

	GameData2 gameData2;

	public int score1;
	public int score2;

	public Text scoreText1;
	public Text scoreText2;

	// Use this for initialization
	void Start () 
	{
		GameObject gameData = GameObject.Find ("GameData2");
		if (gameData != null) 
		{
			GameData2 gameData2 = gameData.GetComponent<GameData2> ();
			score1 = gameData2.scorePlayer1;
			score2 = gameData2.scorePlayer2;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		scoreText1.text = score1.ToString();
		scoreText2.text = score2.ToString();
	}
}
