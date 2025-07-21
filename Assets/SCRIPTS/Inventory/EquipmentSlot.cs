using UnityEngine;

[System.Serializable]
public class EquipmentSlot
{
    public ItemType acceptedType;
    public InventorySlot slot = new InventorySlot();

    public bool CanAccept(Item item)
    {
        Debug.Log($"item.itemType: {item.itemType} ({(int)item.itemType}), acceptedType: {acceptedType} ({(int)acceptedType})");
        return item != null && item.itemType == acceptedType;
    }

    public void SetItem(Item item)
    {
        if (CanAccept(item))
            slot.SetItem(item, 1);
    }

    public void Clear()
    {
        slot = new InventorySlot();
    }

    public Item EquippedItem => slot.item;
}