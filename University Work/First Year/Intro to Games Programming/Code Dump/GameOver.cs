using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	public Texture2D backGroundTexture;
	//This is to load mainmenu
	IEnumerator LoadMain()
	{
		yield return new WaitForSeconds (audio.clip.length);		
		Application.LoadLevel ("MainMenu");
	}
	// Use this for initialization
	void Start () {
		Screen.showCursor = true;
	}
	
	//This is to show background texture and a try again button
	void OnGUI()
	{
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backGroundTexture);
		if(GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2,200,50),"Try Again?"))
		{
			audio.Play ();
			StartCoroutine(LoadMain());
		}
	}
}
