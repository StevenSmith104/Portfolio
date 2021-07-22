﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer),
                  typeof(MeshCollider))]

public class VoxelGenerator : MonoBehaviour {

	Mesh mesh;
	MeshCollider meshCollider;
	List<Vector3> vertexList;
	List<int> triIndexList;
	List<Vector2> UVList;
	public List<string> texNames;
	public List<Vector2> texCoords;
	public float texSize;
	Dictionary<string, Vector2> texNameCoordDictionary;

	int numQuads = 0;

	// Use this for initialization
	void Start () {
		//Initialise ();

		/*CreateVoxel (0, 0, 0, "Dirt");
		CreateVoxel (1, 0, 0, "Grass");
		CreateVoxel (2, 0, 0, "Grass");
		CreateVoxel (3, 0, 0, "Grass");
		CreateVoxel (3, 0, 1, "Grass");
		CreateVoxel (3, 0, 2, "Grass");
		CreateVoxel (4, 0, 2, "Grass");
		CreateVoxel (4, 0, 3, "Dirt");*/

	

		//UpdateMesh ();
	}

	/*
	 void CreateGround()
	{
		int x = 0;
		int y = 0;
		int z = 0;


		for(int i=0; i<10; i++)
		{
			for (int a=0; a<10; a++) 
			{

				CreateVoxel (x,y,z,"Dirt");
				x++;
			}
			z++;
			x=0;
		}
	}
	*/

	public void Initialise()
	{
		mesh = GetComponent<MeshFilter> ().mesh;
		meshCollider = GetComponent<MeshCollider> ();
		vertexList = new List<Vector3> ();
		triIndexList = new List<int> ();
		UVList = new List<Vector2> ();
		CreateTextureNameCoordDictionary ();
	}

	public void UpdateMesh()
	{
		mesh.Clear ();
		mesh.vertices = vertexList.ToArray ();
		//print ("vertices " + vertexList.Count);
		mesh.triangles = triIndexList.ToArray ();
		//print ("Quads " + numQuads);
		mesh.uv = UVList.ToArray ();
		mesh.RecalculateNormals ();
		meshCollider.sharedMesh = null;
		meshCollider.sharedMesh = mesh;
		ClearPreviousData ();
	}

	public void CreateVoxel(int x, int y, int z, string texture)
	{
		//Vector2 uvCoords = texNameCoordDictionary [texture];

		CreateNegativeXFace (x, y, z, texture);
		CreatePositiveXFace (x, y, z, texture);

		CreateNegativeYFace (x, y, z, texture);
		CreatePositiveYFace (x, y, z, texture);

		CreateNegativeZFace (x, y, z, texture);
		CreatePositiveZFace (x, y, z, texture);
	}

	public void CreateNegativeZFace(int x, int y, int z, string texture)
	{
		vertexList.Add (new Vector3 (x, y + 1, z));
		vertexList.Add (new Vector3 (x + 1, y + 1, z));
		vertexList.Add (new Vector3 (x + 1, y, z));
		vertexList.Add (new Vector3 (x, y, z));

		AddTriangleIndices ();
		Vector2 uvCoords = texNameCoordDictionary [texture];
		AddUVCoords (uvCoords);
	}

	public void CreatePositiveZFace(int x, int y, int z, string texture)
	{
		vertexList.Add (new Vector3 (x + 1, y, z + 1));
		vertexList.Add (new Vector3 (x + 1, y + 1, z + 1));
		vertexList.Add (new Vector3 (x, y + 1, z + 1));
		vertexList.Add (new Vector3 (x, y, z + 1));

		AddTriangleIndices ();
		Vector2 uvCoords = texNameCoordDictionary [texture];
		AddUVCoords (uvCoords);
	}

	public void CreateNegativeXFace(int x, int y, int z, string texture)
	{
		vertexList.Add (new Vector3 (x, y, z + 1));
		vertexList.Add (new Vector3 (x, y + 1, z + 1));
		vertexList.Add (new Vector3 (x, y + 1, z));
		vertexList.Add (new Vector3 (x, y, z));

		AddTriangleIndices ();
		Vector2 uvCoords = texNameCoordDictionary [texture];
		AddUVCoords (uvCoords);
	}

	public void CreatePositiveXFace(int x, int y, int z, string texture)
	{
		vertexList.Add (new Vector3 (x + 1, y, z));
		vertexList.Add (new Vector3 (x + 1, y + 1, z));
		vertexList.Add (new Vector3 (x + 1, y + 1, z + 1));
		vertexList.Add (new Vector3 (x + 1, y, z + 1));

		AddTriangleIndices ();
		Vector2 uvCoords = texNameCoordDictionary [texture];
		AddUVCoords (uvCoords);
	}

	public void CreateNegativeYFace(int x, int y, int z, string texture)
	{
		vertexList.Add (new Vector3 (x + 1, y, z));
		vertexList.Add (new Vector3 (x + 1, y, z + 1));
		vertexList.Add (new Vector3 (x, y, z + 1));
		vertexList.Add (new Vector3 (x, y, z));

		AddTriangleIndices ();
		Vector2 uvCoords = texNameCoordDictionary [texture];
		AddUVCoords (uvCoords);
	}

	public void CreatePositiveYFace(int x, int y,int z, string texture)
	{
		vertexList.Add (new Vector3 (x, y + 1, z));
		vertexList.Add (new Vector3 (x, y + 1, z + 1));
		vertexList.Add (new Vector3 (x + 1, y + 1, z + 1));
		vertexList.Add (new Vector3 (x + 1, y + 1, z));

		AddTriangleIndices ();
		Vector2 uvCoords = texNameCoordDictionary [texture];
		AddUVCoords (uvCoords);
	}

	void AddTriangleIndices()
	{
		triIndexList.Add (numQuads * 4);
		triIndexList.Add ((numQuads * 4) + 1);
		triIndexList.Add ((numQuads * 4) + 3);
		triIndexList.Add ((numQuads * 4) + 1);
		triIndexList.Add ((numQuads * 4) + 2);
		triIndexList.Add ((numQuads * 4) + 3);
		numQuads++;
	}

	void AddUVCoords(Vector2 uvCoords)
	{
		UVList.Add (new Vector2 (uvCoords.x, uvCoords.y + 0.5f));
		UVList.Add (new Vector2 (uvCoords.x + 0.5f, uvCoords.y + 0.5f));
		UVList.Add (new Vector2 (uvCoords.x + 0.5f, uvCoords.y));
		UVList.Add (new Vector2 (uvCoords.x, uvCoords.y));
	}

	void CreateTextureNameCoordDictionary()
	{
		texNameCoordDictionary = new Dictionary<string, Vector2> ();

		if (texNames.Count == texCoords.Count) {
			for (int i = 0; i < texNames.Count; i++) {
				texNameCoordDictionary.Add (texNames [i], texCoords [i]);
			}
		} 
		else 
		{
			Debug.Log ("texNames and texCoords count mismatch");
		}
	
	}

	void ClearPreviousData()
	{
		vertexList.Clear ();
		triIndexList.Clear ();
		UVList.Clear ();
		numQuads = 0;
	}



	
	// Update is called once per frame
	void Update () {
	
	}
}
