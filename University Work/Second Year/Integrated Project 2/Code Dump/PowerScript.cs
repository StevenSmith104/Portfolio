using UnityEngine;
using System.Collections;

public class PowerScript : MonoBehaviour {

	public bool test = false;
	int i = 0;
	PowerUp1 powerUp1;
	PowerUp2 powerUp2;
	PowerUp3 powerUp3;

	// Use this for initialization
	void Start () 
	{
		powerUp1 = GetComponent<PowerUp1> ();
		powerUp1.enabled = false;

		powerUp2 = GetComponent<PowerUp2> ();
		powerUp2.enabled = false;

		powerUp3 = GetComponent<PowerUp3> ();
		powerUp3.enabled = false;
	}

	void ChoosePowerUp()
	{
		i = Random.Range (1, 4);

		if (i == 1 && powerUp1.enabled == false) 
		{
			powerUp1.enabled = true;
		}
		else if (i == 2 && powerUp2.enabled == false) 
		{
			powerUp2.enabled = true;
		} 
		else if (i == 3 && powerUp3.enabled == false) 
		{
			powerUp3.enabled = true;
		} 
	}
	
	// Update is called once per frame
	void Update () {
	if (Grid.power == true) 
		{
			ChoosePowerUp();
			Grid.power = false;
		}
	}
}
