using UnityEngine;
using System.Collections;

public class WaterRiseScript : MonoBehaviour 
{
	public GameObject ocean;
	bool floorCollapsed = false;

	void Start()
	{
		ocean = this.gameObject;
	}

	public void floorCollapseEvent()
	{
		floorCollapsed = true;
	}

	void FixedUpdate()
	{
		if(floorCollapsed == true)
		{
			//ocean.transform.position += new Vector3(0.0f, 0.0003f, 0.0f );
		}
	}

}
