using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	//The texture to be drawn for the splash screen
	public Texture2D backGroundTexture;
	//width and height of button 
	public int buttonWidth = 100; 
	public int buttonHeight = 30; 
	//the space between the buttons 
	public int buttonSpacing = 70; 
	//the start Y position of button
	public int buttonYStart = 400;


	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{

	}

	void OnGUI() 
	{ 
		//draw splash screen 
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),backGroundTexture);

		//store the start position 
		int buttonyPosition=buttonYStart; 
		//add button
		if (GUI.Button (new Rect (Screen.width / 2 - buttonWidth / 2,
			buttonyPosition, buttonWidth, buttonHeight),
			"Start"))

		{
			Application.LoadLevel("Test"); 
		}
		//change the position for the next button 
		buttonyPosition += buttonSpacing; 
		//add another button 
		if 
			(GUI.Button (new Rect (Screen.width / 2 - buttonWidth / 2,
				buttonyPosition, buttonWidth, buttonHeight), "Quit"))
		{ 
			Application.Quit(); 
		}
	}
}