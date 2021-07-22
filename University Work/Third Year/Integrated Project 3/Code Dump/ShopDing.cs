using UnityEngine;
using System.Collections;

public class ShopDing : MonoBehaviour {
	public AudioSource audio;
	public AudioClip ding;

	bool played = false;

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player" && played == false)
		{
			audio.PlayOneShot(ding, 1.0f);

			if(this.gameObject.name == "Sphere")
			{
				played = true;
			}
		}
	}

}
