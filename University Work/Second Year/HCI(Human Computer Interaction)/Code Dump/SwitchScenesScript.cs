using UnityEngine;
using System.Collections;

public class SwitchScenesScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SwitchScenes (string switchScene)
	{
		Application.LoadLevel (switchScene);
	}

	public void Quit()
	{
		Application.Quit ();
	}
}
