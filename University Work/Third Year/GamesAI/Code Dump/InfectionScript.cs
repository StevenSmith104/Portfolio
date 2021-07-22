using UnityEngine;
using System.Collections;

public class InfectionScript : MonoBehaviour {

	public GameObject omegaAgent;

	void OnCollisionEnter(Collision col)
	{
		//If this agent hits an Alpha or Beta agent
		if(col.gameObject.name == "AlphaAgent(Clone)" || col.gameObject.name == "BetaAgent(Clone)")
		{
			//Delete the hit agent and spawn an Omega agent in its place
			Vector3 spawn = col.gameObject.transform.position;
			Destroy(col.gameObject);
			Instantiate(omegaAgent, spawn, Quaternion.identity);
		}
	}
}