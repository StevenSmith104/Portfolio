using UnityEngine;
using System.Collections;

public class VoxelChunk : MonoBehaviour {

	public delegate void EventBlockChanged(int blockType);

	public static event EventBlockChanged OnEventBlockChanged;


	VoxelGenerator voxelGenerator;
	int[,,] terrainArray;
	int chunkSize = 16;
	public GameObject player;
	float[,,] playerTransform;
	float[,,] playerRotation;
	Vector3 playerTransformVector;

	// Use this for initialization
	void Start () {

		voxelGenerator = GetComponent<VoxelGenerator> ();
		terrainArray = new int[chunkSize, chunkSize, chunkSize];

		voxelGenerator.Initialise ();
		InitialiseTerrain ();
		CreateTerrain ();
		voxelGenerator.UpdateMesh ();
	
	}

	void InitialiseTerrain()
	{
		terrainArray = new int[chunkSize, chunkSize, chunkSize];

		for (int x = 0; x < terrainArray.GetLength(0); x++) 
		{
			for (int y = 0; y < terrainArray.GetLength(1); y++)
			{
				for (int z = 0; z < terrainArray.GetLength(2); z++)
				{
					if (y == 3)
					{
						terrainArray[x,y,z] = 1;
						terrainArray[0,3,1] = 3;
						terrainArray[0,3,2] = 3;
						terrainArray[0,3,3] = 3;
						terrainArray[1,3,3] = 3;
						terrainArray[1,3,4] = 3;
						terrainArray[2,3,4] = 3;
						terrainArray[3,3,4] = 3;
						terrainArray[4,3,4] = 3;
						terrainArray[5,3,4] = 3;
						terrainArray[5,3,3] = 3;
						terrainArray[5,3,2] = 3;
						terrainArray[6,3,2] = 3;
						terrainArray[7,3,2] = 3;
						terrainArray[8,3,2] = 3;
						terrainArray[9,3,2] = 3;
						terrainArray[10,3,2] = 3;
						terrainArray[11,3,2] = 3;
						terrainArray[12,3,2] = 3;
						terrainArray[13,3,2] = 3;
						terrainArray[13,3,3] = 3;
						terrainArray[14,3,3] = 3;
						terrainArray[15,3,3] = 3;
					}
					else if (y < 3)
					{
						terrainArray[x,y,z] = 2;
					}
				}
			}
		}
	}

	void CreateTerrain()
	{
		for (int x = 0; x < terrainArray.GetLength(0); x++) 
		{
			for (int y = 0; y < terrainArray.GetLength(1); y++) 
			{
				for (int z = 0; z < terrainArray.GetLength(2); z++) 
				{
					if (terrainArray [x, y, z] != 0) {
						string tex;

						switch (terrainArray [x, y, z]) {
						case 1:
							tex = "Grass";
							break;
						case 2:
							tex = "Dirt";
							break;
						case 3:
							tex = "Stone";
							break;
						default:
							tex = "Grass";
							break;
						}
						/*voxelGenerator.CreateVoxel (x, y, z, tex);*/
						if(x==0||terrainArray[x-1,y,z] == 0)
						{
							voxelGenerator.CreateNegativeXFace(x, y, z, tex);
						}
						if (x==terrainArray.GetLength(0) - 1 || terrainArray[x + 1,y,z]==0)
						{
							voxelGenerator.CreatePositiveXFace(x, y, z, tex);
						}
						if (y==0||terrainArray[x,y-1,z] == 0)
						{
							voxelGenerator.CreateNegativeYFace(x, y, z, tex);
						}
						if (y==terrainArray.GetLength(1) - 1 || terrainArray[x,y+1,z] == 0)
						{
							voxelGenerator.CreatePositiveYFace(x,y,z,tex);
						}
						if(z==0||terrainArray[x,y,z-1] == 0)
						{
							voxelGenerator.CreateNegativeZFace(x,y,z,tex);
						}
						if(z==terrainArray.GetLength(2) - 1 || terrainArray[x,y,z+1] == 0)
						{
							voxelGenerator.CreatePositiveZFace(x,y,z,tex);
						}

						//print ("Create " + tex + " block,");
					}
				}
			}
		}

	}

	[RPC]public void SetBlock(Vector3 index, int blockType)
	{
		if ((index.x > 0 && index.x < terrainArray.GetLength (0)) &&
			(index.y > 0 && index.y < terrainArray.GetLength (1)) &&
			(index.z > 0 && index.z < terrainArray.GetLength (2))) 
		{
			terrainArray [(int)index.x, (int)index.y, (int)index.z] = blockType;
			CreateTerrain ();
			voxelGenerator.UpdateMesh ();

			if (OnEventBlockChanged != null) 
			{
				OnEventBlockChanged(blockType);
			}
			//OnEventBlockChanged(blockType);

		}
	}

	void OnEnable()
	{
		PlayerScript.OnEventSetBlock += SetBlock;
	}

	void OnDisable()
	{
		PlayerScript.OnEventSetBlock -= SetBlock;
	}



	public bool IsTraversable(Vector3 voxel)
	{
		bool isEmpty = terrainArray [(int)voxel.x, (int)voxel.y, (int)voxel.z] == 0;
		bool isBelowStone = terrainArray [(int)voxel.x, (int)voxel.y - 1, (int)voxel.z] == 3;
		return isEmpty && isBelowStone;
	}

	public int GetChunkSize()
	{
		return chunkSize;
	}
	
	// Update is called once per frame
	void Update () 
	{


		if (Input.GetKeyDown (KeyCode.Keypad4)) 
		{



			XMLVoxelFileWriter.SaveChunkToXMLFile(terrainArray, "VoxelChunk");
		}

		if (Input.GetKeyDown (KeyCode.Keypad5)) 
		{
			terrainArray = XMLVoxelFileWriter.LoadChunkFromXMLFile(16,"VoxelChunk");
			CreateTerrain();
			voxelGenerator.UpdateMesh();
		}
	}
}
