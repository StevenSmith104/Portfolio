using UnityEngine;
using System.Collections;

public class baseScript : MonoBehaviour {
	public int Health = 100;

	void OnTriggerEnter(Collider other){
				if (other.gameObject.tag == "enemy") {
			Destroy (other.gameObject);		
			Health --;
				}
		}
				

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
