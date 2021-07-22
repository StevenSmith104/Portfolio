using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	public GameObject spawnPrefab;
	public int i;
	public int n;
	//This is to spawn in a target
	public void Spawn()
	{
		for(n=0; n<i; n++)
		{		
			GameObject Target = (GameObject)Instantiate (spawnPrefab,
			                                             transform.position, Quaternion.identity);
			Target.name = "Target";
		}
	}
}
