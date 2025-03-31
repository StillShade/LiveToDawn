using System.Collections.Generic;
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

    public void AddItemToSlot(int slotIndex, Item item, int quantity)
    {
        Debug.Log($"Пытаюсь добавить item {item} в количестве {quantity} в слот {slotIndex}");
        // Проверка валидности
        if (item == null)
        {
            Debug.LogWarning("Попытка добавить null-предмет.");
            return;
        }

        if (quantity <= 0)
        {
            Debug.LogWarning("Количество должно быть положительным.");
            return;
        }

        if (slotIndex < 0 || slotIndex >= slots.Count)
        {
            Debug.LogWarning($"Неверный индекс слота: {slotIndex}");
            return;
        }

        var slot = slots[slotIndex];

        // Если слот пуст — просто установить предмет
        if (slot.IsEmpty())
        {
            int amountToAdd = item.isStackable ? Mathf.Min(quantity, item.maxStack) : 1;
            slot.SetItem(item, amountToAdd);
            quantity -= amountToAdd;

            Debug.Log($"Добавлен новый предмет {item.itemName} ({amountToAdd} шт.) в пустой слот [{slotIndex}].");

            if (quantity > 0)
            {
                Debug.Log($"Осталось {quantity} шт. предмета {item.itemName}, не помещающихся в слот [{slotIndex}].");
            }

            inventoryUI.UpdateUI();
            return;
        } else
        {
            Debug.Log($"слот не из empty");
        }

        // Если слот занят тем же предметом — попытаться добавить в стек
        if (slot.item.Equals(item) && item.isStackable)
        {
            int spaceLeft = item.maxStack - slot.Quantity;

            if (spaceLeft <= 0)
            {
                Debug.Log($"Слот [{slotIndex}] с предметом {item.itemName} уже полон.");
                return;
            }

            int amountToAdd = Mathf.Min(quantity, spaceLeft);
            slot.SetQuantity(slot.Quantity + amountToAdd);
            quantity -= amountToAdd;

            Debug.Log($"Добавлено {amountToAdd} шт. предмета {item.itemName} в слот [{slotIndex}].");

            if (quantity > 0)
            {
                Debug.Log($"Осталось {quantity} шт. предмета {item.itemName}, не помещающихся в слот [{slotIndex}].");
            }

            inventoryUI.UpdateUI();
            return;
        }

        // Если в слоте другой предмет или предмет не стакается
        Debug.LogWarning($"Слот [{slotIndex}] уже занят другим предметом или предмет не может быть добавлен.");
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

    //ЭТОТ МЕТОД НУЖНО ТЕСТИРОВАТЬ

    public void RemoveItemFromSlot(int slotIndex, int quantity)
    {
        if (slotIndex < 0 || slotIndex >= slots.Count)
        {
            Debug.LogWarning("Недопустимый индекс слота!");
            return;
        }

        InventorySlot slot = slots[slotIndex];

        if (slot.item == null)
        {
            Debug.LogWarning("Слот пуст!");
            return;
        }

        if (slot.Quantity > quantity)
        {
            slot.SetQuantity(slot.Quantity - quantity);
        }
        else
        {
            // Удаляем весь предмет, если quantity >= slot.Quantity
            slots[slotIndex] = new InventorySlot();
        }

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