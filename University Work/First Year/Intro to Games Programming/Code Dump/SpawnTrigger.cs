using UnityEngine;
using System.Collections;

public class SpawnTrigger : MonoBehaviour {
	public SpawnScript spawnScript1;
	public SpawnScript spawnScript2;
	public SpawnScript spawnScript3;

//This is the trigger to spawn objects
void OnTriggerEnter(Collider other)
		{
				if (other.gameObject.name == "Player") 
				{
						spawnScript1.Spawn ();
						spawnScript2.Spawn ();
						spawnScript3.Spawn ();
						audio.Play ();
				}
		}

}
