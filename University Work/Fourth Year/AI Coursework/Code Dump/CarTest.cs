﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTest : MonoBehaviour {

	public List<AxleInfo> axleInfos;
	public float maxMotorTorque;
	public float maxSteeringAngle;
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float motor = maxMotorTorque * Input.GetAxis("Vertical");
		float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

		foreach(AxleInfo axleInfo in axleInfos)
		{
			if(axleInfo.steering)
			{
				axleInfo.leftWheel.steerAngle = steering;
				axleInfo.rightWheel.steerAngle = steering;
			}
			if(axleInfo.motor)
			{
				axleInfo.leftWheel.motorTorque = motor;
				axleInfo.rightWheel.motorTorque = motor;
			}
		}
	}
}

[System.Serializable]
public class AxleInfo
{
	public WheelCollider leftWheel;
	public WheelCollider rightWheel;
	public bool motor;
	public bool steering;
}
