using UnityEngine;
using System.Collections;

public class EndSceneScript : MonoBehaviour {
	public Texture2D backGroundTexture;
	public string playerName = "";
	public int score =0;
	//This is to load up the mainmenu
	IEnumerator LoadMain()
	{
		GameObject gameData = GameObject.Find ("GameData");	
		if (gameData != null) 
		{
			Destroy(gameData);
		}
			yield return new WaitForSeconds (audio.clip.length);		
			Application.LoadLevel ("MainMenu");

	}
	// Use this for initialization
	void Start () {
		Screen.showCursor = true;
	}
	
	//This displays the users name, score and a well done message and also a button to return to the main menu and clear game data
	void OnGUI()
	{
				GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backGroundTexture);
				GameObject gameData = GameObject.Find ("GameData");		
		if (gameData != null) 
		{
					GameDataScript gameDataScript = gameData.GetComponent<GameDataScript> ();
					GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 120, 300, 100), "Well done " + gameDataScript.playerName + " your score is " + gameDataScript.score.ToString ());
		}
						if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 100, 100, 50), "Main Menu")) 
				{
								audio.Play ();
								StartCoroutine (LoadMain ());
				}
	}
}
