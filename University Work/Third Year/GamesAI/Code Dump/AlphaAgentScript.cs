using UnityEngine;
using System.Collections;

public class AlphaAgentScript : MonoBehaviour {

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
				if(agent!= null)
				{
					//Checks the distance between the agents and the current agent
					float dist = Vector3.Distance(thisAgent.transform.position, agent.transform.position);

					if(dist < 10 && agent.name != "AlphaAgent(Clone)")
					{
						//If the agent is close enough its position is added to the velocity vector
						positionVec.x += agent.transform.position.x;
						positionVec.z += agent.transform.position.z;
						surroundingAgents++;
					}
				}
			}
		}

		speedDecision();

		thisRB = thisAgent.GetComponent<Rigidbody>();

		//The position vector is then divided by the number of surrounding agents and normalized
		positionVec.x /= surroundingAgents;
		positionVec.z /= surroundingAgents;
		positionVec = new Vector3(positionVec.x - thisAgent.transform.position.x, 0 , positionVec.z - thisAgent.transform.position.z);
		positionVec.Normalize();

		if(!float.IsNaN(positionVec.x) && !float.IsNaN(positionVec.z))
		{
			//The normalized position vector is set equal to the velocity of the current agent
			thisRB.velocity = positionVec;
		}

		UpdateArray();
	}

	void speedDecision()
	{
		//This is a balanced decision tree to decide the speed the agent moves
		if(surroundingAgents >= 5)
		{
			if(surroundingAgents > 2)
			{
				if(surroundingAgents >= 4)
				{
					if(surroundingAgents >= 5)
					{
						speedFloat = 0.0f;
					}
					else if(surroundingAgents == 4)
					{
						speedFloat = 0.2f;
					}
				}
				else if (surroundingAgents == 3)
				{
					speedFloat = 0.4f;
				}
			}
			else if (surroundingAgents <= 2)
			{
				if(surroundingAgents < 2)
				{
					if(surroundingAgents == 1)
					{
						speedFloat = 0.8f;
					}
					else if(surroundingAgents == 0)
					{
						speedFloat = 1.0f;
					}
				}
				else if(surroundingAgents == 2)
				{
					speedFloat = 0.6f;
				}
			}
		}
	}

	void UpdateArray()
	{
		//Clears all data for the next frame
		agents = null;
		agents = GameObject.FindGameObjectsWithTag ("Agent");
		surroundingAgents = 0;
	}

	void FixedUpdate()
	{
		ComputeVelocityVec();
	}
}
