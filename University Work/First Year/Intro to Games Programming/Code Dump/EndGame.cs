using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {
	// This is to load the end scene
	IEnumerator LoadEndScene()
	{
				yield return new WaitForSeconds (audio.clip.length);
				Application.LoadLevel ("EndScene");
	}

	// This is a check to see if the player has hit the end collider
	void OnTriggerEnter(Collider other)
	{
				if (other.gameObject.name == "Player") 
				{
						audio.Play ();
						StartCoroutine (LoadEndScene ());
				}
	}

}
