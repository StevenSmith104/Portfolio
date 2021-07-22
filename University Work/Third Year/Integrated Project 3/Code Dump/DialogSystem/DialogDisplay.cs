using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class DialogDisplay : MonoBehaviour
{
	public Text dialogText;
	public GameObject dialogBox;
	public GameObject pipeMinigame;
	public Sprite[] phoneImages;
	public Image phone;
	public GameObject winText;

	DialogDatabase dialogDatabase;

	public Inventory inventory;

	List<Dialog> dialogs = new List<Dialog>();

	public GameObject player;

	public bool checkDialogExists = false;

	bool task1complete = false;
	bool task2complete = false;
	bool task3complete = false;
	bool task4complete = false;
	bool task5complete = false;

	bool dialogOpen = false;

	int x = 0;

	// Use this for initialization
	void Start ()
	{
		dialogDatabase = GetComponent<DialogDatabase>();

		dialogBox = GameObject.Find("DialogBox");
		dialogText = GameObject.Find("DialogText").GetComponent<Text>();

		dialogBox.SetActive(false);
	}

	public void ShowInactiveDialog(int id)
	{
		Dialog dialogToDisplay = dialogDatabase.FetchDialogByID(id);
		dialogBox.SetActive(true);
		dialogText.text = dialogToDisplay.InactiveSpeech;
		GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = false;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	public void ShowActiveDialog(int id)
	{
		Dialog dialogToDisplay = dialogDatabase.FetchDialogByID(id);
		dialogBox.SetActive(true);
		dialogText.text = dialogToDisplay.ActiveSpeech;
		GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = false;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	public void ShowActiveDialog2(int id)
	{
		Dialog dialogToDisplay = dialogDatabase.FetchDialogByID(id);
		dialogBox.SetActive(true);
		dialogText.text = dialogToDisplay.ActiveSpeech2;
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

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown("e"))
		{
			Transform cam = Camera.main.transform;
			Vector3 fwd = transform.TransformDirection (Vector3.forward);

			Ray ray = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit, 2))
			{
				if(hit.transform.tag == "NPC")
				{
					if (dialogOpen == false) {

						dialogOpen = true;

						if (hit.transform.name == "ShopKeeper") {
							if (task1complete == false) {
								ShowActiveDialog (0);
								task1complete = true;
								x++;
								phone.sprite = phoneImages[x];
							} else if (task1complete == true) {
								ShowActiveDialog2 (0);
							}
						}
						if (hit.transform.name == "Boss" && task3complete == false) {
							if (task1complete == false) {
								ShowInactiveDialog (1);
							} else if (task1complete == true && task2complete == false) {
								ShowActiveDialog (1);
								task2complete = true;
								x++;
								phone.sprite = phoneImages[x];
							} else if (task2complete == true) {
								ShowActiveDialog2 (1);
							}
						}
						if (hit.transform.name == "BoothKeeper") {
							if (task2complete == false) {
								ShowInactiveDialog (3);
							} else if (task2complete == true && task3complete == false) {
								ShowActiveDialog (3);
								task3complete = true;
								x++;
								phone.sprite = phoneImages[x];
							} else if (task3complete == true) {
								ShowActiveDialog2 (3);
							}
						}
						if (hit.transform.name == "Boss" && task3complete == true) {
							if (task3complete == true && task4complete == false || inventory.sandbagPickedUp == false) {
								ShowActiveDialog (4);
								task4complete = true;
								x++;
								x++;
								phone.sprite = phoneImages[x];
							} else if (task4complete == true && inventory.sandbagPickedUp == true) {
								ShowActiveDialog2 (4);
							}
						}
						if (hit.transform.name == "Mr Van Der Sar") {
							if (task4complete == false) {
								ShowInactiveDialog (2);
							} else if (task4complete == true && task5complete == false) {
								ShowActiveDialog (2);
								task5complete = true;
								x++;
								phone.sprite = phoneImages[x];
							} else if (task5complete == true) {
								ShowActiveDialog2 (2);
							}
						}
						if (hit.transform.name == "BarryTalkable") 
						{
							ShowInactiveDialog (5);
						}
						if (hit.transform.name == "CH_Updated") 
						{
							ShowInactiveDialog (5);
						}
						if (hit.transform.name == "ControlPanel") 
						{
							if (task5complete == true) {
								pipeMinigame.SetActive (true);
								x++;
								phone.sprite = phoneImages[x];
								Cursor.visible = true;
								Cursor.lockState = CursorLockMode.None;
								GameObject.Find ("Player").GetComponent<FirstPersonController> ().enabled = false;
							}
						}
					} 
					else if (dialogOpen == true) 
					{
						CloseDialog ();
						dialogOpen = false;
					}
				}
			}
		}
	}
}


