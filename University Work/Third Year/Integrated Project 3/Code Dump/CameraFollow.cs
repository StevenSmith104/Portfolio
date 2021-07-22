using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject target;

	void Update()
	{
		Vector3 yOffset = new Vector3(0.0f, 10.0f, 0.0f);
		gameObject.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z) + yOffset;
	}
}﻿
