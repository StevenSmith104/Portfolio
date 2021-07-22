using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]

public class MeshGenerator : MonoBehaviour 
{
	MeshCollider meshCollider;
	Mesh mesh;
	List<Vector3> vertexList;
	List<int> triIndexList;
	List<Vector2> UVList;
	int numQuads = 0;

	// Use this for initialization
	void Start () 
	{
		mesh = GetComponent<MeshFilter> ().mesh;
		meshCollider = GetComponent<MeshCollider> ();
		vertexList = new List<Vector3>();
		triIndexList = new List<int> ();
		UVList = new List<Vector2>();


		CreateQuadWall (1, 1, 0, new Vector2(0.5f,0));
		CreateQuadWall (2, 1, 0, new Vector2(0.5f,0));
		CreateQuadWall (3, 1, 0, new Vector2(0.5f,0));
		CreateQuadWall (4, 1, 0, new Vector2(0.5f,0));
		CreateQuadWall (5, 1, 0, new Vector2(0.5f,0));
		CreateQuadWall (6, 1, 0, new Vector2(0.5f,0));
		CreateQuadWall (1, 2, 0, new Vector2(0.5f,0));
		CreateQuadWall (2, 2, 0, new Vector2(0.5f,0));
		CreateQuadWall (3, 2, 0, new Vector2(0.5f,0));
		CreateQuadWall (4, 2, 0, new Vector2(0.5f,0));
		CreateQuadWall (5, 2, 0, new Vector2(0.5f,0));
		CreateQuadWall (6, 2, 0, new Vector2(0.5f,0));
		CreateQuadWall (1, 3, 0, new Vector2(0.5f,0));
		CreateQuadWall (2, 3, 0, new Vector2(0.5f,0));
		CreateQuadWall (3, 3, 0, new Vector2(0.5f,0));
		CreateQuadWall (4, 3, 0, new Vector2(0.5f,0));
		CreateQuadWall (5, 3, 0, new Vector2(0.5f,0));
		CreateQuadWall (6, 3, 0, new Vector2(0.5f,0));
		CreateQuadWall (1, 4, 0, new Vector2(0.5f,0));
		CreateQuadWall (2, 4, 0, new Vector2(0.5f,0));
		CreateQuadWall (3, 4, 0, new Vector2(0.5f,0));
		CreateQuadWall (4, 4, 0, new Vector2(0.5f,0));
		CreateQuadWall (5, 4, 0, new Vector2(0.5f,0));
		CreateQuadWall (6, 4, 0, new Vector2(0.5f,0));

		CreateQuadWall (1, 5, 0, new Vector2(0,0.5f));
		CreateQuadWall (2, 5, 0, new Vector2(0,0.5f));
		CreateQuadWall (3, 5, 0, new Vector2(0,0.5f));
		CreateQuadWall (4, 5, 0, new Vector2(0,0.5f));
		CreateQuadWall (5, 5, 0, new Vector2(0,0.5f));
		CreateQuadWall (6, 5, 0, new Vector2(0,0.5f));
		CreateQuadWall (1, 6, 0, new Vector2(0,0.5f));
		CreateQuadWall (2, 6, 0, new Vector2(0,0.5f));
		CreateQuadWall (3, 6, 0, new Vector2(0,0.5f));
		CreateQuadWall (4, 6, 0, new Vector2(0,0.5f));
		CreateQuadWall (5, 6, 0, new Vector2(0,0.5f));
		CreateQuadWall (6, 6, 0, new Vector2(0,0.5f));

		CreateQuadFloor (1, 1, -1, new Vector2(0,0));
		CreateQuadFloor (2, 1, -1, new Vector2(0,0));
		CreateQuadFloor (1, 1, -2, new Vector2(0,0));
		CreateQuadFloor (2, 1, -2, new Vector2(0,0));
		CreateQuadFloor (1, 1, -3, new Vector2(0,0));
		CreateQuadFloor (2, 1, -3, new Vector2(0,0));
		CreateQuadFloor (1, 1, -4, new Vector2(0,0));
		CreateQuadFloor (2, 1, -4, new Vector2(0,0));
		CreateQuadFloor (1, 1, -5, new Vector2(0,0));
		CreateQuadFloor (2, 1, -5, new Vector2(0,0));
		CreateQuadFloor (1, 1, -6, new Vector2(0,0));
		CreateQuadFloor (2, 1, -6, new Vector2(0,0));
		CreateQuadFloor (5, 1, -1, new Vector2(0,0));
		CreateQuadFloor (6, 1, -1, new Vector2(0,0));
		CreateQuadFloor (5, 1, -2, new Vector2(0,0));
		CreateQuadFloor (6, 1, -2, new Vector2(0,0));
		CreateQuadFloor (5, 1, -3, new Vector2(0,0));
		CreateQuadFloor (6, 1, -3, new Vector2(0,0));
		CreateQuadFloor (5, 1, -4, new Vector2(0,0));
		CreateQuadFloor (6, 1, -4, new Vector2(0,0));
		CreateQuadFloor (5, 1, -5, new Vector2(0,0));
		CreateQuadFloor (6, 1, -5, new Vector2(0,0));
		CreateQuadFloor (5, 1, -6, new Vector2(0,0));
		CreateQuadFloor (6, 1, -6, new Vector2(0,0));

		CreateQuadFloor (3, 1, -1, new Vector2(0.5f,0.5f));
		CreateQuadFloor (4, 1, -1, new Vector2(0.5f,0.5f));
		CreateQuadFloor (3, 1, -2, new Vector2(0.5f,0.5f));
		CreateQuadFloor (4, 1, -2, new Vector2(0.5f,0.5f));
		CreateQuadFloor (3, 1, -3, new Vector2(0.5f,0.5f));
		CreateQuadFloor (4, 1, -3, new Vector2(0.5f,0.5f));
		CreateQuadFloor (3, 1, -4, new Vector2(0.5f,0.5f));
		CreateQuadFloor (4, 1, -4, new Vector2(0.5f,0.5f));
		CreateQuadFloor (3, 1, -5, new Vector2(0.5f,0.5f));
		CreateQuadFloor (4, 1, -5, new Vector2(0.5f,0.5f));
		CreateQuadFloor (3, 1, -6, new Vector2(0.5f,0.5f));
		CreateQuadFloor (4, 1, -6, new Vector2(0.5f,0.5f));



		mesh.vertices = vertexList.ToArray ();
		mesh.triangles = triIndexList.ToArray ();
		mesh.uv = UVList.ToArray ();
		mesh.RecalculateNormals ();
		meshCollider.sharedMesh = null;
		meshCollider.sharedMesh = mesh;


	}

