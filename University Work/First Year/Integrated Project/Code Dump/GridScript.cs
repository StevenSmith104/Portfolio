using UnityEngine;
using System.Collections;
//Unsucessful attempt at getting a grid system for turret spawning
public class GridScript : MonoBehaviour {
	public Transform gridBlock; 
	public Vector3 size;
	// Use this for initialization
	void Start () {
		CreateGrid ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void CreateGrid(){
		for(int x = 0; x< size.x; x++){
			for(int z = 0; z< size.z; z++){
		Instantiate (gridBlock, new Vector3(x, 0, z), Quaternion.identity);
			}
		}
	}
}
