namespace Inventory
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Newtonsoft.Json;
    using UnityEngine;

    public static class InventorySaver
    {
        private static string SaveFilePath => Path.Combine(Application.persistentDataPath, "inventory_data.json");

        public static void Save(List<InventorySlot> slots)
        {
            InventorySaveData data = new InventorySaveData();

            foreach (var slot in slots)
            {
                if (slot.IsEmpty())
                {
                    data.slots.Add(new InventorySlotSaveData
                    {
                        itemName = null,
                        quantity = 0
                    });
                }
                else
                {
                    data.slots.Add(new InventorySlotSaveData
                    {
                        itemName = slot.item.itemName, 
                        quantity = slot.Quantity
                    });
                }
            }

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(SaveFilePath, json, Encoding.UTF8);

            Debug.Log($"[InventorySaver] Инвентарь сохранён в: {SaveFilePath}");
        }

        public static List<InventorySlotSaveData> Load()
        {
            if (!File.Exists(SaveFilePath))
            {
                Debug.Log("[InventorySaver] Файл не найден.");
                return null;
            }

            string json = File.ReadAllText(SaveFilePath, Encoding.UTF8);
            InventorySaveData data = JsonConvert.DeserializeObject<InventorySaveData>(json);

            Debug.Log("[InventorySaver] Инвентарь загружен из файла.");
            return data?.slots;
        }
    }
}