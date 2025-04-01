using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public GameObject slotPrefab;
    public Transform slotParent;
    public ScrollRect scrollRect;

    private void OnEnable()
    {
        if (inventory == null) return;

        inventory.OnInventoryChanged += UpdateUI;
        inventory.OnSlotChanged += UpdateUI;
        inventory.OnInventoryExpanded += ExpandUI;
        inventory.OnInventoryShrunk += ShrinkUI;
    }

    private void OnDisable()
    {
        if (inventory == null) return;

        inventory.OnInventoryChanged -= UpdateUI;
        inventory.OnSlotChanged -= UpdateUI;
        inventory.OnInventoryExpanded -= ExpandUI;
        inventory.OnInventoryShrunk -= ShrinkUI;
    }

    public void ScrollToBottom()
    {
        Canvas.ForceUpdateCanvases(); // Обновляем UI перед прокруткой
        scrollRect.verticalNormalizedPosition = 0f; // Скроллим вниз
    }

    private void Start()
    {
        InitializeSlots();
    }

    public void InitializeSlots()
    {
        if (inventory == null)
        {
            Debug.LogError("Inventory не назначен в InventoryUI!");
            return;
        }

        Debug.Log("Инициализация слотов...");

        for (int i = 0; i < inventory.MaxSlots; i++)
        {
            int currentSlots = slotParent.childCount; // Количество UI-слотов
            int maxSlots = inventory.slots.Count; // Количество слотов в Inventory

            if (currentSlots >= maxSlots)
            {
                Debug.Log("UI-слоты уже соответствуют количеству слотов в Inventory. Останавливаем создание.");
                break; // Прерываем создание, если достигнуто максимальное количество
            }

            GameObject slotObject = Instantiate(slotPrefab, slotParent);
            InventorySlotUI slotUI = slotObject.GetComponent<InventorySlotUI>();
            slotUI.slotIndex = i; // Устанавливаем индекс
            slotUI.SetSlot(inventory.slots[i]); // Привязываем слот
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        Debug.Log($"Вызов UpdateUI. Количество слотов в инвентаре: {inventory.slots.Count}");

        for (int i = 0; i < slotParent.childCount; i++)
        {
            InventorySlotUI slotUI = slotParent.GetChild(i).GetComponent<InventorySlotUI>();

            //Debug.Log($"Обновление слота UI [{i}]: Проверяем, есть ли соответствующий слот в инвентаре...");

            if (i < inventory.slots.Count)
            {
                InventorySlot slot = inventory.slots[i];

                //Debug.Log($"Слот [{i}] найден. Проверяем IsEmpty()...");
                bool isEmpty = slot.IsEmpty();
                //Debug.Log($"Результат IsEmpty() для слота [{i}]: {isEmpty}");

                if (isEmpty)
                {
                    //Debug.Log($"Слот [{i}] пуст, вызываем ClearSlot().");
                    slotUI.ClearSlot();
                }
                else
                {
                    //Debug.Log($"Слот [{i}] содержит предмет {slot.item.itemName} ({slot.Quantity} шт.), вызываем SetSlot().");
                    slotUI.SetSlot(slot);
                }
            }
            else
            {
                //Debug.Log($"Слот [{i}] отсутствует в inventory.slots (index выходит за границы).");
            }
        }
       // DebugUISlots();
    }

    public void UpdateUI(int index)
    {
        if (index < 0 || index >= slotParent.childCount)
        {
            Debug.LogWarning($"UpdateUI: индекс {index} вне допустимых границ.");
            return;
        }

        InventorySlotUI slotUI = slotParent.GetChild(index).GetComponent<InventorySlotUI>();

        if (index < inventory.slots.Count)
        {
            InventorySlot slot = inventory.slots[index];

            if (slot.IsEmpty())
            {
                slotUI.ClearSlot();
            }
            else
            {
                slotUI.SetSlot(slot);
            }
        }
        else
        {
            // Если в inventory.slots нет слота с таким индексом, очищаем UI-ячейку
            slotUI.ClearSlot();
        }
    }

    private void DebugUISlots()
    {
        Debug.Log("=== Порядок UI-слотов (InventoryUI) ===");
        for (int i = 0; i < slotParent.childCount; i++)
        {
            InventorySlotUI slotUI = slotParent.GetChild(i).GetComponent<InventorySlotUI>();
            if (i < inventory.slots.Count)
            {
                InventorySlot slot = inventory.slots[i];
                string itemName = (slot != null && slot.item != null) ? slot.item.itemName : "ПУСТОЙ";
                Debug.Log($"UI-слот {i}: {itemName}");
            }
        }
    }

    public void ExpandUI(int newSlots)
    {
        Debug.Log("ExpandUI вызван с newSlots: " + newSlots);

        if (inventory == null)
        {
            Debug.LogError("Inventory не назначен в InventoryUI!");
            return;
        }

        for (int i = 0; i < newSlots; i++)
        {
            int currentSlots = slotParent.childCount; // Количество UI-слотов
            int maxSlots = inventory.slots.Count; // Количество слотов в Inventory

            if (currentSlots >= maxSlots)
            {
                Debug.Log("Достигнуто максимальное количество UI-слотов. Останавливаем создание.");
                break; // Прерываем цикл, если UI-слотов уже достаточно
            }

            GameObject slotObject = Instantiate(slotPrefab, slotParent);
            InventorySlotUI slotUI = slotObject.GetComponent<InventorySlotUI>();
            slotUI.slotIndex = i; // Устанавливаем индекс
            slotUI.SetSlot(inventory.slots[i]); // Привязываем слот
        }

        UpdateUI();
    }

    public void ShrinkUI(int amount)
    {
        Debug.Log("ShrinkUI вызван с amount: " + amount);

        int removedSlots = 0;

        for (int i = slotParent.childCount - 1; i >= 0 && removedSlots < amount; i--)
        {
            Destroy(slotParent.GetChild(i).gameObject);
            removedSlots++;
        }

        Debug.Log($"Удалено {removedSlots} UI-слотов.");
        UpdateUI();
    }
}