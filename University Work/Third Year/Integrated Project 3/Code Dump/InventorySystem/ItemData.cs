using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler {
	public Item item;
	public int amount;
	public int slot;
	public bool tooltipActive = false;

	private Inventory inv;
	private ToolTip tooltip;
	private Vector2 offset;

	void Start()
	{
		inv = GameObject.Find("InventoryObject").GetComponent<Inventory>();
		tooltip = inv.GetComponent<ToolTip>();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if(item != null)
		{
			offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
			this.transform.SetParent(this.transform.parent.parent);
			this.transform.position = eventData.position - offset;
			GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if(item != null)
		{
			this.transform.position = eventData.position - offset;
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		this.transform.SetParent(inv.slots[slot].transform);
		this.transform.position = inv.slots[slot].transform.position;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		//Debug.Log("Test");
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		tooltip.Activate(item);
		tooltipActive = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.Deactivate();
		tooltipActive = false;
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Tab))
		{
			if(tooltipActive == true)
			{
				tooltip.Deactivate();
				tooltipActive = false;
			}
		}
	}



}
