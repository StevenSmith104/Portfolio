using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {


	public GameObject[] select;
	public GameObject show;
	public int i =0;

	bool clickedR = false;
	bool clickedL = false;

	// Use this for initialization
	void Start () {
	
		Instantiate (select [i], transform.position, Quaternion.identity);
		//show.name = "showBlock";
	}

	void deleteOld()
	{
		show = GameObject.FindGameObjectWithTag ("Selected");
		GameObject.Destroy (show);
	}

	void showBlock(){

		deleteOld ();

	 Instantiate (select [i], transform.position, Quaternion.identity);
		//show.name = "showBlock";

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxisRaw ("DictatorSelectRight") != 0 && i == 6) 
		{
			if(clickedR == false)
			{
				i = 0;
				showBlock ();
				clickedR = true;
			}
		}
	
		else if (Input.GetAxisRaw ("DictatorSelectRight") != 0 && i<=5 && i >= 0) 
		{
			if(clickedR == false)
			{
				i++;
				showBlock ();
				clickedR = true;
			}
		}
		
		else if (Input.GetAxisRaw ("DictatorSelectLeft") != 0 && i == 0)
		{
			if(clickedL == false)
			{
				i = 6;
				showBlock ();
				clickedL = true;
			}
		}

		else if (Input.GetAxisRaw ("DictatorSelectLeft") != 0 && i >= 1 && i <= 6) 
		{
			if(clickedL == false)
			{
				i--;
				showBlock ();
				clickedL = true;
			}
		}

		if (Input.GetAxisRaw("DictatorSelectRight") == 0 && clickedR == true)
		{
			clickedR = false;
		}

		if (Input.GetAxisRaw("DictatorSelectLeft") == 0 && clickedL == true)
		{
			clickedL = false;
		}

	}
}
