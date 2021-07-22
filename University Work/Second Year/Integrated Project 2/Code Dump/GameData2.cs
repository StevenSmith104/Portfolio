using UnityEngine;
using System.Collections;

public class GameData2 : MonoBehaviour {

	Score score;

	public int scorePlayer1 = 0;
	public int scorePlayer2 = 0;

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad(this);
	}

	public void BeforeLoad(int x, int y)
	{
		scorePlayer1 = x;
		scorePlayer2 = y;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
