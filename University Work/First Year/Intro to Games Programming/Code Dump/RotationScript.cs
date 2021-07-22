using UnityEngine;
using System.Collections;

public class RotationScript : MonoBehaviour {
	public float rotationSpeed = 10.0f;
	// This is to spin a game object
	void Update () 
	{
		transform.Rotate (Vector3.up * Time.deltaTime * rotationSpeed);
	}
}
