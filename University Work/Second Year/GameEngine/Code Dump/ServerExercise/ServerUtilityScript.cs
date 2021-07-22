using UnityEngine;
using System.Collections;

public class ServerUtilityScript : MonoBehaviour {

	string typeName = "WGEStevenSmithGame";
	string gameName = "WGEStevenSmithRoom";
	HostData[] hostList;
	string ipAddress = "10.15.1.170";
	public GameObject voxelObjectPrefab;
	public GameObject networkFPCPrefab;
	public GameObject mainCamera;

	// Use this for initialization
	void Start () 
	{
		MasterServer.ipAddress = ipAddress;
	}

	public void StartServer()
	{
		if (!Network.isServer && !Network.isClient) 
		{
			Network.InitializeServer (4, 25000, !Network.HavePublicAddress ());
			MasterServer.RegisterHost (typeName, gameName);
		}
	}

	public void RefreshHostList()
	{
		MasterServer.RequestHostList (typeName);
	}

	void OnMasterServerEvent(MasterServerEvent msEvent)
	{
		if (msEvent == MasterServerEvent.HostListReceived) 
		{
			hostList = MasterServer.PollHostList ();

			foreach (HostData hd in hostList) 
			{
				if (hd.gameName == gameName) 
				{
					Network.Connect (hd);
				}
			}
		}
	}

	void OnServerInitialized()
	{
		Debug.Log ("Server Initialized");
		Network.Instantiate (voxelObjectPrefab, Vector3.zero, Quaternion.identity, 0);
	}

	void OnConnectedToServer()
	{
		Debug.Log ("Server Joined");
		mainCamera.SetActive (false);
		Network.Instantiate (networkFPCPrefab, new Vector3 (8, 8, 8), Quaternion.identity, 0);
		//SpawnPlayer():
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
