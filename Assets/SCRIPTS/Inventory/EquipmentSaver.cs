using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

namespace Inventory
{
    public static class EquipmentSaver
    {
        private static string SaveFilePath => Path.Combine(Application.persistentDataPath, "equipment_data.json");

        public static void Save(List<EquipmentSlot> equipmentSlots)
        {
            EquipmentSaveData data = new EquipmentSaveData();

            foreach (var slot in equipmentSlots)
            {
                if (slot.EquippedItem != null)
                {
                    data.equippedItems.Add(new EquippedItemData
                    {
                        itemName = slot.EquippedItem.itemName,
                        itemType = slot.acceptedType
                    });
                }
            }

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(SaveFilePath, json, Encoding.UTF8);

            Debug.Log($"[EquipmentSaver] Экипировка сохранена в: {SaveFilePath}");
        }

        public static List<EquippedItemData> Load()
        {
            if (!File.Exists(SaveFilePath))
            {
                Debug.Log("[EquipmentSaver] Файл не найден.");
                return null;
            }

            string json = File.ReadAllText(SaveFilePath, Encoding.UTF8);
            EquipmentSaveData data = JsonConvert.DeserializeObject<EquipmentSaveData>(json);

            Debug.Log("[EquipmentSaver] Экипировка загружена из файла.");
            return data?.equippedItems;
        }
    }
}