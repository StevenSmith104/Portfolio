using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour {

	public float Motor, Steer, Brake, Idle;
	public WheelCollider F_R_Wheel, F_L_Wheel, R_R_Wheel, R_L_Wheel;
	public float v;
	public float h;

	void FixedUpdate () 
	{
		v = Input.GetAxis("Vertical") * Motor;
	 	h = Input.GetAxis("Horizontal") * Steer;

		R_R_Wheel.motorTorque = v;
		R_L_Wheel.motorTorque = v;

		F_R_Wheel.steerAngle = h;
		F_L_Wheel.steerAngle = h;

		if(Input.GetKey(KeyCode.Space))
		{
			R_R_Wheel.brakeTorque = Brake;
			R_L_Wheel.brakeTorque = Brake;
		}

		if(Input.GetKeyUp(KeyCode.Space))
		{
			R_R_Wheel.brakeTorque = 0;
			R_L_Wheel.brakeTorque = 0;
		}

		if(Input.GetAxis("Vertical") == 0)
		{
			R_R_Wheel.brakeTorque = Idle;
			R_L_Wheel.brakeTorque = Idle;
		}
		else
		{
			R_R_Wheel.brakeTorque = 0;
			R_L_Wheel.brakeTorque = 0;
		}
	}
}
