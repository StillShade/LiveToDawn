using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlotUI : InventorySlotUI
{
    public ItemType acceptedType;
    private PersonalInventoryUI personalInventoryUI;
    public override bool IsEquipmentSlot => true;
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
        Debug.Log($"Перемещение предмета {draggedSlot.Slot.item.itemName} в новый слот в Экипировку");

        SwapItems(draggedSlot, sourceInventoryUI);
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
            itemIcon.color = new Color(1f, 1f, 1f, 0.5f); // Полупрозрачная иконка, показывающая тип
        }
    }

    private Sprite GetPlaceholderIconForType(ItemType type)
    {
        // Можно привязать через ScriptableObject или Resources.Load
        return null;
    }

    public virtual void SwapItems(InventorySlotUI otherSlot, IInventoryUI otherInventoryUI)
    {
        Item droppedItem = draggedSlot.Slot.item;

        if (droppedItem.itemType != acceptedType)
        {
            Debug.LogWarning($"❌ Этот слот принимает только {acceptedType}, а не {droppedItem.itemType}");
            return;
        }

        if (personalInventoryUI.inventory.TryEquip(droppedItem))
        {
            Debug.Log($"✅ {droppedItem.itemName} экипирован в слот {acceptedType}");
            int thisIndex = transform.GetSiblingIndex();
            Debug.Log($"thisIndex {thisIndex}");
            if (personalInventoryUI.inventory.equipmentSlots[thisIndex].slot != null && personalInventoryUI.inventory.equipmentSlots[thisIndex].slot.item != null) {
                if (sourceInventoryUI != null)
                {
                    Debug.Log("я ЗДЕСЬ добавляем в инвентарь из экипировки");
                    InventorySlot temp = new InventorySlot(droppedItem, draggedSlot.Slot.Quantity);
                    InventorySlot tempUI = personalInventoryUI.inventory.equipmentSlots[thisIndex].slot;
                    sourceInventoryUI.inventory.RemoveItemFromSlot(tempIndex, draggedSlot.Slot.Quantity);
                    Debug.Log($"в экипировке были {personalInventoryUI.inventory.equipmentSlots[thisIndex].slot.item}");
                    sourceInventoryUI.inventory.AddItemToSlot(tempIndex, personalInventoryUI.inventory.equipmentSlots[thisIndex].slot.item, personalInventoryUI.inventory.equipmentSlots[thisIndex].slot.Quantity);
                    otherSlot.SetSlot(tempUI);
                    personalInventoryUI.inventory.Equip(thisIndex, droppedItem);
                    //SetSlot(temp);
                }
                
            } 
            else
            {
                // Удаляем предмет из старого инвентаря
                if (sourceInventoryUI != null)
                {
                    Debug.Log("Экипировка была пустая, просто удаляем из инвентаря");
                    sourceInventoryUI.inventory.RemoveItemFromSlot(tempIndex, draggedSlot.Slot.Quantity);
                    draggedSlot.ClearSlot();
                    // Обновляем UI
                    personalInventoryUI.inventory.Equip(thisIndex, droppedItem);
                    //SetSlot(new InventorySlot(droppedItem, draggedSlot.Slot.Quantity));
                }
            }
        }
        else
        {
            Debug.LogWarning("❌ Не удалось экипировать предмет.");
        }
    }

}