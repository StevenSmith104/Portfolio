using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {
	public int id;
	GameObject spawn;
	private Inventory inv;

	/*
	GameObject item0;
	GameObject item1;
	GameObject item2;
	GameObject item3;
	GameObject item4;
	GameObject item5;
	GameObject item6;
	*/

	void Start()
	{
		inv = GameObject.Find("InventoryObject").GetComponent<Inventory>();	
		/*
		spawn = GameObject.Find("ItemSpawn");
		item0 = GameObject.Find("TestItem0");
		item1 = GameObject.Find("TestItem1");
		item2 = GameObject.Find("TestItem2");
		item3 = GameObject.Find("TestItem3");
		item4 = GameObject.Find("TestItem4");
		item5 = GameObject.Find("TestItem5");
		item6 = GameObject.Find("TestItem6");
		*/
	}

	public void OnDrop(PointerEventData eventData)
	{
		ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
		if(inv.items[id].ID == -1)
		{
			inv.items[droppedItem.slot] = new Item();
			inv.items[id] = droppedItem.item;
			//Debug.Log("Slot hit " + id);
			droppedItem.slot = id;
			//Debug.Log(droppedItem.item.ID);
			/*
			if(droppedItem.slot == 11)
			{
				if(droppedItem.item.ID == 0)
				{
					Instantiate(item0, spawn.transform.position, Quaternion.identity);
				}
				else if(droppedItem.item.ID == 1)
				{
					Instantiate(item1, spawn.transform.position, Quaternion.identity);
				}
				else if(droppedItem.item.ID == 2)
				{
					Instantiate(item2, spawn.transform.position, Quaternion.identity);
				}
				else if(droppedItem.item.ID == 3)
				{
					Instantiate(item3, spawn.transform.position, Quaternion.identity);
				}
				else if(droppedItem.item.ID == 4)
				{
					Instantiate(item4, spawn.transform.position, Quaternion.identity);
				}
				else if(droppedItem.item.ID == 5)
				{
					Instantiate(item5, spawn.transform.position, Quaternion.identity);
				}
				else if(droppedItem.item.ID == 6)
				{
					Instantiate(item6, spawn.transform.position, Quaternion.identity);
				}
				inv.items[droppedItem.slot] = new Item();
				Destroy(droppedItem.gameObject);
			}
			*/
		}
		else if(droppedItem.slot !=id) 
		{
			Transform item = this.transform.GetChild(0);
			item.GetComponent<ItemData>().slot = droppedItem.slot;
			item.transform.SetParent(inv.slots[droppedItem.slot].transform);
			item.transform.position = inv.slots[droppedItem.slot].transform.position;

			droppedItem.slot = id;
			droppedItem.transform.SetParent(this.transform);
			droppedItem.transform.position = this.transform.position;

			inv.items[droppedItem.slot] = item.GetComponent<ItemData>().item;
			inv.items[id] = droppedItem.item;

			/*
			if(droppedItem.slot == 11)
			{
				Debug.Log("Test");
				if(droppedItem.item.ID == 0)
				{
					Instantiate(item0, spawn.transform.position, Quaternion.identity);
				}
				else if(droppedItem.item.ID == 1)
				{
					Instantiate(item1, spawn.transform.position, Quaternion.identity);
				}
				else if(droppedItem.item.ID == 2)
				{
					Instantiate(item2, spawn.transform.position, Quaternion.identity);
				}
				else if(droppedItem.item.ID == 3)
				{
					Instantiate(item3, spawn.transform.position, Quaternion.identity);
				}
				else if(droppedItem.item.ID == 4)
				{
					Instantiate(item4, spawn.transform.position, Quaternion.identity);
				}
				else if(droppedItem.item.ID == 5)
				{
					Instantiate(item5, spawn.transform.position, Quaternion.identity);
				}
				else if(droppedItem.item.ID == 6)
				{
					Instantiate(item6, spawn.transform.position, Quaternion.identity);
				}
				inv.items[droppedItem.slot] = new Item();
				Destroy(droppedItem.gameObject);

			}
		*/
		}
	}
}
