using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	public GameObject spawnPrefab;

	public void Spawn()
	{
		GameObject turret = (GameObject)Instantiate (spawnPrefab,transform.position, Quaternion.identity);
			turret.name = "Turret";    // This will spawn the turret at the spawn point
		}
}

