using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public GameObject slotPrefab;
    public Transform slotParent;

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

            Instantiate(slotPrefab, slotParent);
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

            Instantiate(slotPrefab, slotParent);
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