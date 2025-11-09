using System;
using System.Collections.Generic;

namespace Inventory
{
    [Serializable]
    public class EquipmentSaveData
    {
        public List<EquippedItemData> equippedItems = new List<EquippedItemData>();
    }

    [Serializable]
    public class EquippedItemData
    {
        public string itemName;
        public ItemType itemType;
    }
}