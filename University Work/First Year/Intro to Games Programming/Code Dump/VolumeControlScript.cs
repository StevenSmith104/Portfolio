using UnityEngine;
using System.Collections;

public class VolumeControlScript : MonoBehaviour {

	// This is to set the listeners volume to the saved volume
	void Start () 
	{
		GameObject gameData = GameObject.Find ("GameData");
		if (gameData != null) 
				{
						GameDataScript gameDataScript = gameData.GetComponent<GameDataScript> ();
						AudioListener.volume = gameDataScript.volume;
				}
	}
}
