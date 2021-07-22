using UnityEngine;
using System.Collections;

public class AgentSpawner2 : MonoBehaviour {

	//Create the prefabs to spawn
	public GameObject alphaAgent;
	public GameObject betaAgent;
	public GameObject omegaAgent;

	// Use this for initialization
	void Start ()
	{
		//Enter a for loop
		for(int i = 0; i <= 25; i++)
		{
			//Create a random spawn point for the Alpha and Beta agents
			Vector3 rndAlphaSpawn = new Vector3(Random.Range(-25.0f, 25.0f), 1, Random.Range(-25.0f, 25.0f)); 
			Vector3 rndBetaSpawn = new Vector3(Random.Range(-25.0f, 25.0f), 1, Random.Range(-25.0f, 25.0f));

			//Spawn the Alpha and Beta agents at the randomized spawn points
			Instantiate(alphaAgent, rndAlphaSpawn, Quaternion.identity);
			Instantiate(betaAgent, rndBetaSpawn, Quaternion.identity);
		}

		//Create a randomized spawn and spawn the Omega agent at the randomized spawn
		Vector3 rndOmegaSpawn = new Vector3(Random.Range(-25.0f, 25.0f), 1, Random.Range(-25.0f, 25.0f)); 
		Instantiate(omegaAgent, rndOmegaSpawn, Quaternion.identity);
	}
}
