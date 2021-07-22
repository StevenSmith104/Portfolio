using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public GameData2 gameData2;

	public int player1Score;
	public int player2Score;

	public Text player1Text;
	public Text player2Text;

	float timer = 0;
	float timeStart = 0;

	// Use this for initialization
	void Start () 
	{
		timer = Time.time;
		timeStart = Time.time + 300;
	}
	
	// Update is called once per frame
	void Update () 
	{
		player1Text.text = player1Score.ToString();
		player2Text.text = player2Score.ToString();

		timer = Time.time;
		if(timer >= timeStart)
		{
			if(player1Score > player2Score)
			{
				gameData2.BeforeLoad(player1Score, player2Score);
				GameData.gameData.EndMusic();
				Application.LoadLevel ("Player1Win");
			}
			else if (player2Score > player1Score)
			{
				gameData2.BeforeLoad(player1Score, player2Score);
				GameData.gameData.EndMusic();
				Application.LoadLevel ("Player2Win");
			}

		}
	}
}
