using UnityEngine;
using System.Collections;

public class PowerUp1 : MonoBehaviour {

	public float enableTime = 0.0f;
	public float spawnTime = 0.0f;
	public GameObject fireBall;
	public AudioClip fireBallSound;

	// Use this for initialization
	void Start () {
	
	}

	void SpawnFireball()
	{
		Instantiate (fireBall, (transform.position + new Vector3(Random.Range (-9.0f, 9.5f), -2.0f, 0.0f)), Quaternion.identity);
		audio.PlayOneShot (fireBallSound);
	}

	void OnEnable()
	{
		enableTime = Time.time;
		spawnTime = Time.time;
	}


	// Update is called once per frame
	void Update () 
	{
		if (Time.time - enableTime >= 15.0f) 
		{
			this.enabled = false;
		}
		if (Time.time - spawnTime >= 1.0f) 
		{
			SpawnFireball();
			spawnTime = Time.time;
		}
	}
}
