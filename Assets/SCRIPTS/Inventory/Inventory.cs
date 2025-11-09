using System.Collections.Generic;
using Character;
using UnityEngine;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField]
        private int maxSlots = 0; // Теперь приватное
        public int MaxSlots => maxSlots; // Геттер для чтения
        public List<InventorySlot> slots = new List<InventorySlot>();
        private CharacterStats stats;
        
        [SerializeField] protected ItemDatabase itemDatabase;
        
        public event System.Action OnInventoryChanged;
        public event System.Action<int> OnSlotChanged;
        public event System.Action<int> OnInventoryExpanded;
        public event System.Action<int> OnInventoryShrunk;

        //это для того, чтобы в наследнике можно было вызвать
        protected void RaiseInventoryChanged()
        {
            OnInventoryChanged?.Invoke();
        }
        
        private void Awake()
        {
            // Найдём объект Player (можно по тегу или ссылке)
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                stats = player.GetComponent<CharacterStats>();
                if (stats != null)
                {
                    maxSlots = stats.InventorySlotsCount;
                    stats.OnInventorySlotsChanged += HandleInventorySlotChange;
                }
            }
            OnInventoryChanged += SaveInventory;
            OnInventoryExpanded += _ => SaveInventory();
            OnInventoryShrunk += _ => SaveInventory();
            if (itemDatabase == null)
            {
                Debug.LogError("❌ itemDatabase не назначен в инспекторе (на родителе Inventory)!");
                return;
            }

            itemDatabase.Initialize();
            
            LoadInventory();
        }
        
        public void SaveInventory()
        {
            InventorySaver.Save(slots);
        }

        public void LoadInventory()
        {
            var loadedSlots = InventorySaver.Load();
            if (loadedSlots == null)
            {
                Debug.Log("Нет сохранённого инвентаря.");
                InitializeSlots();
                return;
            }

            //slots.Clear();

            foreach (var slotData in loadedSlots)
            {
                if (!string.IsNullOrEmpty(slotData.itemName))
                {
                    Debug.Log($"ЗАГРУЖАЮ ОБЪЕКТ {slotData.itemName}.");
                    Item item = itemDatabase.GetItemByName(slotData.itemName); 
                    slots.Add(new InventorySlot(item, slotData.quantity));
                }
                else
                {
                    Debug.Log("ИМЯ ОБЪЕКТА ПУСТОЕ загружаю пустой объект");
                    slots.Add(new InventorySlot(null, 0));
                }
            }

            Debug.Log("Инвентарь успешно загружен.");
            OnInventoryChanged?.Invoke();
        }

        private void HandleInventorySlotChange(int delta)
        {
            if (delta > 0)
            {
                ExpandInventory(delta);
            }
            else if (delta < 0)
            {
                ShrinkInventory(-delta); // передаём положительное число
            }
        }

        private void InitializeSlots()
        {
            Debug.Log($"Инициализация инвентаря. Создаем {maxSlots} слотов.");

            for (int i = 0; i < maxSlots; i++)
            {
                slots.Add(new InventorySlot(null, 0)); // Создаем пустой слот
            }
        }

        public bool TryAddItem(Item item, int quantity)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                var slot = slots[i];
                if (slot.IsEmpty())
                    return true;

                if (slot.item.Equals(item) && item.isStackable && slot.Quantity < item.maxStack)
                    return true;
            }

            return false;
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

            // Обновляем UI один раз в конце - раньше было: inventoryUI.UpdateUI(); переходим на делеагаты и события
            OnInventoryChanged?.Invoke();
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

            //inventoryUI.UpdateUI(slotIndex); теперь переходим на вызов событий
            OnSlotChanged?.Invoke(slotIndex);
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

            //inventoryUI.UpdateUI(slotIndex); переходим на делеагаты и события
            OnSlotChanged?.Invoke(slotIndex);
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
                        OnInventoryChanged?.Invoke();
                        return;
                    }
                    else
                    {
                        quantity -= slots[i].Quantity;

                        // ✅ Вместо удаления — очищаем слот
                        slots[i].Clear();

                        if (quantity <= 0)
                        {
                            OnInventoryChanged?.Invoke();
                            return;
                        }
                    }
                }
            }

            Debug.Log("❗ Предмет не найден в инвентаре!");
        }



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

            //inventoryUI.UpdateUI(slotIndex);
            OnSlotChanged?.Invoke(slotIndex);
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
            //inventoryUI.ExpandUI(amount);
            OnInventoryExpanded?.Invoke(amount);
        }

        //уменьшаем количество слотов если возможно
        public void ShrinkInventory(int amount)
        {
            if (amount <= 0) return;
            if (maxSlots - amount < 1)
            {
                Debug.LogWarning("Нельзя уменьшить инвентарь до 0 слотов!");
                return;
            }

            int emptySlots = CountEmptySlots();
            if (emptySlots < amount)
            {
                int needed = amount - emptySlots;
                Debug.LogWarning($"Недостаточно пустых слотов ({emptySlots})! Освободите еще {needed}.");
                return;
            }

            int removedSlots = RemoveEmptySlots(amount);
            maxSlots -= removedSlots;

            Debug.Log($"Инвентарь уменьшен на {removedSlots} слотов. Новое количество: {maxSlots}");
            OnInventoryShrunk?.Invoke(removedSlots);
        }
        
        private int RemoveEmptySlots(int amount)
        {
            int removed = 0;
            for (int i = slots.Count - 1; i >= 0 && removed < amount; i--)
            {
                if (slots[i].IsEmpty())
                {
                    slots.RemoveAt(i);
                    removed++;
                }
            }
            return removed;
        }

        public virtual bool TryEquip(Item item)
        {
            return false;
        }
        
        public int CountEmptySlots()
        {
            int count = 0;
            foreach (var slot in slots)
            {
                if (slot.IsEmpty()) count++;
            }
            Debug.Log($"Пустых слотов {count}");
            return count;
        }
        
        private void OnDestroy()
        {
            OnInventoryChanged -= SaveInventory;
        }
    }
}
