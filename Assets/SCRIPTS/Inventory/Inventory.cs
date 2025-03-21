﻿using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int maxSlots = 10; // Теперь приватное
    public int MaxSlots => maxSlots; // Геттер для чтения

    public List<InventorySlot> slots = new List<InventorySlot>();
    public InventoryUI inventoryUI;

    private void Awake()
    {
        InitializeSlots();
    }

    private void InitializeSlots()
    {
        Debug.Log($"Инициализация инвентаря. Создаем {maxSlots} слотов.");

        for (int i = 0; i < maxSlots; i++)
        {
            slots.Add(new InventorySlot(null, 0)); // Создаем пустой слот
        }
    }

    public void AddItem(Item item, int quantity)
    {
        int initialQuantity = quantity; // Сохраняем изначальное количество для логирования

        // 1. Попытка сложить предмет в уже существующий слот
        for (int i = 0; i < slots.Count; i++)
        {
            if (!slots[i].IsEmpty() && slots[i].item.Equals(item) && item.isStackable)
            {
                int spaceLeft = item.maxStack - slots[i].Quantity;
                if (spaceLeft > 0)
                {
                    int amountToAdd = Mathf.Min(quantity, spaceLeft);
                    slots[i].SetQuantity(slots[i].Quantity + amountToAdd);
                    quantity -= amountToAdd;

                    Debug.Log($"Добавлено {amountToAdd} штук предмета {item.itemName} в существующий слот [{i}]");

                    if (quantity <= 0)
                    {
                        Debug.Log($"Успешно добавлено {initialQuantity} предметов {item.itemName}.");
                        //inventoryUI.UpdateUI(); // Обновляем UI и выходим
                        return;
                    }
                }
            }
        }

        // 2. Добавление в пустой слот (только если еще есть предметы для добавления)
        if (quantity > 0)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].IsEmpty())
                {
                    int amountToAdd = Mathf.Min(quantity, item.isStackable ? item.maxStack : 1);
                    slots[i].SetItem(item, amountToAdd);
                    quantity -= amountToAdd;

                    Debug.Log($"Добавлен новый предмет {item.itemName} ({amountToAdd} шт.) в слот [{i}]");

                    if (quantity <= 0)
                    {
                        break;  // Все предметы добавлены, выходим
                    }
                }
            }
        }

        // 3. Если не удалось добавить все предметы
        if (quantity > 0)
        {
            Debug.Log($"Инвентарь полон! Осталось {quantity} предметов {item.itemName}, которые не поместились.");
        }
        else
        {
            Debug.Log($"Успешно добавлено {initialQuantity} предметов {item.itemName}.");
        }

        inventoryUI.UpdateUI(); // Обновляем UI один раз в конце
    }

    private void DebugInventorySlots()
    {
        Debug.Log("=== Порядок слотов в Inventory ===");
        for (int i = 0; i < slots.Count; i++)
        {
            string itemName = slots[i].IsEmpty() ? "ПУСТОЙ" : slots[i].item.itemName;
            Debug.Log($"Слот {i}: {itemName} ({slots[i].Quantity})");
        }
    }

    public void RemoveItem(Item item, int quantity)
    {
        for (int i = slots.Count - 1; i >= 0; i--)
        {
            if (slots[i].item == item)
            {
                if (slots[i].Quantity > quantity)
                {
                    slots[i].SetQuantity(slots[i].Quantity - quantity);
                    inventoryUI.UpdateUI();
                    return;
                }
                else
                {
                    quantity -= slots[i].Quantity;
                    slots[i] = new InventorySlot();
                    if (quantity <= 0)
                    {
                        inventoryUI.UpdateUI();
                        return;
                    }
                }
            }
        }
        Debug.Log("Предмет не найден в инвентаре!");
        inventoryUI.UpdateUI();
    }

    public void ExpandInventory(int amount)
    {
        if (amount <= 0) return; // Защита от некорректных значений

        maxSlots += amount;
        for (int i = 0; i < amount; i++)
        {
            slots.Add(new InventorySlot(null, 0)); // Создаем пустой слот
        }

        Debug.Log("Инвентарь расширен! Новое количество слоты: " + maxSlots);
        DebugInventorySlots();
        inventoryUI.ExpandUI(amount);
    }

    //уменьшаем количество слотов если возможно
    public void ShrinkInventory(int amount)
    {
        if (amount <= 0) return;
        if (maxSlots - amount < 1) // Предотвращаем удаление всех слотов
        {
            Debug.LogWarning("Нельзя уменьшить инвентарь до 0 слотов!");
            return;
        }

        // 1️ Подсчитываем пустые слоты
        int emptySlots = 0;
        foreach (var slot in slots)
        {
            if (slot.IsEmpty()) emptySlots++;
        }

        // 2️ Проверяем, хватает ли пустых слотов для удаления
        if (emptySlots < amount)
        {
            int needed = amount - emptySlots;
            Debug.LogWarning($"Всего слотов {maxSlots}. Недостаточно пустых слотов ({emptySlots})! Освободите еще {needed} слотов, чтобы уменьшить инвентарь на {amount} слотов.");
            return;
        }

        // 3️ Удаляем только пустые слоты (не обязательно подряд)
        int removedSlots = 0;
        for (int i = slots.Count - 1; i >= 0 && removedSlots < amount; i--)
        {
            if (slots[i].IsEmpty())
            {
                slots.RemoveAt(i);
                removedSlots++;
            }
        }

        maxSlots -= removedSlots;

        Debug.Log($"Инвентарь уменьшен на {removedSlots} слотов. Новое количество слотов: {maxSlots}");
        inventoryUI.ShrinkUI(removedSlots);
    }
}