using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerInventory : MonoBehaviour {

	public int rock = 0;
	public int wood = 0;
	public int gold = 0;
	public int money = 0;

	public GameObject popUp;
	public GameObject popUp2;

	// Use this for initialization
	void Start () 
	{
		
	}

	public void SellRock()
	{
		if (rock >=1)
		{
			rock--;
			money = money + 5;
		}
		else
		{
			StartCoroutine(PopUpTime());
		}
	}

	public void SellWood()
	{
		if (wood >=1)
		{
			wood--;
			money = money + 10;
		}
		else
		{
			StartCoroutine(PopUpTime());
		}
	}

	public void SellGold()
	{
		if(gold >=1)
		{
			gold--;
			money = money + 100;
		}
		else
		{
			StartCoroutine(PopUpTime());
		}
	}

	public void BuyRock()
	{
		if(money >= 10)
		{
			money = money - 10;
			rock++;
		}
		else
		{
			StartCoroutine(PopUpTime2());
		}

	}

	public void BuyWood()
	{
		if(money >=20)
		{
			money = money - 20;
			wood++;
		}
		else
		{
			StartCoroutine(PopUpTime2());
		}
	}

	public void BuyGold()
	{
		if(money >= 200)
		{
			money = money - 200;
			gold++;
		}
		else
		{
			StartCoroutine(PopUpTime2());
		}
	}

	IEnumerator PopUpTime()
	{
			PopUp();
			yield return new WaitForSeconds(1);
			PopUpClose();
	}

	IEnumerator PopUpTime2()
	{
			PopUp2();
			yield return new WaitForSeconds(1);
			PopUpClose2();
	}

	void PopUp()
	{
		popUp.SetActive(true);
	}

	void PopUpClose()
	{
		popUp.SetActive(false);
	}

	void PopUp2()
	{
		popUp2.SetActive(true);
	}

	void PopUpClose2()
	{
		popUp2.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 fwd = transform.TransformDirection(Vector3.forward);

		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			RaycastHit hit;
			if(Physics.Raycast(transform.position, fwd, out hit, 2))
			{
				if(hit.transform.tag == "Rock")
				{
					rock++;
					Destroy(hit.transform.gameObject);
				}
				else if (hit.transform.tag == "Wood")
				{
					wood++;
					Destroy(hit.transform.gameObject);
				}
				else if (hit.transform.tag == "Gold")
				{
					gold++;
					Destroy(hit.transform.gameObject);
				}
			}
		}
	}
}