	void CreateQuadWall(int x, int y, int z, Vector2 uvCoords)
	{
		//vertexList = new List<Vector3> ();

		vertexList.Add (new Vector3 (x, y+1, z));
		vertexList.Add (new Vector3 (x+1, y+1, z));
		vertexList.Add (new Vector3 (x+1, y, z));
		vertexList.Add (new Vector3 (x, y, z));

		//triIndexList = new List<int> ();

		triIndexList.Add (numQuads * 4);
		triIndexList.Add ((numQuads * 4) + 1);
		triIndexList.Add ((numQuads * 4) + 3);
		triIndexList.Add ((numQuads * 4) + 1);
		triIndexList.Add ((numQuads * 4) + 2);
		triIndexList.Add ((numQuads * 4) + 3);
		numQuads++;

		UVList.Add (new Vector2 (uvCoords.x, uvCoords.y + 0.5f));
		UVList.Add (new Vector2 (uvCoords.x + 0.5f, uvCoords.y + 0.5f));
		UVList.Add (new Vector2 (uvCoords.x + 0.5f, uvCoords.y));
		UVList.Add (new Vector2 (uvCoords.x, uvCoords.y));
	}

	void CreateQuadFloor(int x, int y, int z, Vector2 uvCoords)
	{
		//vertexList = new List<Vector3> ();
		
		vertexList.Add (new Vector3 (x, y, z+1));
		vertexList.Add (new Vector3 (x+1, y, z+1));
		vertexList.Add (new Vector3 (x+1, y, z));
		vertexList.Add (new Vector3 (x, y, z));
		
		//triIndexList = new List<int> ();
		
		triIndexList.Add (numQuads * 4);
		triIndexList.Add ((numQuads * 4) + 1);
		triIndexList.Add ((numQuads * 4) + 3);
		triIndexList.Add ((numQuads * 4) + 1);
		triIndexList.Add ((numQuads * 4) + 2);
		triIndexList.Add ((numQuads * 4) + 3);
		numQuads++;
		
		UVList.Add (new Vector2 (uvCoords.x, uvCoords.y + 0.5f));
		UVList.Add (new Vector2 (uvCoords.x + 0.5f, uvCoords.y + 0.5f));
		UVList.Add (new Vector2 (uvCoords.x + 0.5f, uvCoords.y));
		UVList.Add (new Vector2 (uvCoords.x, uvCoords.y));
	}
	

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit))
			if (hit.collider != null)
				Debug.Log ("hit a block");
		}
	}

}

