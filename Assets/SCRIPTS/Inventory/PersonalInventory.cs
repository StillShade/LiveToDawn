using System.Collections.Generic;
using Character;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class PersonalInventory : Inventory
    {
        [SerializeField]
        public List<EquipmentSlot> equipmentSlots = new(); // Устанавливаются вручную в инспекторе

        [SerializeField] private CharacterStats characterStats;

        [SerializeField] private Transform playerVisualRoot; // Ссылка на объект Player (где socks, boots и т.д.)
        
        // Сопоставление ItemType и имени объекта - это для одевания Player-а
        private string GetChildNameByItemType(ItemType type)
        {
            //это то что в объекте Player (часов и трусов пока нет, gps и транспорта вообще не будет)
            return type switch
            {
                ItemType.Socks => "socks",
                ItemType.Boots => "boots",
                ItemType.Pants => "pants",
                ItemType.Gloves => "gloves",
                ItemType.Mask => "faceMask",
                ItemType.Helmet => "headdress",
                ItemType.Armor => "armor",
                ItemType.Unloading_vest => "unloadingVest",
                ItemType.Backpack => "backpack",
                ItemType.Glasses => "glasses",
                ItemType.TShirt => "light_clothing",
                ItemType.Weapon => "weapon",
                //ItemType.Clock => "",
                //ItemType.Underwear => "",
                // ... и так далее ...
                _ => null
            };
        }
        
        public void SaveEquipment()
        {
            EquipmentSaver.Save(equipmentSlots);
        }

        public void LoadEquipment()
        {
            var loadedData = EquipmentSaver.Load();
            if (loadedData == null) return;

            foreach (var data in loadedData)
            {
                Item item = itemDatabase.GetItemByName(data.itemName); //проблема в доступе к itemDatabase
                if (item != null)
                {
                    var slot = GetEquipmentSlot(data.itemType);
                    if (slot != null)
                    {
                        slot.SetItem(item);
                        ApplyStats(item);
                        UpdatePlayerVisual(item);
                    }
                }
            }

            RaiseInventoryChanged();
            Debug.Log("Экипировка загружена.");
        }
        
        private void Awake()
        {
            characterStats = GetComponentInParent<CharacterStats>();

            if (characterStats == null)
            {
                Debug.LogError("❌ CharacterStats не найден на родительском объекте!");
            }
            LoadEquipment();
        }

        private Sprite LoadSpriteByName(string spriteName)
        {
            // Путь относительно папки Resources
            string path = $"Men/{spriteName}";
            Sprite sprite = Resources.Load<Sprite>(path);
            if (sprite == null)
            {
                Debug.LogWarning($"Не найден спрайт по пути: {path}");
            }
            return sprite;
        }

        // Вызови этот метод при экипировке - для одевания
        private void UpdatePlayerVisual(Item item)
        {
            if (item == null) return;

            string childName = GetChildNameByItemType(item.itemType);
            if (string.IsNullOrEmpty(childName)) return;

            // Получаем имя спрайта из item.icon
            string spriteName = item.icon != null ? item.icon.name : null;
            if (string.IsNullOrEmpty(spriteName)) return;
            
            // Если имя заканчивается на "_0", обрезаем это окончание
            if (spriteName.EndsWith("_0"))
            {
                spriteName = spriteName.Substring(0, spriteName.Length - 2);
            }

            // Загружаем спрайт из папки Resources/Men/
            Sprite sprite = LoadSpriteByName(spriteName);

            // Первый уровень
            Transform firstLevel = playerVisualRoot.Find(childName);
            if (firstLevel == null)
            {
                Debug.LogWarning($"Не найден объект визуализации для {childName}");
                return;
            }

            firstLevel.gameObject.SetActive(true);

            var image1 = firstLevel.GetComponent<UnityEngine.UI.Image>();
            if (image1 != null)
            {
                image1.sprite = sprite;
                image1.enabled = (sprite != null);
            }

            // Второй уровень
            Transform secondLevel = firstLevel.Find(childName);
            if (secondLevel != null)
            {
                secondLevel.gameObject.SetActive(true);

                var image2 = secondLevel.GetComponent<UnityEngine.UI.Image>();
                if (image2 != null)
                {
                    image2.sprite = sprite;
                    image2.enabled = (sprite != null);
                }
            }
        }

        //для снятия
        private void UpdatePlayerVisual(ItemType type)
        {
            string childName = GetChildNameByItemType(type);
            if (string.IsNullOrEmpty(childName)) return;

            Transform firstLevel = playerVisualRoot.Find(childName);
            if (firstLevel == null)
            {
                Debug.LogWarning($"Не найден объект визуализации для {childName}");
                return;
            }

            firstLevel.gameObject.SetActive(false);

            Transform secondLevel = firstLevel.Find(childName);
            if (secondLevel != null)
            {
                secondLevel.gameObject.SetActive(false);
            }
        }
        
        public override bool TryEquip(Item item)
        {
            foreach (var equipSlot in equipmentSlots)
            {
                if (equipSlot.CanAccept(item))
                {
                   // equipSlot.SetItem(item);
                   // ApplyStats(item.stats);
                  //  RaiseInventoryChanged();  // Обновить UI
                    return true;
                }
            }

            Debug.LogWarning($"Нет подходящего слота для предмета {item.itemName}");
            return false;
        }

        public void Equip(int index, Item item)
        {
            var equipSlot = equipmentSlots[index];
            equipSlot.SetItem(item);
            ApplyStats(item);
            RaiseInventoryChanged();
            UpdatePlayerVisual(item);
            SaveEquipment();
        }

        public void UnEquip(ItemType type)
        {
            foreach (var equipSlot in equipmentSlots)
            {
                if (equipSlot.acceptedType == type && equipSlot.EquippedItem != null)
                {
                    RemoveStats(equipSlot.EquippedItem);
                    equipSlot.Clear();
                    RaiseInventoryChanged();
                    UpdatePlayerVisual(equipSlot.acceptedType);
                    SaveEquipment();
                    return;
                }
            }
        }

        public void UnEquip(int index)
        {
            var equipSlot = equipmentSlots[index];
            RemoveStats(equipSlot.EquippedItem);
            equipSlot.Clear();
            RaiseInventoryChanged();
            UpdatePlayerVisual(equipSlot.acceptedType);
            SaveEquipment();
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
        
        public void ApplyStats(Item item)
        {
            if (item == null) return;

            if (item.inventorySlotsCount != 0)
            {
                characterStats.ChangeInventorySlots(item.inventorySlotsCount);
            }

            if (item.weight != 0)
            {
                characterStats.UpgradeStat(CharacterStatType.CarryCapacity, -item.weight);
            }

            foreach (var pair in item.GetStatModifiers())
            {
                characterStats.UpgradeStat(pair.Key, pair.Value);
            }
        }
        
        public void RemoveStats(Item item)
        {
            if (item == null) return;

            if (item.inventorySlotsCount != 0)
            {
                characterStats.ChangeInventorySlots(-item.inventorySlotsCount);
            }

            if (item.weight != 0)
            {
                characterStats.UpgradeStat(CharacterStatType.CarryCapacity, item.weight);
            }

            foreach (var pair in item.GetStatModifiers())
            {
                characterStats.UpgradeStat(pair.Key, -pair.Value);
            }
        }

        public IReadOnlyList<EquipmentSlot> GetEquipmentSlots() => equipmentSlots;
    }
}
