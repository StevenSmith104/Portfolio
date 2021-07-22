using UnityEngine;
using System.Collections;

public class Q1Script : MonoBehaviour {

	public GameObject cubePrefab;
	public GameObject spherePrefab;

	// Use this for initialization
	void Start () 
	{
	
	}

	public void Option1()
	{
		GameObject cube = (GameObject)Instantiate(cubePrefab, transform.position, transform.rotation);
	}

	public void Option2()
	{
		GameObject sphere = (GameObject)Instantiate(spherePrefab, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
