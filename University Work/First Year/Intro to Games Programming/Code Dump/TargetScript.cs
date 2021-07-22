using UnityEngine;
using System.Collections;

public class TargetScript : MonoBehaviour {
	public int score;
	public int health;
	public GameObject explosion;
//This is to play a sound and remove the hit target
IEnumerator PlaySoundAndRemove()
	{
				audio.Play ();
				yield return new WaitForSeconds (audio.clip.length);
			 	Instantiate (explosion, transform.position, Quaternion.identity);
				Destroy (gameObject);
				
	}

	// This is to apply a force on hit
	public void HitApplyForce(Vector3 direction, float force)
	{
				rigidbody.AddForce (direction * force);
				health = health - 50;
			if (health == 0) 
		{
						StartCoroutine (PlaySoundAndRemove ());
						score++;
		}
	}	
}