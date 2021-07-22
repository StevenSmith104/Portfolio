using UnityEngine;
using System.Collections;

public class BetaAgentScript : MonoBehaviour {

	public int surroundingAgents = 0;
	public GameObject[] agents;

	public Rigidbody rb;
	public Rigidbody thisRB;

	GameObject thisAgent;
	float speedFloat = 0.0f;

	public Vector3 positionVec = new Vector3();

	void Start()
	{
		//Constructs the array of agents and sets thisAgent to the current agent the script is attached to
		agents = GameObject.FindGameObjectsWithTag ("Agent");
		thisAgent = this.gameObject;

		ComputeVelocityVec();
	}
	//Calculate the velocity vector
	void ComputeVelocityVec()
	{
		//Loops through each agent in the agent array
		foreach (GameObject agent in agents) 
		{
			if (agent != thisAgent) 
			{
				if(agent != null)
				{
					//Checks the distance between the agents and the current agent
					float dist = Vector3.Distance(thisAgent.transform.position, agent.transform.position);

					if(dist < 10)
					{
						//If the agent is close enough its position is added to the velocity vector
						positionVec.x += agent.transform.position.x;
						positionVec.z += agent.transform.position.z;
						surroundingAgents++;
					}
				}
			}
		}

		SpeedDecision();
	
		thisRB = thisAgent.GetComponent<Rigidbody>();

		//The position vector is then divided by the number of surrounding agents and normalized
		positionVec.x /= surroundingAgents;
		positionVec.z /= surroundingAgents;
		positionVec = new Vector3((positionVec.x - thisAgent.transform.position.x) * -1, 0 , (positionVec.z - thisAgent.transform.position.z)*-1);
		positionVec.Normalize();
		positionVec *= speedFloat;

		if(!float.IsNaN(positionVec.x) && !float.IsNaN(positionVec.z))
		{
			thisRB.velocity = positionVec;
		}

		UpdateArray();
	}

	void SpeedDecision()
	{
		//This is an example of an unbalanced decision tree to decide the speed of the agent
		if(surroundingAgents == 0)
		{
			speedFloat = 0.0f;
		}
		if(surroundingAgents == 1)
		{
			speedFloat = 0.2f;
		}
		if(surroundingAgents == 2)
		{
			speedFloat = 0.4f;
		}
		if(surroundingAgents == 3)
		{
			speedFloat = 0.6f;
		}
		if(surroundingAgents == 4)
		{
			speedFloat = 0.8f;
		}
		if(surroundingAgents >= 5)
		{
			speedFloat = 1.0f;
		}
	}

	void UpdateArray()
	{
		//Clears the data for the next frame
		agents = null;
		agents = GameObject.FindGameObjectsWithTag ("Agent");
		surroundingAgents = 0;
	}

	void FixedUpdate()
	{
		ComputeVelocityVec();
	}
}
