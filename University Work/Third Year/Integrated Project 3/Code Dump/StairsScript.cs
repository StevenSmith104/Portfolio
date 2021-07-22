using UnityEngine;
using System.Collections;

public class StairsScript : MonoBehaviour {

	public GameObject plankObject;
	public GameObject inactivePlankObject;

	public GameObject boxObject;
	public GameObject inactiveBoxObject;

	bool boxPlaced = false;

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject == plankObject && boxPlaced == true)
		{
			Destroy(col.gameObject);
			inactivePlankObject.SetActive(true);
		}
		else if(col.gameObject == boxObject)
		{
			Destroy(col.gameObject);
			inactiveBoxObject.SetActive(true);
			boxPlaced = true;
		}
	}
	

}
