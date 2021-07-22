using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class MinorDialogDisplay : MonoBehaviour
{
	public Text dialogText;
	public GameObject dialogBox;

	MinorDialogData minorDialogData;

	List<MinorDialog> dialogs = new List<MinorDialog>();

	public GameObject player;

	public bool checkDialogExists = false;

	bool dialogOpen = false;

	int x = 0;

	// Use this for initialization
	void Start ()
	{
		minorDialogData = GetComponent<MinorDialogData>();

		//dialogBox = GameObject.Find("DialogBox");
		//dialogText = GameObject.Find("DialogText").GetComponent<Text>();
	}
	
	public void ShowDialog(int id)
	{
		MinorDialog dialogToDisplay = minorDialogData.FetchDialogByID(id);
		dialogBox.SetActive(true);
		dialogText.text = dialogToDisplay.Speech;
		GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = false;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	public void CloseDialog()
	{
		dialogText.text = "";
		dialogBox.SetActive(false);
		GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = true;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Confined;
	}

	void Update()
	{
		if(Input.GetKeyDown("e"))
		{
			Transform cam = Camera.main.transform;
			Vector3 fwd = transform.TransformDirection (Vector3.forward);

			Ray ray = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit, 2))
			{
				if(hit.transform.tag == "MinorNPC")
				{
					if(dialogOpen == false)
					{
						x = Random.Range(0, 9);
						ShowDialog(x);
						dialogOpen = true;
					}
					else if(dialogOpen == true)
					{
						CloseDialog();
						dialogOpen = false;
					}
				}
			}
		}
	}
}

