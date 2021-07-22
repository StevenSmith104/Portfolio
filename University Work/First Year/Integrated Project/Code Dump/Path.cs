using UnityEngine;
using System.Collections;
//A created class to hold information on the nodes agents travel between
public class Path : MonoBehaviour {
	public Transform[] nodes;
	public Vector3 GetNodePos(int id){
				return nodes [id].position;
		}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
