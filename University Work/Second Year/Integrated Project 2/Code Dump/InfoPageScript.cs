using UnityEngine;
using System.Collections;

public class InfoPageScript : MonoBehaviour {

	public Sprite page1, page2;
	public bool pageOne = true;

	// Use this for initialization
	void Start () 
	{

	}

	public void Exit()
	{
		Application.LoadLevel("MainMenu");
	}

	public void TurnPage()
	{
		if(pageOne == true)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = page2;
			pageOne = false;
		}
		else if (pageOne == false)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = page1;
			pageOne = true;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
