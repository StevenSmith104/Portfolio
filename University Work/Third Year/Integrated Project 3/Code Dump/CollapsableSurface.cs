using UnityEngine;
using System.Collections;

public class CollapsableSurface : MonoBehaviour {
	public WaterRiseScript waterRiseScript;

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Player")
		{
			//Debug.Log("Hit");
			waterRiseScript.floorCollapseEvent();
			Destroy(gameObject);
		}
	}

}
