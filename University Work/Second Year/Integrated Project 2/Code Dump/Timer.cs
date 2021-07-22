using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour 
{
	public float timeLimit;

	float seconds;
	float minutes;
	/*
	public Texture2D player1;
	public Texture2D player2;
	public Texture2D heart;

	public GUIStyle style;
*/
	Text time;

	void Awake ()
	{
		time = GetComponent <Text> ();

		timeLimit = 300;
	}

	void Start ()
	{
		InvokeRepeating ("Countdown", 1, 1);
	}

	void Update ()
	{
		minutes = Mathf.Floor(timeLimit / 60);
		seconds = Mathf.Floor(timeLimit - minutes * 60);

		if (minutes < 0)
		{
			minutes = 0;
			seconds = 0;
		}

		time.text = string.Format ("{0:0}:{1:00}", minutes, seconds);
	}
	/*
	void OnGUI()
	{
		minutes = Mathf.Floor(timeLimit / 60);
		seconds = Mathf.Floor(timeLimit - minutes * 60);

		if(minutes < 0) 
		{
			minutes = 0;
			seconds = 0;
		}

		GUI.Label (new Rect (Screen.width / 2 - 480, Screen.height / 2 - 320, 100, 30), string.Format ("{0:0}:{1:00}", minutes, seconds), style);

		GUI.DrawTexture (new Rect (Screen.width / 2 - 590, Screen.height / 2 + 180, 320, 50), player1, ScaleMode.StretchToFill, true, 0);
		GUI.DrawTexture (new Rect (Screen.width / 2 + 260, Screen.height / 2 + 180, 320, 50), player2, ScaleMode.StretchToFill, true, 0);

		if (Player1.player.health >= 1)
		{
			GUI.DrawTexture (new Rect (Screen.width / 2 - 500, Screen.height / 2 + 240, 40, 40), heart, ScaleMode.StretchToFill, true, 0);

			if (Player1.player.health >= 2)
			{
				GUI.DrawTexture (new Rect (Screen.width / 2 - 450, Screen.height / 2 + 240, 40, 40), heart, ScaleMode.StretchToFill, true, 0);

				if (Player1.player.health >= 3)
				{
					GUI.DrawTexture (new Rect (Screen.width / 2 - 400, Screen.height / 2 + 240, 40, 40), heart, ScaleMode.StretchToFill, true, 0);
				}
			}
		}

		if (Player2.player.health >= 1)
		{
			GUI.DrawTexture (new Rect (Screen.width / 2 + 350, Screen.height / 2 + 240, 40, 40), heart, ScaleMode.StretchToFill, true, 0);
			
			if (Player2.player.health >= 2)
			{
				GUI.DrawTexture (new Rect (Screen.width / 2 + 400, Screen.height / 2 + 240, 40, 40), heart, ScaleMode.StretchToFill, true, 0);
				
				if (Player2.player.health >= 3)
				{
					GUI.DrawTexture (new Rect (Screen.width / 2 + 450, Screen.height / 2 + 240, 40, 40), heart, ScaleMode.StretchToFill, true, 0);
				}
			}
		}
	}
	*/
	void Countdown ()
	{
		timeLimit--;
	}
}