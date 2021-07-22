using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {
	public Texture2D backGroundTexture;
	public int buttonWidth = 100;
	public int buttonHeight = 30;
	public int buttonSpacing = 70;
	public int buttonYStart = 300;
	//This is to load main level
	IEnumerator LoadMainLevel()
	{
				yield return new WaitForSeconds (audio.clip.length);
				Application.LoadLevel ("MainLevel");
	}
	// This is to exit application
	IEnumerator ExitApplication()
	{
				yield return new WaitForSeconds (audio.clip.length);
				Application.Quit ();
	}
	// This is to load option menu
	IEnumerator LoadOptionMenu()
	{
				yield return new WaitForSeconds (audio.clip.length);
				Application.LoadLevel ("OptionMenu");
	}

	// Use this for initialization
	void Start () {
		Screen.showCursor = true;
	}
	
	//Various buttons to take you to each scene
	void OnGUI()
	{
				int buttonYPosition = buttonYStart;
				GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backGroundTexture);
				

		
		if (GUI.Button (new Rect (Screen.width / 2 - buttonWidth / 2, buttonYPosition, buttonWidth, buttonHeight), "Quit")) 
		{
			audio.Play ();
			StartCoroutine (ExitApplication ());
		}

		buttonYPosition -= buttonSpacing;

		if (GUI.Button (new Rect (Screen.width / 2 - buttonWidth / 2, buttonYPosition, buttonWidth, buttonHeight), "Options")) 
				{
						audio.Play ();
						StartCoroutine (LoadOptionMenu ());
				}

		buttonYPosition -= buttonSpacing;

		if (GUI.Button (new Rect (Screen.width / 2 - buttonWidth / 2, buttonYPosition, buttonWidth, buttonHeight), "Start")) 
		{
			audio.Play ();
			StartCoroutine (LoadMainLevel ());
		}

				

	}
	
	
}

