using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryManager : SingletonBehavior<InventoryManager>
{
	private List<InteractableEntity> documents = new List<InteractableEntity>();
	private List<InteractableEntity> photographs = new List<InteractableEntity>();
	private List<InteractableEntity> smallKeys = new List<InteractableEntity>();
	private List<InteractableEntity> keyItems = new List<InteractableEntity>();
	private List<InteractableEntity> miscItems = new List<InteractableEntity>();

	public void AddItem(InteractableEntity toAdd, ItemType typeOfItem, Action OnItemAdded = null)
	{
		switch (typeOfItem)
		{
			case ItemType.DOCUMENT:
				documents.Add(toAdd);
				break;
			case ItemType.PHOTOGRAPH:
				photographs.Add(toAdd);
				break;
			case ItemType.SMALL_KEYS:
				smallKeys.Add(toAdd);
				break;
			case ItemType.KEY_ITEM:
				keyItems.Add(toAdd);
				break;
			case ItemType.MISC_ITEM:
				miscItems.Add(toAdd);
				break;
		}

		OnItemAdded?.Invoke();
	}

	public bool HasSmallKey()
	{
		return smallKeys.Count > 0;
	}

	public void UseSmallKey()
	{
		smallKeys.RemoveAt(smallKeys.Count - 1);
	}
}

public enum ItemType
{
	DOCUMENT,
	PHOTOGRAPH,
	SMALL_KEYS,
	KEY_ITEM,
	MISC_ITEM
}
