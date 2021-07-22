using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
	public GameObject Enemy;
	public Transform Target;
	public float RotationSpeed;
//Unsuccessful attempt at getting the towers to rotate towards the agents before static turrets were used
	void OnTriggerStay(Collider other){
				if (other.gameObject.tag == "enemy") {
			Enemy = other.gameObject;
						var direction = Enemy.transform.position - transform.position;
			
			
						direction.y = transform.position.y; 
			
						var rot = Quaternion.LookRotation (direction, Vector3.up);      
						transform.rotation = Quaternion.RotateTowards (
				transform.rotation, 
				rot, 
				RotationSpeed * Time.deltaTime);
				}
		}
}