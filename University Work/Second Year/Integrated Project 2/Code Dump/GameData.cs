using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour 
{
	public static GameData gameData;

	public AudioClip Menu;
	public AudioClip Game;
	public AudioClip End;

	public float volume = 0.5f;

	void Awake ()
	{
		audio.PlayOneShot (Menu);

		if (gameData == null)
		{
			DontDestroyOnLoad (gameObject);
			gameData = this;
		}
		else if (gameData != this)
		{
			Destroy (gameObject);
		}
	}

	public void GameMusic()
	{
		audio.Stop();
		audio.PlayOneShot(Game);
	}

	public void MenuMusic()
	{
		audio.Stop();
		audio.PlayOneShot (Menu);
	}

	public void EndMusic()
	{
		audio.Stop ();
		audio.PlayOneShot(End);
	}

	void Start () 
	{
		DontDestroyOnLoad (this);
	}

	void Update ()
	{
		GameObject player1 = GameObject.FindGameObjectWithTag ("Player");
		if (player1 != null)
		{
			AudioSource playerVolume = player1.GetComponent<AudioSource> ();
			playerVolume.audio.volume = volume;
		}

		GameObject player2 = GameObject.FindGameObjectWithTag ("Player2");
		if (player2 != null)
		{
			AudioSource playerVolume = player2.GetComponent<AudioSource> ();
			playerVolume.audio.volume = volume;
		}

		AudioSource gameVolume = gameObject.GetComponent <AudioSource> ();
		gameVolume.audio.volume = volume;
		/*
		GameObject mainCamera = GameObject.Find ("Main Camera");
		if (mainCamera != null)
		{
			AudioSource volume = mainCamera.GetComponent<AudioSource> ();
			volume.audio.volume = sfxVol;
		}
		*/
	}
}