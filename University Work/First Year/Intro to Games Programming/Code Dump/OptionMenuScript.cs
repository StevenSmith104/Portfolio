using UnityEngine;
using System.Collections;

public class OptionMenuScript : MonoBehaviour {
	public Texture2D backGroundTexture;
	string nameText = "";
	float volume = 1.0f;
	//This is to load the main menu
	IEnumerator LoadMain()
	{
		yield return new WaitForSeconds (audio.clip.length);		
		Application.LoadLevel ("MainMenu");
	}
	
	// This is to set the volume and save it
	void Update () 
	{
		GameObject gameData = GameObject.Find ("GameData");

						GameDataScript gameDataScript = gameData.GetComponent<GameDataScript> ();
						gameDataScript.playerName = nameText;
						gameDataScript.volume = volume;
						AudioListener.volume = volume;
	}

	// these are the buttons to navigate the options menu
	void OnGUI()
	{
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backGroundTexture);
		GUI.Label (new Rect (Screen.width / 2 - 50.0f, 30.0f, 100.0f, 20.0f), "Enter Name Here"); 
		GUI.Label (new Rect (Screen.width / 2 - 50 , Screen.height - 180, 200, 30), "Master Volume");
		volume = GUI.HorizontalSlider (new Rect (Screen.width - 510, Screen.height - 100, 200, 50), volume, 0, 1.0f);
		nameText = GUI.TextField (new Rect (Screen.width / 2 - 50.0f, 50.0f, 100.0f, 20.0f), nameText);
		if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 100, 100, 50), "Main Menu")) 
		{
			audio.Play ();
			StartCoroutine (LoadMain ());
		}
	
	}
}