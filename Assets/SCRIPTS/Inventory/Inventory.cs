using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public List<InventorySlot> slots = new List<InventorySlot>();
	public int maxSlots = 10; // Начальное количество слотов

	public void AddItem(Item item, int quantity)
	{
		if (item.isStackable)
		{
			// Проверяем, есть ли уже этот предмет в инвентаре
			foreach (var slot in slots)
			{
				if (slot.item == item && slot.quantity < item.maxStack)
				{
					int spaceLeft = item.maxStack - slot.quantity;
					int amountToAdd = Mathf.Min(quantity, spaceLeft);
					slot.AddAmount(amountToAdd);
					quantity -= amountToAdd;

					if (quantity <= 0) return;
				}
			}
		}

		// Добавляем новый предмет в свободный слот
		while (quantity > 0 && slots.Count < maxSlots)
		{
			int amountToAdd = Mathf.Min(quantity, item.isStackable ? item.maxStack : 1);
			slots.Add(new InventorySlot(item, amountToAdd));
			quantity -= amountToAdd;
		}

		if (quantity > 0)
		{
			Debug.Log("Инвентарь полон!");
		}
	}

	public void ExpandInventory(int amount)
	{
		maxSlots += amount;
		Debug.Log("Инвентарь расширен! Новые слоты: " + maxSlots);
	}
}