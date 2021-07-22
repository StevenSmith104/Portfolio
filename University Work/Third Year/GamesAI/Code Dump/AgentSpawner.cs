using UnityEngine;
using System.Collections;

public class AgentSpawner : MonoBehaviour {

	//Create the prefabs to spawn
	public GameObject alphaAgent;
	public GameObject betaAgent;
	public GameObject omegaAgent;

	// Use this for initialization
	void Start ()
	{
		//Enter a for loop 
		for(int i = 0; i <= 20; i++)
		{
			//Create a random spawn point for each type of agent
			Vector3 rndAlphaSpawn = new Vector3(Random.Range(-25.0f, 25.0f), 1, Random.Range(-25.0f, 25.0f)); 
			Vector3 rndBetaSpawn = new Vector3(Random.Range(-25.0f, 25.0f), 1, Random.Range(-25.0f, 25.0f));
			Vector3 rndOmegaSpawn = new Vector3(Random.Range(-25.0f, 25.0f), 1, Random.Range(-25.0f, 25.0f)); 

			//Spawn each agent at the randomized spawn points
			Instantiate(alphaAgent, rndAlphaSpawn, Quaternion.identity);
			Instantiate(betaAgent, rndBetaSpawn, Quaternion.identity);
			Instantiate(omegaAgent, rndOmegaSpawn, Quaternion.identity);
		}
	}
}
