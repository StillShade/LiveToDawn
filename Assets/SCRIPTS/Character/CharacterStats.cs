using System;
using System.Collections.Generic;
using Character;
using Inventory;
using UnityEngine;

namespace Character
{
    public class CharacterStats : MonoBehaviour
    {
        [Header("Инвентарь")]
        [SerializeField]
        private int inventorySlotsCount = 2;
        public int InventorySlotsCount => inventorySlotsCount;
        
        [Header("Характеристики")]
        [SerializeField] private List<StatEntry> defaultStats = new();
        private Dictionary<CharacterStatType, int> stats = new();
        
        /*
        [Header("Базовые характеристики")]
        public int armor;               //броня
        public int carryCapacity ;      //вместимость переносимого веса
        public int radiationResistance; //сопротивление радиации
        public int coldResistance;      //сопротивление холоду
        public int damage;              //Урон
        public int speed;               //Скорость
        
        [Header("RPG Характеристики")]
        public int power;         // Сила
        public int agility;       // Ловкость
        public int intelligence;  // Интеллект
        public int luck;          // Удача
        public int stamina;     // Выносливость
        public int energy;        // Энергия
        public int health;        // Здоровье
        public int immunity;      // Иммунитет
        */

        public event Action<int> OnInventorySlotsChanged;
        public event Action<CharacterStatType, int> OnStatChanged;
        
        private void Awake()
        {
            var loaded = CharacterStatsSaver.Load();
            if (loaded != null)
                stats = new Dictionary<CharacterStatType, int>(loaded);
            else
            {
                InitFromInspectorDefaults();
                SaveStats();
            }
        }
        
        public void ChangeInventorySlots(int delta)
        {
            inventorySlotsCount += delta;
            OnInventorySlotsChanged?.Invoke(delta);
        }
        
        private void InitFromInspectorDefaults()
        {
            stats.Clear();
            foreach (CharacterStatType stat in Enum.GetValues(typeof(CharacterStatType)))
                stats[stat] = 0;

            foreach (var entry in defaultStats)
                stats[entry.stat] = entry.value;
        }

        public void UpgradeStat(CharacterStatType stat, int amount)
        {
            if (stats.ContainsKey(stat))
            {
                stats[stat] += amount;
                OnStatChanged?.Invoke(stat, stats[stat]);
            }
        }

        public int GetStatValue(CharacterStatType stat)
        {
            return stats.TryGetValue(stat, out int value) ? value : 0;
        }

        public void SaveStats() => CharacterStatsSaver.Save(stats);
    }
}
