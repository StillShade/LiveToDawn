using UnityEngine;
using UnityEngine.UI;
using TMPro; // ���������� TextMeshPro

public class InventorySlotUI : MonoBehaviour
{
    public Image itemIcon;  // ������ ��������
    public TMP_Text quantityText; // ���������� ��������� (TMP)

    private InventorySlot slot; // ������ �� ���� ���������

    public void SetSlot(InventorySlot newSlot)
    {
        slot = newSlot;
        itemIcon.sprite = slot.item.icon;
        itemIcon.enabled = true; // ���������� ������
        quantityText.text = slot.Quantity > 1 ? slot.Quantity.ToString() : ""; // ���������� ���������� ���� ������ 1
    }

    public void ClearSlot()
    {
        slot = null;
        itemIcon.sprite = null;
        itemIcon.enabled = false; // ������ ������
        quantityText.text = "";
    }
}