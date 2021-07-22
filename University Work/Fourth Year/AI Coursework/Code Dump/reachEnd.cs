using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reachEnd : MonoBehaviour {

	public int end = 0;

	void OnTriggerEnter(Collider col)
	{
		end = 1;
	}
}
