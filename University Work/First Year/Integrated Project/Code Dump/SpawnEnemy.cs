using UnityEngine;
using System.Collections;
//A test script to spawn prefab agents when GUI buttons were pressed
public class SpawnEnemy : MonoBehaviour {
	public GameObject enemyPrefab1;
	public GameObject enemyPrefab2;
	public GameObject enemyPrefab3;

	void SpawnSlow(){
		
		GameObject slow = (GameObject)Instantiate (enemyPrefab3, transform.position,
		                                           Quaternion.identity);
		slow.name = "slow";
	}



	void SpawnFast(){
		
		GameObject fast = (GameObject)Instantiate (enemyPrefab2, transform.position,
		                                             Quaternion.identity);
		fast.name = "fast";
	}



	void SpawnNormal(){

				GameObject normal = (GameObject)Instantiate (enemyPrefab1, transform.position,
	                                            Quaternion.identity);
				normal.name = "normal";
		}

	void OnGUI(){
		if (GUI.Button (new Rect (100, 150, 150, 25), "Spawn Normal Enemy")) {
						SpawnNormal();
				}
		if (GUI.Button (new Rect (100, 200, 150, 25), "Spawn Fast Enemy")) {
			SpawnFast();
		}
		if (GUI.Button (new Rect (100, 250, 150, 25), "Spawn Slow Enemy")) {
			SpawnSlow();
		}
	}

}
