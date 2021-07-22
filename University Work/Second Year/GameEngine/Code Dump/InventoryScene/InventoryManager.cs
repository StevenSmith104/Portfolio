using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {

	public Transform parentPanel;

	public List<Sprite> itemSprites;
	public List<string> itemNames;
	public List<int> 	itemAmounts;

	public GameObject startItem;

	List<InventoryItemScript> inventoryList;
	// Use this for initialization
	void Start () {
		inventoryList = new List<InventoryItemScript> ();
		for (int i = 0; i < itemNames.Count; i++) 
		{
			GameObject inventoryItem = (GameObject)Instantiate (startItem);
			inventoryItem.transform.SetParent (parentPanel);
			inventoryItem.SetActive (true);

			InventoryItemScript iis = inventoryItem.GetComponent<InventoryItemScript> ();
			iis.itemSprite.sprite = itemSprites [i];
			iis.itemNameText.text = itemNames [i];
			iis.itemName = itemNames [i];
			iis.itemAmountText.text = itemAmounts [i].ToString ();
			iis.itemAmount = itemAmounts [i];

			inventoryList.Add (iis);

		}
		DisplayListInOrder();
	}

	void DisplayListInOrder()
	{
		float yOffset = 55f;

		Vector3 startPosition = startItem.transform.position;
		foreach (InventoryItemScript iis in inventoryList) 
		{
			iis.transform.position = startPosition;

			startPosition.y -= yOffset;
		}
	}

	public void StartQuickSort()
	{
		inventoryList = QuickSort (inventoryList);
		DisplayListInOrder ();
	}

	public void StartMergeSort()
	{
		inventoryList = Sort (inventoryList);
		DisplayListInOrder ();
	}

	public void SelectionSortInventory()
	{
		for (int i = 0; i < inventoryList.Count-1; i++) 
		{
			int minIndex = i;
			for(int j = i; j<inventoryList.Count; j++)
			{
				if(inventoryList[j].itemAmount < inventoryList[minIndex].itemAmount)
				{
					minIndex = j;
				}
			}
		if(minIndex!=i)
			{
				InventoryItemScript iis = inventoryList[i];
				inventoryList[i] = inventoryList[minIndex];
				inventoryList[minIndex] = iis;
			}
		}
		DisplayListInOrder ();
	}

	public void InsertionSortInventory()
	{
		int i,j;

		for (j=1; j <inventoryList.Count - 1; j++) 
		{
			i = j;

			while(i > 0 && inventoryList[i-1].itemAmount > inventoryList[i].itemAmount)
			{
				inventoryList[i] = inventoryList[i-1];
			}
		}
	}

	List<InventoryItemScript> QuickSort(List<InventoryItemScript> listIn)
	{
		if(listIn.Count <=1)
		{
			return listIn;
		}

		int pivotIndex = 0;

		List<InventoryItemScript> leftList = new List<InventoryItemScript>();
		List<InventoryItemScript> rightList = new List<InventoryItemScript> ();

		for (int i = 1; i < listIn.Count; i++) 
		{
			if(listIn[i].itemAmount > listIn[pivotIndex].itemAmount)
			{
				leftList.Add (listIn[i]);
			}
			else
			{
				rightList.Add(listIn[i]);
			}
		}
		leftList = QuickSort (leftList);
		rightList = QuickSort (rightList);

		leftList.Add (listIn [pivotIndex]);
		leftList.AddRange (rightList);

		return leftList;
	}

	List<InventoryItemScript> Sort(List<InventoryItemScript> listIn)
	{
		if (listIn.Count > 1) 
		{
			int mid = listIn.Count / 2;

			List<InventoryItemScript> left = new List<InventoryItemScript> ();

			for (int i = 0; i < mid; i++) 
				left.Add (listIn[i]);
			left = Sort(left);

			

			List<InventoryItemScript> right = new List<InventoryItemScript> ();

			for(int i = mid; i < listIn.Count; i++)
				right.Add(listIn[i]);
			right = Sort(right);
			
			

			listIn = Merge(left, right);

		}

		return listIn;
	}

	List<InventoryItemScript>Merge(List<InventoryItemScript> left, List<InventoryItemScript> right)
	{

		List<InventoryItemScript> temp = new List<InventoryItemScript> ();
		int i = 0;
		int j = 0;

		while (i < left.Count || j < right.Count) 
		{
			if (i < left.Count && j < right.Count) 
			{
				if(left[i].itemAmount > right[j].itemAmount)
				{
					temp.Add(right[j]);
					j++;
				}
				else
				{
					temp.Add(left[i]);
					i++;
				}
			}
			else if(i < left.Count)
			{
				temp.Add(left[i]);
				i++;
			}
			else if(j < right.Count)
			{
				temp.Add(right[j]);
				j++;
			}
		}
		return temp;
	}
}
