using System.Collections.Generic;
using UnityEngine;


public class PersonalInventory : Inventory
{
    [SerializeField]
    private List<EquipmentSlot> equipmentSlots = new(); // Устанавливаются вручную в инспекторе

    [SerializeField] private CharacterStats characterStats;

    private void Awake()
    {
        characterStats = GetComponent<CharacterStats>();

        if (characterStats == null)
        {
            Debug.LogError("❌ CharacterStats не найден на объекте с PersonalInventory!");
        }

    }

    public bool TryEquip(Item item)
    {
        foreach (var equipSlot in equipmentSlots)
        {
            if (equipSlot.CanAccept(item))
            {
                equipSlot.SetItem(item);
                ApplyStats(item.stats);
                RaiseInventoryChanged();  // Обновить UI
                return true;
            }
        }

        Debug.LogWarning($"Нет подходящего слота для предмета {item.itemName}");
        return false;
    }

    public void Unequip(ItemType type)
    {
        foreach (var equipSlot in equipmentSlots)
        {
            if (equipSlot.acceptedType == type && equipSlot.EquippedItem != null)
            {
                RemoveStats(equipSlot.EquippedItem.stats);
                equipSlot.Clear();
                RaiseInventoryChanged();
                return;
            }
        }
    }

    public EquipmentSlot GetEquipmentSlot(ItemType type)
    {
        foreach (var equipSlot in equipmentSlots)
        {
            if (equipSlot.acceptedType == type)
                return equipSlot;
        }

        return null;
    }

    private void ApplyStats(ItemStats stats)
    {
        characterStats.Add(stats);
    }

    private void RemoveStats(ItemStats stats)
    {
        characterStats.Remove(stats);
    }

    public IReadOnlyList<EquipmentSlot> GetEquipmentSlots() => equipmentSlots;
}