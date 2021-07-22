using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinder : MonoBehaviour {

	public VoxelChunk voxelChunk;
	GameObject cube;
	bool traversing = false;

	Vector3 startPosition = new Vector3(0, 4, 1);
	Vector3 endPosition = new Vector3(15, 4, 3);
	Vector3 offset = new Vector3(0.5f, 0.5f, 0.5f);

	// Use this for initialization
	void Start () 
	{
	
	}

	/*Stack<Vector3> BreadthFirstSearch
		(Vector3 start, Vector3 end, VoxelChunk vc)
	{
		Stack<Vector3> waypoints = new Stack<Vector3> ();
		Dictionary<Vector3, Vector3> visitedParent = new Dictionary<Vector3, Vector3> ();
		Queue<Vector3> q = new Queue<Vector3> ();
		bool found = false;
		Vector3 current = start;

		q.Enqueue (start);

		while (q.Count > 0 && !found) 
		{
			if(current != end)
			{
				List<Vector3> neighbourList = new List<Vector3>();
				neighbourList.Add (current + new Vector3(1,0,0));
				neighbourList.Add (current + new Vector3(-1,0,0));
				neighbourList.Add (current + new Vector3(0,0,1));
				neighbourList.Add (current + new Vector3(0,0,-1));

				foreach(Vector3 n in neighbourList)
				{
					if ((n.x >= 0 && n.x < vc.GetChunkSize()) && n.z >= 0 && n.z < vc.GetChunkSize())
					{
						if(vc.IsTraversable(n))
						{
							if(!visitedParent.ContainsKey(n))
							{
								visitedParent[n] = current;
								q.Enqueue(n);
							}
						}
					}
				}

			}
			else
			{
				found = true;
			}
		}
	}
	*/
	// Update is called once per frame
	void Update () 
	{
	
	}
}
