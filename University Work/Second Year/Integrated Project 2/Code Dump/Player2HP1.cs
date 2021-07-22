using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player2HP1 : MonoBehaviour 
{
	public Sprite heartActive;
	public Sprite heartInactive;
	
	Image heart;
	
	void Start ()
	{
		heart = GetComponent <Image> ();
	}
	
	void Update () 
	{
		if (Player2.player.health >= 1)
		{
			heart.sprite = heartActive;
		}
		else 
		{
			heart.sprite = heartInactive;
		}
	}
}