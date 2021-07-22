using UnityEngine;
using System.Collections;

public class GameDataScript : MonoBehaviour {
	public string playerName;
	public float volume = 1.0f;
	public int score;
	// This is to ensure the game data is not deleted upon load
	void Start () 
	{
		DontDestroyOnLoad (this);
	}
}
