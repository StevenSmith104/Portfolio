using UnityEngine;
using System.Collections;

public class SpawnTriggerScript : MonoBehaviour {
	public SpawnScript spawnScript;   // Selects the which spawn script

	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))    // Checks for the user clicking the left mouse button
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Creates a ray cast from the mouses position
			RaycastHit hit = new RaycastHit ();
			if (Physics.Raycast (ray , out hit))   // If the raycast hit 
			{
				if (hit.collider.gameObject.name == "Cube(Clone)") // Checks to see if the raycast has hit the cube
				{
					Debug.Log ("Spawning Turret Menu");   // Displays message
					spawnScript.Spawn();                 // Calls Spawn script for the turret
				}
			}
	}	
}
}