using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {
	public AudioSource audio1;
	public AudioSource audio2;
	public AudioSource audio3;

	//This is to play the selected track
	void OnControllerColliderHit (ControllerColliderHit hit)
	{
				if (hit.gameObject.name == "Music1") 
				{
						audio1.Play ();
						audio2.Stop ();
						audio3.Stop ();
				} else if (hit.gameObject.name == "Music2") 
				{
						audio2.Play ();
						audio1.Stop ();
						audio3.Stop ();
				} else if (hit.gameObject.name == "Music3") 
				{
						audio3.Play ();
						audio1.Stop ();
						audio2.Stop ();
				}
	} 
}
