using UnityEngine;
using System.Collections;

public class DoorOpenScript : MonoBehaviour {

	public bool doorOpen = false;
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("e"))
		{
			Transform cam = Camera.main.transform;
			Vector3 fwd = transform.TransformDirection(Vector3.forward);

			Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit, 2))
			{
				if(hit.transform.tag == "Door" && doorOpen == false)
				{
					hit.transform.parent.transform.Rotate(Vector3.up, 90, Space.World);
					doorOpen = true;
				}
				else if (hit.transform.tag == "Door" && doorOpen == true)
				{
					hit.transform.parent.transform.Rotate(Vector3.up, -90, Space.World);
					doorOpen = false;
				}
			}
		}
	}
}
