using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public delegate void EventSetBlock(Vector3 v, int x);
	
	public static event EventSetBlock OnEventSetBlock;

	//public VoxelChunk voxelChunk;
	public bool rClick;

	bool PickThisBlock(out Vector3 v, float dist)
	{
		v = new Vector3 ();
		Ray ray = Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0));
		
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, dist)) 
		{
			if(rClick != true)
			{
			v = hit.point - hit.normal/2;
			}
			else
			{
			v = hit.point+hit.normal/2;
			}
			v.x = Mathf.Floor(v.x);
			v.y = Mathf.Floor(v.y);
			v.z = Mathf.Floor(v.z);
			rClick = false;
			return true;
		}
		return false;
	}



	// Use this for initialization
	void Start () {
	
	}


	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) 
		{

			Vector3 v;
			if(PickThisBlock(out v, 4))
			{
				//voxelChunk.SetBlock(v, 0);
				OnEventSetBlock(v, 0);
			}
		}

		if (Input.GetButtonDown ("Fire2")) 
		{
			rClick = true;
			Vector3 v;
			if(PickThisBlock(out v, 4))
			{
				//Debug.Log (v);
				//voxelChunk.SetBlock(v, 1);
				OnEventSetBlock(v, 1);
			}
		}
	
	}
}
