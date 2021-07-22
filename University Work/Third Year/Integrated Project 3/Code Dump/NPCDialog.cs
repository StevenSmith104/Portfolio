using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

public class NPCDialog : MonoBehaviour {

	public GameObject q1;
	public GameObject sell;
	public GameObject buy;
	public NPCWander npcWander;
	bool gotKey = false;
	public GameObject keyPrefab;

	// Use this for initialization
	void Start () 
	{
		
	}

	public void Exit ()
	{ 
		if(gotKey == false)
		{
			Vector3 keyTransform = this.transform.position + new Vector3(1.0f, 2.0f, 0.0f);

			Instantiate(keyPrefab, keyTransform , transform.rotation);
			gotKey = true;
		}

		npcWander.pause = false;
		GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = true;
		q1.SetActive(false);
		sell.SetActive(false);
		buy.SetActive(false);
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Confined;
	}

	public void BuySelect()
	{
		q1.SetActive(false);
		buy.SetActive(true);
	}

	public void SellSelect()
	{
		q1.SetActive(false);
		sell.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 fwd = transform.TransformDirection(Vector3.forward);

		if(Input.GetKeyDown("e"))
		{
			RaycastHit hit;
			//Debug.DrawRay(transform.position, fwd, Color.red, 10, false);
			if(Physics.Raycast(transform.position, fwd, out hit, 2))
			{
				/*if(hit.transform.tag == "NPC")
				{
					npcWander = hit.transform.gameObject.GetComponent<NPCWander>();
					npcWander.pause = true;
					GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = false;
					q1.SetActive(true);
					Cursor.lockState = CursorLockMode.None;
					Cursor.visible = true;
					//Debug.Log("NPC hit");
				}
				*/
			}
		}
	}
}
