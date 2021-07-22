using UnityEngine;
using System.Collections;

public class DoorUnlock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.name == "Key(Clone)")
		{
			Debug.Log ("Key hit");
			Destroy(this.gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
