using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour {

	public GameObject pickUpPlacement;
	public GameObject pickUp;
	public Rigidbody rb;
	public bool holdingItem = false;

	// Use this for initialization
	void Start () 
	{
		
	}

	void FixedUpdate()
	{
		if (holdingItem == true) 
		{
			if(Input.GetKey ("q")) 
			{
				pickUp.transform.Rotate (Vector3.left * Time.deltaTime * 30.0f);
				pickUp.transform.Rotate (Vector3.down * Time.deltaTime * 30.0f);
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		Transform cam = Camera.main.transform;
		Vector3 fwd = transform.TransformDirection (Vector3.forward);

		if (Input.GetKeyDown ("e")) 
		{
			if (holdingItem == false) {
				Ray ray = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit, 2)) {
					if (hit.transform.tag == "PickUp") {
						pickUp = hit.transform.gameObject;
						pickUp.transform.position = pickUpPlacement.transform.position;
						pickUp.transform.parent = pickUpPlacement.transform;
						pickUp.transform.eulerAngles = new Vector3(0f, 0f, 0f);
						rb = pickUp.GetComponent<Rigidbody>();
						rb.isKinematic = true;
						//rb.detectCollisions = false;
						holdingItem = true;
					}
				}
			} 
			else if (holdingItem == true) 
			{
				if (Input.GetKeyDown ("e")) 
				{
					if(rb != null)
					{
						rb.isKinematic = false;
						//rb.detectCollisions = true;
						rb = null;
						pickUp.transform.parent = null;
						pickUp = null;
						holdingItem = false;
					}
					else
					{
						pickUp = null;
						holdingItem = false;
					}
				}
			}
		}
	}
}
