using UnityEngine;
using UnityEngine.UI;
using TMPro; // Подключаем TextMeshPro

public class InventorySlotUI : MonoBehaviour
{
    public Image itemIcon;  // Иконка предмета
    public TMP_Text quantityText; // Количество предметов (TMP)

    private InventorySlot slot; // Ссылка на слот инвентаря

    public void SetSlot(InventorySlot newSlot)
    {
        slot = newSlot;
        itemIcon.sprite = slot.item.icon;
        itemIcon.enabled = true; // Показываем иконку
        quantityText.text = slot.Quantity > 1 ? slot.Quantity.ToString() : ""; // Показываем количество если больше 1
    }

    public void ClearSlot()
    {
        slot = null;
        itemIcon.sprite = null;
        itemIcon.enabled = false; // Прячем иконку
        quantityText.text = "";
    }
}