using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int maxSlots = 10; // ������ ���������
    public int MaxSlots => maxSlots; // ������ ��� ������

    public List<InventorySlot> slots = new List<InventorySlot>();
    public InventoryUI inventoryUI;

    private void Awake()
    {
        InitializeSlots();
    }

    private void InitializeSlots()
    {
        Debug.Log($"������������� ���������. ������� {maxSlots} ������.");

        for (int i = 0; i < maxSlots; i++)
        {
            slots.Add(new InventorySlot(null, 0)); // ������� ������ ����
        }
    }

    public void AddItem(Item item, int quantity)
    {
        int initialQuantity = quantity; // ��������� ����������� ���������� ��� �����������

        // 1. ������� ������� ������� � ��� ������������ ����
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

                    Debug.Log($"��������� {amountToAdd} ���� �������� {item.itemName} � ������������ ���� [{i}]");

                    if (quantity <= 0)
                    {
                        Debug.Log($"������� ��������� {initialQuantity} ��������� {item.itemName}.");
                        inventoryUI.UpdateUI(); // ��������� UI � �������
                        return;
                    }
                }
            }
        }

        // 2. ���������� � ������ ���� (������ ���� ��� ���� �������� ��� ����������)
        if (quantity > 0)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].IsEmpty())
                {
                    int amountToAdd = Mathf.Min(quantity, item.isStackable ? item.maxStack : 1);
                    slots[i].SetItem(item, amountToAdd);
                    quantity -= amountToAdd;

                    Debug.Log($"�������� ����� ������� {item.itemName} ({amountToAdd} ��.) � ���� [{i}]");

                    if (quantity <= 0)
                    {
                        break;  // ��� �������� ���������, �������
                    }
                }
            }
        }

        // 3. ���� �� ������� �������� ��� ��������
        if (quantity > 0)
        {
            Debug.Log($"��������� �����! �������� {quantity} ��������� {item.itemName}, ������� �� �����������.");
        }
        else
        {
            Debug.Log($"������� ��������� {initialQuantity} ��������� {item.itemName}.");
        }

        inventoryUI.UpdateUI(); // ��������� UI ���� ��� � �����
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
        Debug.Log("������� �� ������ � ���������!");
        inventoryUI.UpdateUI();
    }

    public void ExpandInventory(int amount)
    {
        if (amount <= 0) return; // ������ �� ������������ ��������

        maxSlots += amount;
        for (int i = 0; i < amount; i++)
        {
            slots.Add(new InventorySlot(null, 0)); // ������� ������ ����
        }

        Debug.Log("��������� ��������! ����� ���������� �����: " + maxSlots);
        inventoryUI.ExpandUI(amount);
    }

    public void ShrinkInventory(int amount)
    {
        if (amount <= 0) return;
        if (maxSlots - amount < 1) // ������������� �������� ���� ������
        {
            Debug.LogWarning("������ ��������� ��������� �� 0 ������!");
            return;
        }

        // ������� ��������� `amount` ������
        for (int i = 0; i < amount; i++)
        {
            if (slots.Count > 0)
            {
                slots.RemoveAt(slots.Count - 1);
            }
        }

        maxSlots -= amount;

        Debug.Log("��������� ��������! ����� ���������� ������: " + maxSlots);
        inventoryUI.ShrinkUI(amount);
    }
}