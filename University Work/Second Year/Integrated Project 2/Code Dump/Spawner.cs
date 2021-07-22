using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	//Groups
	public GameObject[] groups;
	public GameObject powerUp;
	public int rand = 0;
	public int i = 0;
	public int check = 0;
	public float x;

	bool clickedR = false;
	bool clickedL = false;

	// Use this for initialization
	void Start () {
		x = -5.0f;
		rand = (Random.Range(1,10));
	}

	public void spawnNext()
	{
		if (check != rand) 
		{
			Instantiate (groups [i], transform.position, Quaternion.identity);
			check++;
		} 
		else if (check == rand) 
		{
			Instantiate (powerUp, (transform.position + new Vector3(Random.Range(-10,11),0.0f,0.0f)), Quaternion.identity);
			rand = (Random.Range(1,10));
			check = 0;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetAxisRaw ("DictatorSelectRight") != 0 && i == 6) 
		{
			if(clickedR == false)
			{
				i = 0;
				clickedR = true;
			}
		}
		
		else if (Input.GetAxisRaw ("DictatorSelectRight") != 0 && i<=5 && i >= 0) 
		{
			if(clickedR == false)
			{
				i++;
				clickedR = true;
			}
		}
		
		else if (Input.GetAxisRaw ("DictatorSelectLeft") != 0 && i == 0)
		{
			if(clickedL == false)
			{
				i = 6;
				clickedL = true;
			}
		}
		
		else if (Input.GetAxisRaw ("DictatorSelectLeft") != 0 && i >= 1 && i <= 6) 
		{
			if(clickedL == false)
			{
				i--;
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


		else if (Input.GetButtonDown ("DictatorSpawn") && (Time.time - x) > 4.5f)
		{
			spawnNext ();
			x = Time.time;
		}
	}
}
