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

	public void RemoveItem(Item item, int quantity)
	{
		for (int i = slots.Count - 1; i >= 0; i--) // Проходится с конца списка
		{
			if (slots[i].item == item)
			{
				if (slots[i].quantity > quantity)
				{
					slots[i].quantity -= quantity;
					return;
				}
				else
				{
					quantity -= slots[i].quantity;
					slots.RemoveAt(i);
					if (quantity <= 0) return;
				}
			}
		}
		Debug.Log("Предмет не найден в инвентаре!");
	}
}