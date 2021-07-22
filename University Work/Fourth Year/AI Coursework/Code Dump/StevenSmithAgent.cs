using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StevenSmithAgent : Agent {

	public GameObject carPrefab;
	public GameObject end;
	public float motorMax, steerMax;
	public float speedTest;
	public float rewardTest;
	private GameObject car;
	private Vector3 forward;
	private WheelCollider frontL, frontR, rearL, rearR;

	public float leftColDist;
	public float rightColDist;
	public float forwardDist;

	public override void InitializeAgent()
	{
		AgentReset();
	}

	public override List<float> CollectState()
	{
		List<float> state = new List<float>();
		//state.Add(Vector3.Dot(forward, car.GetComponent<Rigidbody>().velocity));
		state.Add(leftColDist);
		state.Add(rightColDist);
		state.Add(forwardDist);
		state.Add(car.transform.position.x);
		state.Add(car.transform.position.y);
		state.Add(car.transform.position.z);
		state.Add(car.transform.rotation.x);
		state.Add(car.transform.rotation.y);
		state.Add(car.transform.rotation.z);
		return state;
	}

	public override void AgentStep(float[] action)
	{
		float angle_z = car.transform.rotation.eulerAngles.z > 180 ? 360 - car.transform.rotation.eulerAngles.z : car.transform.rotation.eulerAngles.z;
		if(Mathf.Abs(angle_z) > 20)
		{
			reward = 0;
			done = true;
			return;
		}
		if(end.GetComponent<reachEnd>().end == 1)
		{
			end.GetComponent<reachEnd>().end = 0;
			reward = 1000;
			done = true;
			return;
		}

		Vector3 forward = car.transform.TransformDirection(Vector3.forward);

		float motor;
	
		if(Vector3.Dot(forward, car.GetComponent<Rigidbody>().velocity) < 20f)
		{
			motor = 1.0f;
		}
		else
		{
			motor = 0.0f;
		}
		float steer = action[0] * steerMax;
		rearL.motorTorque = motor * motorMax;
		rearR.motorTorque = motor * motorMax;
		Vector3 position;
		Quaternion rotation;

		Vector3 left = car.transform.TransformDirection(Vector3.left + Vector3.forward);
		Vector3 right = car.transform.TransformDirection(Vector3.right + Vector3.forward);
		//Vector3 forward = car.transform.TransformDirection(Vector3.forward);

		Ray leftRay = new Ray(car.transform.position, left);
		Ray rightRay = new Ray(car.transform.position, right);
		Ray forwardRay = new Ray(car.transform.position, forward);

		Debug.DrawRay(car.transform.position, left * 10f, Color.green);
		Debug.DrawRay(car.transform.position, right * 10f, Color.red);

		RaycastHit leftCol;
		RaycastHit rightCol;
		RaycastHit forwardCol;

		Physics.Raycast(leftRay, out leftCol);
		Physics.Raycast(rightRay, out rightCol);
		Physics.Raycast(forwardRay, out forwardCol);

		leftColDist = leftCol.distance;
		rightColDist = rightCol.distance;
		forwardDist = forwardCol.distance;

		forward = Vector3.Normalize(frontL.transform.position - rearL.transform.position);
		reward += Vector3.Dot(forward, car.GetComponent<Rigidbody>().velocity)/2;
		reward += (forwardDist/100);

		if(leftColDist < 30.0f || rightColDist < 30.0f)
		{
			reward = 0;
			//Debug.Log("Too close");
			if(leftColDist < 10.0f || rightColDist < 10.0f)
			{
				reward -= 500;
				done = true;
				return;
			}
		}

		if(forwardDist < 10.0f)
		{
			reward = -500;
			done = true;
			return;
		}

		frontL.steerAngle = steer;
		frontR.steerAngle = steer;

		speedTest = Vector3.Dot(forward, car.GetComponent<Rigidbody>().velocity);
		rewardTest = reward;
	}

	public override void AgentReset()
	{
		DestroyImmediate(car);
		car = Instantiate(carPrefab, new Vector3(485f, 1f, 945f), Quaternion.Euler(0f, 90f, 0f));
		car.GetComponent<Rigidbody>().velocity = Vector3.zero;
		frontR = car.transform.Find("Front_R_Wheel").GetComponent<WheelCollider>();
		frontL = car.transform.Find("Front_L_Wheel").GetComponent<WheelCollider>();
		rearR = car.transform.Find("Rear_R_Wheel").GetComponent<WheelCollider>();
		rearL = car.transform.Find("Rear_L_Wheel").GetComponent<WheelCollider>();
		forward = Vector3.Normalize(frontL.transform.position - rearL.transform.position);
		frontR.ConfigureVehicleSubsteps(5, 500, 15);
	}

	public override void AgentOnDone()
	{
		AgentReset();
	}
}
