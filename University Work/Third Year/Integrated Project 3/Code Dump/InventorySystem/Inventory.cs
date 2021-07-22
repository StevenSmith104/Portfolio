using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	GameObject inventoryPanel;
	GameObject slotPanel;
    GameObject phone;

	ItemDatabase database;

	public GameObject inventorySlot;
	public GameObject inventoryItem;
	public GameObject player;

	int slotAmount;
	public List<Item> items = new List<Item>();
	public List<GameObject> slots = new List<GameObject>();
	public bool checkItemExists = false;
	public bool inventoryOpen = false;

	bool task1complete = false;
	bool task2complete = false;
	bool task3complete = false;
	bool task4complete = false;
	bool task5complete = false;

	public bool sandbagPickedUp = false;
	public bool toolkitCollected = false;


	void Start()
	{
		
		database = GetComponent<ItemDatabase>();

		slotAmount = 12;
		inventoryPanel = GameObject.Find("Inventory Panel");
		slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;
        phone = GameObject.Find("Phone");
		for(int i = 0; i < slotAmount; i++)
		{
			items.Add(new Item());
			slots.Add(Instantiate(inventorySlot));
			slots[i].GetComponent<Slot>().id = i;
			slots[i].transform.SetParent(slotPanel.transform);
		}
			
		inventoryPanel.SetActive(false);
        phone.SetActive(false);
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	public void AddItem(int id)
	{
		Item itemToAdd = database.FetchItemByID(id);
		CheckItem(itemToAdd);
		if(itemToAdd.Stackable && checkItemExists == true)
		{
			for(int i = 0; i < items.Count; i++)
			{
				if(items[i].ID == id)
				{
					ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
					data.amount++;
					data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
					checkItemExists = false;
					break;
				}
			}
		}
		else
		{
			for (int i = 0; i < items.Count; i++)
			{
				if(items[i].ID == -1)
				{
					items[i] = itemToAdd;
					GameObject itemObj = Instantiate(inventoryItem);
					itemObj.GetComponent<ItemData>().item = itemToAdd;
					itemObj.GetComponent<ItemData>().amount = 1;
					itemObj.GetComponent<ItemData>().slot = i;
					itemObj.transform.SetParent(slots[i].transform);
					itemObj.transform.position = slots[i].transform.position;
					//Vector3 offset = new Vector3(0.0f, 0.0f, 20.0f);
					//itemObj.transform.position += offset; 
					itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
					itemObj.name = itemToAdd.Title;
					break;
				}
			}
		}
	}

	public void CheckItem(Item item)
	{
		for(int i = 0; i < items.Count; i++)
		{
			if(items[i].ID == item.ID)
			{
				checkItemExists = true;
			}
		}
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Tab))
		{
			
			Vector3 offset = new Vector3(100.0f, 100.0f, 0.0f);
			if(inventoryOpen == false)
			{
				GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = false;
				inventoryPanel.SetActive(true);
                phone.SetActive(true);
				inventoryOpen = true;
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
			else if(inventoryOpen == true)
			{
				GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = true;
				inventoryPanel.SetActive(false);
                phone.SetActive(false);
				inventoryOpen = false;
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			}
		}

		if(Input.GetKeyDown("e"))
		{
			Transform cam = Camera.main.transform;
			Vector3 fwd = transform.TransformDirection (Vector3.forward);

			Ray ray = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 2)) 
			{
				if (hit.transform.tag == "ItemPickup") 
				{
					if(hit.transform.name == "TestItem1(Clone)")
					{
						Destroy(hit.transform.gameObject);
						AddItem(1);
						sandbagPickedUp = true;
					}
				}

				if(hit.transform.tag == "NPC")
				{
					if(hit.transform.name == "ShopKeeper")
					{
						if(task1complete == false)
						{
							AddItem(0);
							task1complete = true;
						}
					}
					if (hit.transform.name == "Boss" && task3complete == false)
					{
						if(task1complete == true && task2complete == false)
						{
							task2complete = true;
						}
					}
					if (hit.transform.name == "BoothKeeper")
					{
						if(task2complete == true && task3complete == false)
						{
							AddItem(2);
							task3complete = true;
						}
					}
					if (hit.transform.name == "Boss" && task3complete == true)
					{
						if(task3complete == true && task4complete == false && sandbagPickedUp == true)
						{
							AddItem(3);
							task4complete = true;
						}
					}
					if (hit.transform.name == "Mr Van Der Sar")
					{
						if(task4complete == true && task5complete == false)
						{
							AddItem(4);
							task5complete = true;
							toolkitCollected = true;
						}
					}
				}
			}
		}
	}
}
