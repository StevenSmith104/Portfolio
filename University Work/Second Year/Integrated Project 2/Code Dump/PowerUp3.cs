using UnityEngine;
using System.Collections;

public class PowerUp3 : MonoBehaviour {

	public float enableTime = 0.0f;
	public float strikeTime = 0.0f;
	public int strikeCount = 0;
	public GameObject lightningStrike;
	public AudioClip thunderStart;
	public AudioClip lightning;

	// Use this for initialization
	void Start () {
	
	}

	void OnEnable()
	{
		enableTime = Time.time;
		strikeTime = Random.Range (1.0f, 14.0f) + Time.time;
		strikeCount = 0;
		audio.PlayOneShot (thunderStart);
	}

	void Strike ()
	{
		Instantiate (lightningStrike, (transform.position + new Vector3(Random.Range (-9.0f, 10.0f), 0.0f, 0.0f)), Quaternion.identity);
		audio.PlayOneShot (lightning);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Time.time - enableTime >= 15.0f) 
		{
			this.enabled = false;
		}
		if (Time.time >= strikeTime && strikeCount < 1) 
		{
			Strike();
			strikeCount++;

		}
	}
}
