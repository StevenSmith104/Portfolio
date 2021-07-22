using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioClip destroyBlockSound;
	public AudioClip placeBlockSound;

	// Use this for initialization
	void Start () {
	
	}

	void PlayDestroyBlockSound(int x)
	{
		if (x == 0) 
		{
			audio.PlayOneShot (destroyBlockSound);
		}

	}

	void PlayPlaceBlockSound(int x)
	{
		if (x == 1) 
		{
			audio.PlayOneShot (placeBlockSound);
		}
	}

	void OnEnable()
	{

		//VoxelChunk.OnEventBlockChanged (x);

		//if (x == 0) 
		//{
			VoxelChunk.OnEventBlockChanged += PlayDestroyBlockSound;
		//} 
		//else 
		//{
			VoxelChunk.OnEventBlockChanged += PlayPlaceBlockSound;
		//}


	}

	void OnDisable()
	{
		VoxelChunk.OnEventBlockChanged -= PlayDestroyBlockSound;
		
		VoxelChunk.OnEventBlockChanged -= PlayPlaceBlockSound;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
