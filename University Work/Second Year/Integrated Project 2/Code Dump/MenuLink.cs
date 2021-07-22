using UnityEngine;
using System.Collections;

public class MenuLink : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void LoadMenuScene()
	{
		GameData.gameData.MenuMusic();
		Application.LoadLevel("MainMenu");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
