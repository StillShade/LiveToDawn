using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlotUI : InventorySlotUI
{
    public ItemType acceptedType;
    private PersonalInventoryUI personalInventoryUI;
    [SerializeField] private Sprite defaultIcon;

    private void Start()
    {
        personalInventoryUI = GetComponentInParent<PersonalInventoryUI>();
        if (personalInventoryUI == null)
        {
            Debug.LogError("❌ EquipmentSlotUI: Не найден PersonalInventoryUI в родителях!");
        }
    }

    public override void OnDrop(PointerEventData eventData)
    {
        // ✅ Используем защищённое свойство Slot вместо прямого доступа к полю
        if (draggedSlot == null || draggedSlot.Slot == null || draggedSlot.Slot.item == null)
            return;

        Item droppedItem = draggedSlot.Slot.item;

        if (droppedItem.itemType != acceptedType)
        {
            Debug.LogWarning($"❌ Этот слот принимает только {acceptedType}, а не {droppedItem.itemType}");
            return;
        }

        if (personalInventoryUI.inventory.TryEquip(droppedItem))
        {
            Debug.Log($"✅ {droppedItem.itemName} экипирован в слот {acceptedType}");

            // Удаляем предмет из старого инвентаря
            if (sourceInventoryUI != null)
            {
                sourceInventoryUI.inventory.RemoveItemFromSlot(tempIndex, draggedSlot.Slot.Quantity);
                draggedSlot.ClearSlot();
            }

            // Обновляем UI
            SetSlot(new InventorySlot(droppedItem, 1));
        }
        else
        {
            Debug.LogWarning("❌ Не удалось экипировать предмет.");
        }
    }

    public override void ClearSlot()
    {
        Slot = null;

        if (itemIcon != null)
        {
            itemIcon.sprite = defaultIcon;
            itemIcon.enabled = true;
            //itemIcon.color = new Color(1f, 1f, 1f, 0.5f); // полупрозрачная, если хочешь
        }

        if (quantityText != null)
        {
            quantityText.text = "";
        }
    }

    public override void SetSlot(InventorySlot newSlot)
    {
        base.SetSlot(newSlot);

        // Можно добавить отображение типа, если слот пуст (например, иконка шлема)
        if ((newSlot == null || newSlot.item == null) && itemIcon != null)
        {
            itemIcon.sprite = GetPlaceholderIconForType(acceptedType);
            itemIcon.color = new Color(1f, 1f, 1f, 0.3f); // Полупрозрачная иконка, показывающая тип
        }
    }

    private Sprite GetPlaceholderIconForType(ItemType type)
    {
        // Можно привязать через ScriptableObject или Resources.Load
        return null;
    }
}