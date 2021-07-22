using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player1HP3 : MonoBehaviour 
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
		if (Player1.player.health >= 3)
		{
			heart.sprite = heartActive;
		}
		else 
		{
			heart.sprite = heartInactive;
		}
	}
}