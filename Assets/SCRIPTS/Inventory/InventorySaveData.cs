using System;
using System.Collections.Generic;

namespace Inventory
{
    [Serializable]
    public class InventorySaveData
    {
        public List<InventorySlotSaveData> slots = new List<InventorySlotSaveData>();
    }

    [Serializable]
    public class InventorySlotSaveData
    {
        public string itemName;
        public int quantity;
    }
}