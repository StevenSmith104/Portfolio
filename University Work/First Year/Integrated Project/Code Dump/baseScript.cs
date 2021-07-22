using UnityEngine;
using System.Collections;

public class baseScript : MonoBehaviour {
	public int Health = 100;
	//This handles the health of the base decreasing if an enemy makes it to the end of the course
	void OnTriggerEnter(Collider other){
				if (other.gameObject.tag == "enemy") {
			Destroy (other.gameObject);		
			Health --;
				}
		}
}
