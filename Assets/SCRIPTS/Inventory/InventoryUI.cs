using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryUI : MonoBehaviour, IInventoryUI
{
    public Inventory inventory;
    // ���������� ����������
    Inventory IInventoryUI.inventory => inventory;
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
        Canvas.ForceUpdateCanvases(); // ��������� UI ����� ����������
        scrollRect.verticalNormalizedPosition = 0f; // �������� ����
    }

    private void Start()
    {
        InitializeSlots();
    }

    public void InitializeSlots()
    {
        if (inventory == null)
        {
            Debug.LogError("Inventory �� �������� � InventoryUI!");
            return;
        }

        Debug.Log("������������� ������...");

        for (int i = 0; i < inventory.MaxSlots; i++)
        {
            int currentSlots = slotParent.childCount; // ���������� UI-������
            int maxSlots = inventory.slots.Count; // ���������� ������ � Inventory

            if (currentSlots >= maxSlots)
            {
                Debug.Log("UI-����� ��� ������������� ���������� ������ � Inventory. ������������� ��������.");
                break; // ��������� ��������, ���� ���������� ������������ ����������
            }

            GameObject slotObject = Instantiate(slotPrefab, slotParent);
            InventorySlotUI slotUI = slotObject.GetComponent<InventorySlotUI>();
            slotUI.slotIndex = i; // ������������� ������
            slotUI.SetSlot(inventory.slots[i]); // ����������� ����
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        Debug.Log($"����� UpdateUI. ���������� ������ � ���������: {inventory.slots.Count}");

        for (int i = 0; i < slotParent.childCount; i++)
        {
            InventorySlotUI slotUI = slotParent.GetChild(i).GetComponent<InventorySlotUI>();

            //Debug.Log($"���������� ����� UI [{i}]: ���������, ���� �� ��������������� ���� � ���������...");

            if (i < inventory.slots.Count)
            {
                InventorySlot slot = inventory.slots[i];

                //Debug.Log($"���� [{i}] ������. ��������� IsEmpty()...");
                bool isEmpty = slot.IsEmpty();
                //Debug.Log($"��������� IsEmpty() ��� ����� [{i}]: {isEmpty}");

                if (isEmpty)
                {
                    //Debug.Log($"���� [{i}] ����, �������� ClearSlot().");
                    slotUI.ClearSlot();
                }
                else
                {
                    //Debug.Log($"���� [{i}] �������� ������� {slot.item.itemName} ({slot.Quantity} ��.), �������� SetSlot().");
                    slotUI.SetSlot(slot);
                }
            }
            else
            {
                //Debug.Log($"���� [{i}] ����������� � inventory.slots (index ������� �� �������).");
            }
        }
       // DebugUISlots();
    }

    public void UpdateUI(int index)
    {
        if (index < 0 || index >= slotParent.childCount)
        {
            Debug.LogWarning($"UpdateUI: ������ {index} ��� ���������� ������.");
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
            // ���� � inventory.slots ��� ����� � ����� ��������, ������� UI-������
            slotUI.ClearSlot();
        }
    }

    private void DebugUISlots()
    {
        Debug.Log("=== ������� UI-������ (InventoryUI) ===");
        for (int i = 0; i < slotParent.childCount; i++)
        {
            InventorySlotUI slotUI = slotParent.GetChild(i).GetComponent<InventorySlotUI>();
            if (i < inventory.slots.Count)
            {
                InventorySlot slot = inventory.slots[i];
                string itemName = (slot != null && slot.item != null) ? slot.item.itemName : "������";
                Debug.Log($"UI-���� {i}: {itemName}");
            }
        }
    }

    public void ExpandUI(int newSlots)
    {
        Debug.Log("ExpandUI ������ � newSlots: " + newSlots);

        if (inventory == null)
        {
            Debug.LogError("Inventory �� �������� � InventoryUI!");
            return;
        }

        for (int i = 0; i < newSlots; i++)
        {
            int currentSlots = slotParent.childCount; // ���������� UI-������
            int maxSlots = inventory.slots.Count; // ���������� ������ � Inventory

            if (currentSlots >= maxSlots)
            {
                Debug.Log("���������� ������������ ���������� UI-������. ������������� ��������.");
                break; // ��������� ����, ���� UI-������ ��� ����������
            }

            GameObject slotObject = Instantiate(slotPrefab, slotParent);
            InventorySlotUI slotUI = slotObject.GetComponent<InventorySlotUI>();
            slotUI.slotIndex = i; // ������������� ������
            slotUI.SetSlot(inventory.slots[i]); // ����������� ����
        }

        UpdateUI();
    }

    public void ShrinkUI(int amount)
    {
        Debug.Log("ShrinkUI ������ � amount: " + amount);

        int removedSlots = 0;

        for (int i = slotParent.childCount - 1; i >= 0 && removedSlots < amount; i--)
        {
            Destroy(slotParent.GetChild(i).gameObject);
            removedSlots++;
        }

        Debug.Log($"������� {removedSlots} UI-������.");
        UpdateUI();
    }
}
}
